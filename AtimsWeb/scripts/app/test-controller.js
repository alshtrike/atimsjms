atimsMainApp.controller('testController',  function ($scope,$http){
    $scope.gridOptions = {};
    $last = 50;
    /*specify percentage when lazy loading should trigger*/
    $scope.gridOptions.infiniteScrollPercentage = 15;

    /*loads the first 50 inmates*/
    $http.get('/api/inmate/'+$last).success(function (data) {
        $scope.gridOptions.data = data;

    })
    .error(function () {
        $scope.error="failed to load inmates"
    });

    /*loads 50 more inmates  as you keep scrolling*/
    $scope.gridOptions.onRegisterApi = function (gridApi) {
        gridApi.infiniteScroll.on.needLoadMoreData($scope, function () {
            $last = $last + 51;
            $http.get('/api/inmate/'+$last).success(function (data) {
                $scope.gridOptions.data = $scope.gridOptions.data.concat(data);
                gridApi.infiniteScroll.dataLoaded();

            })
    .error(function () {
        gridApi.infiniteScroll.dataLoaded();
    });
        });

    };
});