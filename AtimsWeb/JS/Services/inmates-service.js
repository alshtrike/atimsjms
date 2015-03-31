//// Atims Inmates

/// Atims Inmate's Service
// This service allows multiple controllers to use the same functions for
//   loading and saving  inmates to the database. This way, if the API changes,
//   only the service must be changed, not each and every controller.
// Note: Trying to retrieve ALL inmates will likely crash the browser, and
//   there is never a case where this is necessary.
// @TOOD: Implement functions to get/save inmates
//   - Specific Inmate ID
//   - List of Inmates by ID
//   - Search functions for inmates from database
atimsApp.service('InmatesService', function ($http) {

    // Retrieves all Inmates who are flagged as Active
    //   This may be a large amount of data and may take a moment to load,
    //   however, UI-Grid can handle infinite scrolling with a large number
    //   of inmates fine.
    this.getActiveInmates = function (callback) {
        $http.get('/api/Inmates')
            .success(function (data) {
                callback(data);
            })
            .error(function () {
            });
    };

});
