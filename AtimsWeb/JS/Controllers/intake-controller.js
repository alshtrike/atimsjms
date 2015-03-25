atimsApp.controller('IntakeController', function ($scope, $http) {

    

    $scope.addInmate = function () {

        $http.post('/api/Inmates/', this.newInmate).success(function (data) {
            alert("Added Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Inmate: " + data;
        });
    };


    $http.get('/api/Facilities/').success(function (data) {
        $scope.facilities = data;
        
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });
    $scope.changeFac = function (fac) {
        $scope.Facility = fac.FacilityName;
    };
});