//// Atims Inmates

/// Atims Inmates Service
// This service allows multiple controllers to use the same functions for
//   loading and saving  inmates to the database. This way, if the API changes,
//   only the service must be changed, not each and every controller.
// Note: Trying to retrieve ALL inmates will likely crash the browser, and
//   there is never a case where this is necessary.
// @TOOD: Implement functions to get/save inmates
//   - Specific Inmate ID
//   - List of Inmates by ID
//   - Search functions for inmates from database
atimsApp.service( 'AtimsInmatesService', function ($http) {
    
    // Retrieves all Inmates who are flagged as Active
    //   This may be a large amount of data and may take a moment to load,
    //   however, UI-Grid can handle infinite scrolling with a large number
    //   of inmates fine.
    this.getActiveInmates = function( callback ){
        $http.get('/api/Inmates')
            .success(function (data) {
                 callback( data );
            })
            .error(function () {
            });
    };

});


/// Inmates UI-Grid Controller
atimsApp.controller('AtimsInmateGridController',  function ($scope,$http,AtimsInmatesService) {
    // Grid Options
    // @TOOD: Add column information to match the simple ViewModel for Inmates
    //   so that columns can be appropriately sized and linked to data
    $scope.gridOptions = {enableFiltering: true};

    // Loads all active Inmates
    this.loadActiveInmates = function( ){
        AtimsInmatesService.getActiveInmates( loadInmates );
    };
    var loadInmates = function (data){
        $scope.gridOptions.data = data;
    };

});