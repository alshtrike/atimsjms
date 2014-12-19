app.controller('FacilityController', function ($scope, $http) {

    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all facilities information
    $http.get('/api/Facilities/').success(function (data) {
        $scope.facilities = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.facility.editMode = !this.facility.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Insert Facility Facility
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Facilities/', this.newfacility).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.facilities.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Facility! " + data;
            $scope.loading = false;
        });
    };

    //Edit Facility
    $scope.save = function () {
        $scope.loading = true;
        var frien = this.facility;
        $http.put('/api/Facilities/' + frien.Id, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Facility! " + data;
            $scope.loading = false;
        });
    };

    //Delete Facility
    $scope.deletefacility = function () {
        $scope.loading = true;
        var id = this.facility.Id;
        $http.delete('/api/Facilities/' + id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.facilities, function (i) {
                if ($scope.facilities[i].Id === id) {
                    $scope.facilities.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Facility! " + data;
            $scope.loading = false;
        });
    };
});