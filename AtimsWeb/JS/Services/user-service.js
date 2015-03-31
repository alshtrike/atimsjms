//// Atims User

/// Atims User's Service
// This service holds all cached information for the currently loaded user
//   This does NOT include logging in the user, or things like cookies and
//   stored security tokens. Login is handled by the atims-app.js file, which
//   calls this Service *after* a successful login to load the user.
// @TODO: Load from API
atimsApp.service('UserService', function ($http) {
    //// Variables

    /// User Information
    // Stores basic data about the user used to retrieve further information
    //   from the API and to make requests. Since this information *could*
    //   be changed, the HTTP Get requests will still pass along session
    //   credentials and therefore this information can not be used as
    //   absolute truth. However, unless someone is maliciously trying to
    //   access things they shouldn't, any discrepencies in this information
    //   should be treated as a bug and fixed.
    // By default, all Id's are set to -1 to indicate a user is not logged in
    //   However, until user login is implemented, -1 will store a set of
    //   debug values to pretend a user is logged in.
    // @TODO: Load from API
    this.user = {
        // PersonnelId of the currently selected user
        PeronelId: -1,
        // PersonId of the currently selected user
        PersonId: -1,

        // HomePage of the currently selected user
        HomePage: "Records/Active"
    }
    
    /// Alerts List
    // Alerts appear at the top right of the web page and are stored in
    //   an array based on the type. The default -1 user has access to
    //   Messages, Notifications, and Tasks. The alerts an actual user
    //   has access to will be loaded from a ViewModel from the database.
    // This array contains the type of alert (display name), a link to
    //   the page each alert type can be viewed at, the number of alerts
    //   of that type the user has, as well as a short list including the
    //   *most recent* alerts of that type.
    // @TODO: Load from API instead of using a default template
    this.alerts = [
        {   Type: "Messages",
            Link: "",
            Number: 0,
            SubList: {}
        },
        {   Type: "Notifications",
            Link: "",
            Number: 0,
            SubList: {}
        },
        {   Type: "Tasks",
            Link: "",
            Number: 0,
            SubList: {}
        }
    ];


    //// User Loading Functions
    // @TODO: Load from API
    this.loadUser = function () {

    }

});