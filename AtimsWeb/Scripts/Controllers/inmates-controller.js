/// Inmates UI-Grid Controller
atimsApp.controller('InmatesController',  function ($scope,$http,InmatesService) {
    // Grid Options
    // @TOOD: Add column information to match the simple ViewModel for Inmates
    //   so that columns can be appropriately sized and linked to data
    $scope.gridOptions = {enableFiltering: true};

    // Loads all active Inmates
    this.loadActiveInmates = function( ){
        InmatesService.getActiveInmates( loadInmates );
    };
    var loadInmates = function (data){
        $scope.gridOptions.data = data;
    };

});