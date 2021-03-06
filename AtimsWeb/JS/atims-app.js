// App Declaration
var atimsApp = angular.module('atimsApp', [
    // Bootstrap
    'ui.bootstrap', 'ui.utils',
    // UI-Grid
    'ui.calendar', 'ui.grid', 'ui.grid.resizeColumns', 'ui.grid.infiniteScroll',
    'ui.grid.selection', 'ui.grid.exporter'
]);

// Main Controller
atimsApp.controller('AtimsAppController', function ($scope, $http, $location) {
    // HTML Page Title
    $scope.pageTitle = "AtimsWeb";

    //// User Authentication
    // This variable controls whether the login page or the navigation page
    //   is displayed. Temporarily, this assumes the user is already logged
    //   in and sets the page to the AtimsWeb navigation page.
    $scope.userPage = "Views/Nav/Nav.cshtml";
    
    // @TODO: User Login verification
    //   Check if user has automatic authentication (windows auth?)
    //   If not, display login page (including custom modules such as biometrics)
    // $scope.userPage = "Views/Nav/Login.cshtml";

});