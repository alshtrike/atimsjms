(function () {

    //   GlassHouse  -  Primary Angular Module
    var glassApp = angular.module( 'GlassHouseModule', [] );



    // GlassHouse  -  Primary Controller
    glassApp.controller( 'GlassHouseController', function( $scope ){

    });



    // GlassHouse  -  User Controller
    glassApp.controller('GlassHouseLoginController', function ($scope) {

        // Login Form Controller Data
        //  Default Login Text
        this.loginHeaderText = "Login Form Header";
        this.loginParagraphText = "Login Form Paragraph.";
        //  Default Show State
        this.showLoginForm = true;

        //  Lock/Unlock form input elements
        this.lockLoginForm = new function( ){
            $( ".login-input" ).prop( "disabled", true );
        }
        this.unlockLoginForm = new function ( ){
            $( ".login-input" ).prop( "disabled", false );
        }

        // Login Status Controller data
        //  Default Show State
        this.showLoginStatus = false;

    });



} )( );