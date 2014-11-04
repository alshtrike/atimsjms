app.service('inmateService', function ($http) {

    //create new inmate
    this.post = function (Inmate) {
        var request = $http({
            method: "post",
            url: "/api/Inmates",
            data: Inmate
        });
        return request;
    }
});