

    // GlassHouse Main Controller
    var glassHouseApp = angular.module( "glassHouseApp", [] );

    glassHouseApp.controller( "GlassHouseController", function( $scope ){

    });

    glassHouseApp.controller( "GlassHouseLoginController", function( $scope ){
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
        
    });
    

