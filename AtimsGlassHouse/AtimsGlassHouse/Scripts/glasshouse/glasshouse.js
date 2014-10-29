

// Config Functions
    
    var glassHouseConfig = function( $routeProvider ) {
        // Routing
    }
    glassHouseConfig.$inject = ['$routeProvider'];
    

    // Controller Functions
    var glassHouseController = function( $scope ){
        $scope.glassPageTitle = "Atims GlassHouse";

    };
    glassHouseController.$inject = ['$scope'];

    var glassHouseLoginController = function( $scope ){
        // Login Page View Control
        this.currentView = "loginForm";
        this.showingView = function( viewName ){
            return viewName == this.currentView;
        }
        this.switchView = function( viewName ){
            this.currentView = viewName;
        };


        // Login Processing Control
        // Wait what? Why is there nothing here :(
        // TODO: this.


        // Login Form Control
        this.submitLoginForm = function( ){
            this.switchView( "loginProcessing" );
            // TODO: Login submit
        };

        // Forgot Password Form Control
        this.submitLoginForgot = function( ){
            this.switchView( "loginProcessing" );
            // TODO: Forgot form submit
        };
        
    };
    glassHouseLoginController.$inject = ['$scope'];


    // App Declaration
    var glassHouseApp = angular.module( "glassHouseApp", ['ngRoute'] );
    glassHouseApp.config( glassHouseConfig );
    
    glassHouseApp.controller( "GlassHouseController", glassHouseController );
    glassHouseApp.controller( "GlassHouseLoginController", glassHouseLoginController );
    

