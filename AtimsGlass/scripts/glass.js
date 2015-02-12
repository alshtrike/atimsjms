// Main Controller
var glassHouseController = function ($scope, $http, $rootScope, $location) {
    //// Variables

    /// Web Page
    //    HTML Page Title
    $scope.glassPageTitle = "Atims GlassHouse";

    /// Modules
    //   Modules in angular are currently using a different variable naming
    //     convention than the AppAO_Module definition, as well as using additional
    //     variables to assist in displaying the menus and the current subModule
    //     page. Unlike other data models, modules and subModules should not be
    //     changed from the web interface and therefore do not need to be sent
    //     back in the same format as recieved in Json.
    //   AppAO_Module's are stored with the form
    //     { id, name, tooltip, link, subModuleNameMap, subModuleMenu }
    //     Note: subModuleMenu does not include subModules which are not set as
    //     visible. However, these modules will still exist in subModuleNameMap and
    //     can be accessed by URL
    //   AppAO_SubModules are stored inside their parent module's subModuleMenu and
    //     subModuleNameMap with the form
    //     { id, name, tooltip, link, parentid }

    // moduleIdMap is a HashTable that maps the database key id (AppAO_Module_id) of
    //   each loaded AppAO_Module to the javascript module object. This is primarily
    //   used by subModules that reference their parent by id rather than name.
    $scope.moduleIdMap = {};
    // moduleNameMap is a HashTable that maps the name (AppAO_Module_Name) of each
    //   loaded module to the javascript module object. This is primarly used for
    //   URL and page routing.
    $scope.moduleNameMap = {};
    // moduleMenu is the list of all loaded modules which are set to be visible
    //   (AppAO_Module_visible = 1). This is directly linked using ng-repeat in
    //   the index.html file for displaying the top menu.
    $scope.moduleMenu = [];
    // subModuleMenu is the list of all loaded subModules for the currently
    //   selected module. Generally, this is both set from and should be the same
    //   value as $scope.selectedModule.subModuleMenu. However, this is intentionally
    //   kept separate for when pages that need to be displayed are not linked to a
    //   subModule and the lefthand menu must represent that. This is directly linked
    //   using ng-repeat in the index.html file for displaying the left menu.
    $scope.subModuleMenu = [];
    
    /// Current Page / URL Handling
    //   The current page is based off of three key values: the current app, the
    //     current module, and the current subModule. While it is possible to load
    //     other pages using displayPage( url ), this is not the normal behavior. 
    //     Currently, the only app being implemented is the JMS, whose id is 4.
    //   When either a URL is entered, or a link is clicked, the function
    //     goToSubModule( moduleName, subModuleName) is called and the name of the
    //     module and subModule are checked against the name map hashtables. The
    //     actual page is displayed using ng-include with the link retrieved from
    //     the database stored in each subModule.

    // $scope.selectedAppId is used to select modules based on which "app" is being
    //   presented. This value is determined from the AppAO_Module.AppAO_id column,
    //   and is parsed server side through the API to prevent unecessary modules from
    //   being sent to the browser.
    $scope.selectedAppId = 4;
    // $scope.selectedModule is the currently selected module object
    $scope.selectedModule = null;
    // $scope.selectedSubModule is the currently selected subModule object
    $scope.selectedSubModule = null;
    // $scope.page is the currently selected page. In the general case, this value
    //   is set using goToSubModule instead of displayPage to ensure the correct
    //   subModule menu is displayed. Setting this directly or using displayPage
    //   will NOT update the menu, but will allow any page to be displayed,
    //   including those not linked to a subModule. In the general case, this
    //   value is set to  "Views/" + $scope.selectedSubModule.link
    $scope.page = "";


    //// App / Module and SubModule Loading Functions
    
    /// Loading the App
    // $scope.loadApp cleans the page and then starts to load the set of modules
    //   and subModuels associated with the app id (AppAO_Module.AppAO_id). Currently
    //   only JMS (AppAO_id = 4) is being implemented.
    //   @TODO: Implement a loading screen to prevent the webpage from
    //     showing up piecewise.
    $scope.loadApp = function( appId ){
        // Clear variables for loading the new app
        $scope.moduleIdMap = {};
        $scope.moduleNameMap = {};
        $scope.moduleMenu = [];
        $scope.subModuleMenu = [];
        $scope.selectedAppId = 4;
        $scope.selectedModule = null;
        $scope.selectedSubModule = null;
        $scope.page = "";
        // Set the requested appId
        $scope.selectedAppId = 4;
        // This function makes a request using $http.get to the server for the
        //   modules and subModules associated with app based on $scope.appId
        //   This function also automatically calls getAppSubModules( ) once
        //   the modules have finished loading. This is to prevent accidentally
        //   trying to load subModules before their parent modules exist.
        getAppModules( );
    }
    // Called when all sub modules have been loaded
    //   This function is called from setupSubModules( ) which in turn is called by
    //   getAppSubModules( ) when the $http.get( ) request is successful.
    //   @TODO: Success Handling (in conjunction with implementing loading screen?)
    var loadAppSuccess = function( ){
        $scope.glassLoaderToggle( );
        resizeHandler( );
        urlChangeEvent( null );
    }
    // Called when an exception is thrown while trying to load the requested app
    //   @TODO: Failure Handling (maybe go to 404 page?)
    var loadAppFailed = function( data ){
        // @TODO: I do nothing, someone fix me :D
        console.log( "Failed: " + data );
    }

    /// Setting up modules
    // getAppModules uses $http.get to query the server for a list of modules needed
    //   for the current app determined by $scope.selectedAppID
    var getAppModules = function( ){
        try{
            $http.get( "api/AppAO_Module/" + $scope.selectedAppId)
                .success(function (data) { setupModules(data) })
                .error(function (data) { loadAppFailed(data) });
        }catch (err){
            loadAppFailed(err);
        }
    }
    // setupModules is called from a successful $http.get request in getAppModules( ),
    //   and attempts to load the modules from the recieved Json data
    var setupModules = function (data) {
        try{
            // Sort Function
            var moduleOrder = function (a, b) {
                return a.AppAO_Module_order - b.AppAO_Module_order;
            }
            // Json Parse
            var rawMenuList = angular.fromJson(data);
            // Organize for display in $scope.moduleMenu
            rawMenuList.sort(moduleOrder);
            for (var i = 0; i < rawMenuList.length; i++) {
                // rawModule is directly tied to the server-recieved AppAO_Module 
                //   and includes all queryable variables
                var rawModule = rawMenuList[i];
                // Check if a module with the same name exists already. Modules with visibility
                //   set higher will load first, HOWEVER, modules with the same name should never
                //   be loaded; If this occurs, check the query URL and the AppAO_ModuleController
                //   The module will not be loaded, but this will not throw an exception
                if( rawModule.AppAO_Module_Name in $scope.moduleNameMap ){
                    console.error( "Attempt to load module with the same name as one which is already loaded. \n"
                        + "Loaded Module ID: " + $scope.moduleNameMap[rawModule.AppAO_Module_Name] + "\n"
                        + "Failed Module ID: " + rawModule.AppAO_Module_id + "\n" );
                }else{
                    // Build module from the raw AppAP_Module
                    var module = {
                        id: rawModule.AppAO_Module_id,
                        name: rawModule.AppAO_Module_Name,
                        tooltip: rawModule.AppAO_Module_ToolTip,
                        // @TODO: Note: These linked pages are not currently planned to be reachable and will
                        //   most likely redirect to a preferred submodule (Maybe the first?)
                        link: "Views/" + rawModule.AppAO_Module_Name + "/" + rawModule.AppAO_Module_Name + ".html",
                        subModuleNameMap: {},
                        subModuleMenu: []
                    };
                    // Store Module
                    $scope.moduleNameMap[rawModule.AppAO_Module_Name] = module;
                    $scope.moduleIdMap[rawModule.AppAO_Module_id] = module;
                    if (rawMenuList[i].AppAO_Module_visible == 1) {
                        $scope.moduleMenu.push(module);
                    }
                }
            }
        }catch (err){
            loadAppFailed(err);
        }
        // We only want to retrieve the subModules once modules have finished loading
        getAppSubModules( );
    }

    /// Setting up subModules
    // getAppSubModules uses $http.get to query the server for a list of modules needed
    //   for the current app determined by $scope.selectedAppID
    var getAppSubModules = function( ){
        try{
            $http.get("api/AppAO_SubModule/" + $scope.selectedAppId)
                .success(function (data) { setupSubModules(data) })
                .error(function (data) { failedMenu(data) });
        }catch (err){
            loadAppFailed(err);
        }
    }
    // setupModules is called from a successful $http.get request in getAppSubModules( ),
    //   and attempts to load the subModules from the recieved Json data
    var setupSubModules = function (data) {
        try{
            // Sort Function
            var subModuleOrder = function (a, b) {
                return a.AppAO_SubModule_order - b.AppAO_SubModule_order;
            }
            // Json Parse
            var rawSubMenuList = angular.fromJson(data);
            // Organize for display in $scope.subModuleMenu
            rawSubMenuList.sort(subModuleOrder);
            for (var i = 0; i < rawSubMenuList.length; i++) {
                // rawSubModule is directly tied to the server-recieved AppAO_SubModule
                //   and includes all queryable variables
                var rawSubModule = rawSubMenuList[i];
                // Find the intended parent module
                var parentModule = $scope.moduleIdMap[rawSubModule.AppAO_Module_id];
                // Check if the parent is loaded. If not, this module is either set to have the wrong
                //   parent module, or the parent module has the wrong AppAO_Module_id set, and was
                //   not loaded as intended. The subModule will not be loaded, but this will not
                //   throw an exception.
                if( parentModule == undefined ){
                    console.error( "Attempt to load subModule whose parent is missing \n"
                        + "Failed SubModule ID: " + rawSubModule.AppAO_SubModule_id + "\n"
                        + "Missing Parent Module ID: " + rawSubModule.AppAO_Module_id + "\n" );
                // Check if a subModule with the same name exists already. SubModules with visibility
                //   set higher will load first, HOWEVER, subModules with the same name should never
                //   be loaded; If this occurs, check the query URL and the AppAO_ModuleController.
                //   The subModule will not be loaded, but this will not throw an exception.
                }else if( rawSubModule.AppAO_SubModule_Name in parentModule.subModuleNameMap ){
                    console.error( "Attempt to load subModule with the same name as one which is already loaded. \n"
                        + "Loaded Module ID: " + parentModule.subModuleNameMap[rawSubModule.AppAO_SubModule_Name].id + "\n"
                        + "Failed Module ID: " + rawSubModule.AppAO_SubModule_id + "\n" );
                }else{
                    // Build Module
                    var subModule = {
                        id: rawSubModule.AppAO_SubModule_id,
                        name: rawSubModule.AppAO_SubModule_Name,
                        tooltip: rawSubModule.AppAO_Module_ToolTip,
                        // @TODO: Fix the server side value of AppAO_SubModule_usercontrol
                        //   Currently all values are for the old implementation
                        link: "Views/" + rawSubModule.AppAO_SubModule_usercontrol,
                        parentid: rawSubModule.AppAO_Module_id
                    };
                    // Store Module
                    if( rawSubModule.AppAO_SubModule_visible ){
                       parentModule.subModuleMenu.push(subModule);
                    }
                    parentModule.subModuleNameMap[ rawSubModule.AppAO_SubModule_Name ] = subModule;
                }
            }
            loadAppSuccess( );
        }catch (err){
            loadAppFailed(err);
        }
    }


    //// Current Page / URL Handling
    // @TODO: Implement URL Get/Set
    // @TODO: Implement a 404 page (See display404( ) function below -- it's empty)
    // @TODO: Implement a default subModuleMenu for cases where a page
    //   is loaded which is NOT loaded from a submodule.
    // @TODO: Implement automatic homepage based on User Preferences.

    /// Current Page
    // displayPage attempts to load a new page into the ng-include
    var displayPage = function (newPage) {
        // Check if the requested page is already loaded, and set the page to
        //   null first. If you *only* set the page to the same value, angular
        //   will assume the page is the same and does not need to be reloaded.
        if( $scope.page ==  newPage )
            $score.page = "";
        $scope.page = newPage;
    };

    // displaySubModule(moduleName, subModuleName) attempts to find and load the
    //   module/subModule pair into the menu's, and then passes the subModules
    //   link to displayPage
    var displaySubModule = function (moduleName, subModuleName) {
        // Module
        //   Find the requested module, and check if it exists
        var module = $scope.moduleNameMap[moduleName];
        if( module == undefined ){
            display404( "Module not found: " + moduleName );
            return;
        }
        //   If exists, set it to current
        $scope.selectedModule = module;

        // SubModule
        //   Find the requested subModule, and check if it exists
        var subModule = $scope.selectedModule.subModuleNameMap[subModuleName]
        if( subModule == undefined ){
            display404( "SubModule not found: " + moduleName + "/" + subModuleName );
            return;
        }
        //   If exists, set it to current
        $scope.selectedSubModule = subModule;

        // Try to go to the subModule's page
        displayPage( $scope.selectedSubModule.link );
    }

    // Displays the 404 error page
    //   @ TODO: Implement this (See above - No 404 page exists as of writing this)
    var display404 = function (errorInfo){
        // @TODO: I do nothing, someone fix me :D
    }

    // $scope.pageLoaded is called after $scope.page has been successfully loaded
    //   with ng-include
    $scope.pageLoaded = function ( ){
        // @TODO: I do nothing, someone fix me :D
    };
    
    /// URL Handling
    // goToSubModule(moduleName, subModuleName) is used inside the web pages for link
    //   urls. This is equivalent to href="#/moduleName/subModuleName/"
    $scope.goToSubModule = function (moduleName, subModuleName){
        $location.path( "/" + moduleName + "/" + subModuleName );
    }
    // goToPath(path) is used inside the web pages to set the url directly, instead of
    //   using goToSubModule to format it. This can also allow URL's that do not follow
    //   the URL convention.
    $scope.goToPath = function(path){
        $location.path( path );
    }
    // urlChangeEvent(event) is called every time the browser url is changed. 
    var urlChangeEvent = function(event){
        var path = $location.path().split('/');
        var moduleName = path[1];
        var subModuleName = path[2];
        displaySubModule( moduleName, subModuleName );
    }
    // This links the event and function for when the URL has changed.
    $scope.$on('$locationChangeSuccess', urlChangeEvent);



    //// Window Styling - CSS Synergy
    // @TODO: Implement CSS changes for highlighting current module here instead
    //   inline in the html.

    // SubModule Menu Toggle
    //   @TODO: Maybe change "<<" to ">>" when menu is toggled?
    $scope.menuToggleText = "<<";
    $scope.menuToggle = function( ){
        $("#wrapper").toggleClass("toggled");
    };
    // Loading Splash Toggle
    $scope.glassLoaderToggle = function( ){
        $("#glass-loading").toggleClass("toggled");
        $("#glass-loading-hider").toggleClass("toggled");
    }
    // Window Resize Fixed Position Handler
    var resizeHandler = function( ){
        // Get navbar-over and navbar-under
        var navbarOver = $(".navbar-over");
        // Get bottom of navbarOver
        var navbarUnder = $(".navbar-under");
        // Set navbar-under flush against navbar-over
        navbarUnder.css("top", navbarOver.offset().top + navbarOver.outerHeight() + "px");
        // Set wrapper flush against navbarUnder
        $("#wrapper").css("top", ( navbarUnder.offset().top + navbarUnder.outerHeight() ) + "px");
        console.log( navbarOver.offset().top + navbarOver.outerHeight() + "px" );
    }
    $( window ).resize( resizeHandler );



    //// Default Behavior
    // Load JMS App (AppAO_Module_id = 4)
    $scope.loadApp( 4 );
    // Load the default home page
    displayPage( "Views/Home/Home.html" );

};
glassHouseController.$inject = ['$scope','$http','$rootScope','$location'];

// App Declaration
var glassHouseApp = angular.module('glassHouseApp', []);
glassHouseApp.controller('GlassHouseController', glassHouseController);