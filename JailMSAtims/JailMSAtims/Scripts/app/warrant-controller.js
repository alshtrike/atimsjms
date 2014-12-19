app.controller('WarrantController', function ($scope, $http) {

    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all inmates information
    $http.get('/api/Inmates/').success(function (dataInmates)
                                        {
                                            $scope.inmates = dataInmates;
                                            $scope.loading = false;
                                        }).error(function ()
                                                {
                                                    $scope.error = "An Error has occured while loading posts!";
                                                    $scope.loading = false;
                                                });

    //get all warrants information
    $http.get('/api/Warrants/').success(function (dataWarrants)
                                        {
                                            $scope.warrants = dataWarrants;
                                            $scope.loading = false;
                                        }).error(function ()
                                                {
                                                    $scope.error = "An Error has occured while loading posts!";
                                                    $scope.loading = false;
                                                });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.warrant.editMode = !this.warrant.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Insert Warrant Warrant
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Warrants/', this.newwarrant).success(function (dataWarrant) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.warrants.push(dataWarrant);
            $scope.loading = false;
        }).error(function (dataWarrant) {
            $scope.error = "An Error has occured while Adding Warrant! " + dataWarrant;
            $scope.loading = false;
        });
    };

    //Edit Warrant
    $scope.save = function () {
        $scope.loading = true;
        var frien = this.warrant;
        $http.put('/api/Warrants/' + frien.id, frien).success(function (dataWarrant) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (dataWarrant) {
            $scope.error = "An Error has occured while Saving Warrant! " + dataWarrant;
            $scope.loading = false;
        });
    };

    //Delete Warrant
    $scope.deletewarrant = function () {
        $scope.loading = true;
        var id = this.warrant.id;
        $http.delete('/odata/Warrants/' + id).success(function (dataWarrant) {
            alert("Deleted Successfully!!");
            $.each($scope.warrants, function (i) {
                if ($scope.warrants[i].id === id) {
                    $scope.warrants.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (dataWarrant) {
            $scope.error = "An Error has occured while Saving Warrant! " + dataWarrant;
            $scope.loading = false;
        });
    };
});