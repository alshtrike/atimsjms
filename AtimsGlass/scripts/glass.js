
// Main Controller
var glassHouseController = function ($scope, $http) {
    $scope.glassPageTitle = "Atims GlassHouse";
    $scope.moduleMenu = [];
    $scope.selectedModule = "Home";

    $http.get( "api/Module" )
        .success(function (data) { setupModules(data) })
        .error(function (data) { failedManu(data) });
    

    var setupModules = function (data) {
        var rawList = angular.fromJson(data);
        var byOrder = function (a, b) {
            return a.AppAO_Module_order - b.AppAO_Module_order;
        }
        rawList.sort(byOrder);
        for (var i = 0; i < rawList.length; i++) {
            if (rawList[i].AppAO_Module_visible == 1) {
                $scope.moduleMenu.push({
                   name: rawList[i].AppAO_Module_Name,
                   submodules: rawList[i].AppAO_SubModule,
                   tooltip: rawList[i].AppAO_Module_ToolTip
                });
            }
        }

        $scope.theoutput = "Module Database Loaded";
    }

    var failedMenu = function (data) {
        $scope.theoutput = "Failed.";
    }

};
glassHouseController.$inject = ['$scope','$http'];


// App Declaration
var glassHouseApp = angular.module('glassHouseApp', []);
glassHouseApp.controller('GlassHouseController', glassHouseController);

