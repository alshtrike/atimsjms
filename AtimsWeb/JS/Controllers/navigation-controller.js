//// Atims Web Navigation
// Navigation is loaded after a user has successfully logged in. This controls
//   App, Module, and Submodule navigation.
atimsApp.controller('NavigationController', function ($scope, $http, $location, UserService) {
    //// Variables

    /// Current Page / URL Handling
    // For current page handling, two major types of functions are used.
    //   display____()
    //     These functions are internal functions that directly manipulate
    //     $scope.page and handle loading the side bar navigation.
    //   goTo____()
    //     These functions are public $scope functions that are designed to be
    //     called from outside the controller and set the URL.
    // The major difference is that the display_____() functions will not
    //   set the URL, and if they are used for page navigation, they will not
    //   be able to be bookmarked. This is not suitable for general use, and
    //   in all cases from the HTML page, the goTo____() functions should be
    //   used.
    // Whenever the URL is set or changed (either by the user, or through one of
    //   the goTo____() functions), the checkUrl(Event) function is called.
    //   The default behavior is to assume the URL is in the form "#/Module/SubModule"
    //   and will be parsed as such. If the Module and SubModule are found, the
    //   displaySubModule() function will also update the sidebar menu. If # is
    //   missing, or there is nothing after it, the nav will assume the user is
    //   attempting to go to their homepage, and will redirect the URL.

    // $scope.page is the currently selected page. In the general case, this value
    //   is set using goToSubModule instead of displayPage to ensure the correct
    //   subModule menu is displayed. Setting this directly or using displayPage
    //   will NOT update the menu, but will allow any page to be displayed.
    $scope.page = "";

    // $scope.selectedAppId is used to select modules based on which "app" is being
    //   presented. This value is determined from the AppAO_Module.AppAO_id column,
    //   and is parsed server side through the API to prevent unecessary modules from
    //   being sent to the browser.
    $scope.selectedAppId = -1
    // $scope.selectedModule is the currently selected module object
    $scope.selectedModule = null;
    // $scope.selectedSubModule is the currently selected subModule object
    $scope.selectedSubModule = null;

    /// Modules
    // $scope.moduleMenu is the list of all loaded modules recieved from the
    //   server. This is directly linked using ng-repeat to display the menu
    $scope.moduleMenu = [];
    // $scope.moduleNameMap is a HashTable that maps the name of each loaded
    //   module to the javascript module object. This is primarly used for URL
    //   and page routing.
    $scope.moduleNameMap = {};

    /// User Specific Elements
    // $scope.alertMenu is a cache of the alerts loaded for the current user.
    // @TODO: Eventually implement a way to check for new alerts. As is, the
    //   only alerts displayed are those loaded at the time of login.
    $scope.alertMenu = UserService.alerts;


    //// App / Module and SubModule Loading Functions
    
    /// Loading the App
    // loadApp cleans the page and then starts to load the set of modules
    //   and subModuels associated with the app id (AppAO_Module.AppAO_id).
    //   Currently only JMS (AppAO_id = 4) is being implemented.
    //   @TODO: This may need to change to load by name once other apps are being
    //     implemented. See $scope.goToApp(id) below.
    var loadApp = function (appId) {
        // Clear variables for loading the new app
        $scope.moduleNameMap = {};
        $scope.moduleMenu = [];
        $scope.subModuleMenu = [];
        $scope.selectedAppId = appId;
        $scope.selectedModule = null;
        $scope.page = "";
        $http.get("api/Modules/" + $scope.selectedAppId)
            .success(function (data) { setupModules(data) })
            .error(function (data) { loadAppFailed(data) });
    };
    // loadAppFailed(data) is called when the $http function returns an error code.
    //   This is not intended to catch exceptions, which should bubble to the console.
    //   @TODO: Failure Handling (maybe go to 404 page?)
    var loadAppFailed = function (data) {
        // @TODO: I do nothing, someone fix me :D
        console.log( "Module HTTP Request Failed: " + data );
    };
    // setupModules is called from a successful $http.get request in loadApp, and
    //   will attempt to load the modules and subModules from the recieved Json data
    var setupModules = function (data) {
        // Load all Modules and SubModules
        //   Json Parse
        var rawMenuList = angular.fromJson(data);
        //   For each module:
        //     Add each module to moduleNameMap, and if visible to $scope.moduleMenu.
        //     Add variables for subModuleMenu and subModuleNameMap arrays.
        //     Populate subModuleMenu and subModuleNameMap for each child subModule.
        for (var i = 0; i < rawMenuList.length; i++) {
            var module = rawMenuList[i];
            module.subModuleMenu = [];
            module.subModuleNameMap = {};
            $scope.moduleNameMap[module.Name] = module;
            $scope.moduleMenu.push(module);
            // Add each subModule to its parent's subModuleNameMap, and if visible
            //   to its parent's subModuleMenu.
            for (var j = 0; j < module.SubModules.length; j++) {
                var subModule = module.SubModules[j];
                module.subModuleMenu.push(subModule);
                module.subModuleNameMap[subModule.Name] = subModule;
            }
        }
        // At this point: App, Modules, and SubModules have been successfully loaded
        //   @TODO: Implement individual app home pages
        $scope.checkUrl(null);
        //   Ensure webpage is snapped in place
        $scope.resizeHandler();
        //   Hide loading screen and show website
        $scope.showLoading(false);
    };


    //// Current Page / URL Handling
    // @TODO: subModule assumes JMS for null usercontrol. Fix this for multiple apps.
    // @TODO: Implement automatic homepage based on User Preferences
    //    (See $scope.goToHome() below)
    // @TODO: Implement refresh page button

    /// Current Page
    // displayPage attempts to load a new page into the ng-include
    // @TODO: Check if page does not exist for 404 handling
    var displayPage = function (newPage) {
        $scope.page = newPage;
    };
    // displaySubModule(moduleName, subModuleName) attempts to find and load the
    //   module/subModule pair into the menu's, and then passes the subModules
    //   link to displayPage
    var displaySubModule = function (moduleName, subModuleName) {
        // Find the requested module
        var module = $scope.moduleNameMap[moduleName];
        if (module == undefined) {
            display404("Module not found: " + moduleName);
            return;
        }
        $scope.selectedModule = module;

        // Find the requested subModule
        var subModule = module.subModuleNameMap[subModuleName]
        if (subModule == undefined) {
            display404("SubModule not found: " + moduleName + "/" + subModuleName);
            return;
        }
        $scope.selectedSubModule = subModule;

        // Try to go to the subModule's page
        if ($scope.selectedSubModule.Usercontrol == null) {
            $scope.selectedSubModule.Usercontrol =
            "Views/JMS/" + encodeURI(moduleName) + "/" + encodeURI(subModuleName) + ".cshtml";
        }
        displayPage($scope.selectedSubModule.Usercontrol);
    };
    // Displays the 404 error page
    var display404 = function (errorInfo) {
        displayPage( "Views/Nav/404.cshtml" );
        console.log( errorInfo );
    };
    // $scope.pageLoaded() is called after $scope.page has been successfully loaded
    //   with ng-include
    $scope.pageLoaded = function () {
        // @TODO: I do nothing, someone fix me :D
    };
    /// URL Handling
    // Displays the requested page
    $scope.goToPage = function (pageName) {
        displayPage( pageName );
    };
    // goToApp(appID) is currently not in use as only the JMS (AppAO_id = 4) is being implemented
    //   @TODO: This may need to change to by name instead of id when the time comes
    $scope.goToApp = function (id) {
        $scope.showLoading( true );
        loadApp(id);
    };
    // goToSubModule(moduleName, subModuleName) is used inside the web pages for link
    //   urls. This is equivalent to href="#/moduleName/subModuleName/"
    $scope.goToSubModule = function (moduleName, subModuleName) {
        $location.path("/" + moduleName + "/" + subModuleName);
    };
    // Displays the users personal home page
    $scope.goToHome = function () {
        $location.path( UserService.user.HomePage );
    };
    // checkUrl(event) is called every time the browser url is changed. 
    //   This can be called in case the current URL has not been loaded
    $scope.checkUrl = function (event) {
        // Wait until we're loaded (it will call checkURL anyways)
        if( $scope.moduleMenu.length == 0 )
            return;

        var rawpath = $location.path();
        // Matches "" "#" and "#/" which should all lead to the users home page
        if( rawpath.match( /^#?\/?$/ ) ){
            $scope.goToHome();
        }else{
            var path = $location.path().split('/');
            displaySubModule(path[1], path[2]);
        }
    };
    // This links the event and function for when the URL has changed.
    $scope.$on('$locationChangeSuccess', $scope.checkUrl);
    

    //// Window Styling - CSS Synergy
    // @TODO: Implement CSS changes for highlighting current module
    //    (see index.html for subModule highlighting)
    // SubModule Menu Toggle
    $scope.menuToggleText = "<<";
    $scope.menuToggle = function () {
        $("#wrapper").toggleClass("toggled");
        $scope.menuToggleText = ($scope.menuToggleText === "<<")? ">>" : "<<";
    };
    // Shows or Hides the full page loading screen
    $scope.showLoading = function (toShow) {
        if ($("#loading").hasClass("toggled") === toShow) {
            $("#loading").toggleClass("toggled");
            $("#loading-hider").toggleClass("toggled");
        }
    };
    // Window Resize Fixed Position Handler
    $scope.resizeHandler = function () {
        // Get navbar-over and navbar-under
        var navbarOver = $(".navbar-over");
        // Get bottom of navbarOver
        var navbarUnder = $(".navbar-under");
        // Set navbar-under flush against navbar-over
        navbarUnder.css("top", navbarOver.offset().top + navbarOver.outerHeight() + "px");
        // Set wrapper flush against navbarUnder
        $("#wrapper").css("top", ( navbarUnder.offset().top + navbarUnder.outerHeight() ) + "px");
    };
    $(window).resize($scope.resizeHandler);


    //// Default Behavior
    // @TODO: Move this to AtimsMainController once user login has been implemented
    // Load JMS App (AppAO_id = 4)
    loadApp(4);
});