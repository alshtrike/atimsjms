
// Main Controller
var glassHouseController = function ($scope, $http) {
    // Variables
    // Page Title
    $scope.glassPageTitle = "Atims GlassHouse";
    // Modules
    $scope.modules = [];
    $scope.moduleMenu = [];
    $scope.moduleIdMap = {};
    $scope.moduleNameMap = {};
    // Sub Modules
    $scope.subModuleMenu = [];
    // Location
    $scope.selectedModule = null;
    $scope.selectedModuleName = "Home";
    $scope.selectedSubModule = null;
    $scope.selectedSubModuleName = "";


    // Page / URL Control
    $scope.goToSubModule = function (moduleName, subModuleName) {
        console.log( moduleName + " / " + subModuleName );
        $scope.selectedModule = $scope.moduleNameMap[moduleName];
        $scope.selectedModuleName = moduleName;

        $scope.selectedSubModule = $scope.selectedModule.subModuleNameMap[subModuleName];
        $scope.selectedSubModuleName = subModuleName;

        $scope.changePage( $scope.selectedSubModule.link );
    }

    $scope.changePage = function (newPage) {
        $scope.page = newPage;
    };

    $scope.pageLoaded = function () {
        //placeholder for function called when new page is loaded
    };


    // Setting up Modules
    $http.get( "api/AppAO_Module" )
        .success(function (data) { setupModules(data) })
        .error(function (data) { failedMenu(data) });

    var setupModules = function (data) {
        // Sort Function
        var moduleOrder = function (a, b) {
            return a.AppAO_Module_order - b.AppAO_Module_order;
        }
        // Json Parse
        var rawMenuList = angular.fromJson(data);
        // Organize for display in $scope.moduleMenu
        rawMenuList.sort(moduleOrder);
        for (var i = 0; i < rawMenuList.length; i++) {
            var rawModule = rawMenuList[i];
            // Build Module
            var module = {
                id: rawModule.AppAO_Module_id,
                name: rawModule.AppAO_Module_Name,
                tooltip: rawModule.AppAO_Module_ToolTip,
                link: "Views/" + rawModule.AppAO_Module_Name + "/" + rawModule.AppAO_Module_Name + ".html",
                subModules: [],
                subModuleNameMap: {},
                subModuleMenu: []
            };
            // Store Module
            $scope.modules.push(module);
            $scope.moduleNameMap[rawModule.AppAO_Module_Name] = module;
            $scope.moduleIdMap[rawModule.AppAO_Module_id] = module;
            if (rawMenuList[i].AppAO_Module_visible == 1) {
                $scope.moduleMenu.push(module);
            }
        }
    }


    // Setting up SubModules
    $http.get("api/AppAO_SubModule")
        .success(function (data) { setupSubModules(data) })
        .error(function (data) { failedMenu(data) });

    var setupSubModules = function (data) {
        // Sort Function
        var subModuleOrder = function (a, b) {
            return a.AppAO_SubModule_order - b.AppAO_SubModule_order;
        }
        // Json Parse
        var rawSubMenuList = angular.fromJson(data);
        // Organize for display in $scope.subModuleMenu
        rawSubMenuList.sort(subModuleOrder);
        for (var i = 0; i < rawSubMenuList.length; i++) {
            // Build Module
            var rawSubModule = rawSubMenuList[i];
            var subModule = {
                id: rawSubModule.AppAO_SubModule_id,
                name: rawSubModule.AppAO_SubModule_Name,
                parentid: rawSubModule.AppAO_Module_id,
                tooltip: rawSubModule.AppAO_Module_ToolTip,
                link: "Views/" + rawSubModule.AppAO_SubModule_usercontrol
            };
            // Store Module
            var parentModule = $scope.moduleIdMap[rawSubModule.AppAO_Module_id];
            parentModule.subModules.push(subModule);
            if( rawSubModule.AppAO_SubModule_visible ){
                parentModule.subModuleMenu.push(subModule);
            }
            parentModule.subModuleNameMap[ rawSubModule.AppAO_SubModule_Name ] = subModule;
        }
    }


    // Window Styling - CSS Synergy
    // SubModule Menu Toggle
    $scope.menuToggleText = "<<";
    $scope.menuToggle = function( ){
        $("#wrapper").toggleClass("toggled");
    };

    $scope.page = "Views/Home/Home.html";

};
glassHouseController.$inject = ['$scope','$http'];


// App Declaration
var glassHouseApp = angular.module('glassHouseApp', []);
glassHouseApp.controller('GlassHouseController', glassHouseController);

