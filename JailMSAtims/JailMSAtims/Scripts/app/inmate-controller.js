app.controller('InmateController', function ($scope, $http) {

    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;
    //get a list of all facilities

    $http.get('/api/Facilities/').success(function (data) {
        $scope.facilities = data;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });

    //get all inmates information
    $http.get('/api/Inmates/').success(function (data) {
        $scope.inmates = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.inmate.editMode = !this.inmate.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Insert Inmate
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Inmates/', this.newinmate).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.inmates.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Inmate: " + data;
            $scope.loading = false;
        });
    };

    //Edit Inmate
    $scope.save = function () {
        $scope.loading = true;
        var frien = this.inmate;
        $http.put('/api/Inmates/' + frien.Id, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Inmate! " + data;
            $scope.loading = false;
        });
    };

    //Delete Inmate
    $scope.deleteinmate = function () {
        $scope.loading = true;
        var id = this.inmate.Id;
        $http.delete('/api/Inmates/' + id+'/').success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.inmates, function (i) {
                if ($scope.inmates[i].Id === id) {
                    $scope.inmates.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Inmate! " + data;
            $scope.loading = false;
        });
    };

});