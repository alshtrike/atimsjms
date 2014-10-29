
var glassHouseNavController = function ($scope) {
    // Default Variables
    this.mainSection = "";
    this.subSection = "";

    // Navigation Control
    this.goToMainNav = function( sectionName ){
        // TODO: Main Section Auth
    };
    this.goToUserNav = function (sectionName) {
        // TODO: User Section Auth
    };
    this.goToSubNav = function( sectionName ){
        // TODO: Sub Section Auth
    };



    /** Nav Icon Constructors **/

    // Because NullPointerExceptions are a pain
    // We should handle it immediately, not check if the function is null elsewhere
    this.noAction = function( ){ };

    this.cssStringFormat = function( input, name ){
        return input.replace( "%NAME", name ).replace( " ", "-" ).toLowerCase( );
    };

    this.newIconState = function( stateName, displayName, cssClass, clickAction, hoverOverAction, hoverOutAction ){
        return {
            name: stateName,
            display: displayName,
            css: cssClass,
            onClick: clickAction ? clickAction : this.noAction,
            hoverOver: hoverOverAction ? hoverOverAction : this.noAction,
            hoverOut: hoverOutAction ? hoverOverAction : this.noAction
        };
    };

    this.newIconStateTemplate = function( stateName, displayNamePrefix, cssClassTemplate,
            clickFunction, hoverOverFunction, hoverOutFunction ){
        return {
            name: stateName,
            display: displayNamePrefix,
            cssClass: cssClassTemplate,
            onClick: clickFunction,
            onHoverOver: hoverOverFunction,
            onHoverOut: hoverOutFunction
        };
    };

    this.newIcon = function( iconName, defaultState, states, raw ){
        stateTable = {};
        for( var i = 0; i < states.length; i++ ){
            stateTable[states[i].name] = states[i];
        };
        return {
            name: iconName,
            state: stateTable[defaultState],
            states: stateTable,
            raw: raw
        };
    };

    this.newIconSet = function( iconNames, stateTemplates ){
        var iconSet = [];
        var tempStates;

        // Build Each Icon
        for( var i = 0; i < iconNames.length; i++ ){
            tempStates = [];
            // Build Each State
            for( var j = 0; j < stateTemplates.length; j++ ){
                tempStates[j] = this.newIconState(
                    // State Name
                    stateTemplates[j].name,
                    // Display Name
                    stateTemplates[j].display + iconNames[i],
                    // Css Name
                    this.cssStringFormat( stateTemplates[j].cssClass, iconNames[i] ),
                    // On Click Function
                    stateTemplates[j].onClick,
                    // Hover Over Function
                    stateTemplates[j].onHoverOver,
                    // Hover Out Function
                    stateTemplates[j].onHoverOut 
                );
            };
            iconSet[i] = this.newIcon( iconNames[i], tempStates[0].name, tempStates );
        };
        return iconSet;
    };



    /**** Main Navigation Menu ****/
    this.mainNav = {};
    this.mainNav.iconNames = [
        'Intake', 'Booking', 'Classify', 'Records',
        'Property', 'Facility', 'Monitor', 'Programs',
        'Alt Sent', 'Money', 'Medical'
    ];
    this.mainNav.clickIcon = function( iconName ){
        goToMainNav( iconName );
    };
    this.mainNav.stateTemplates = [
        this.newIconStateTemplate( "default", "", "glass-nav-%NAME", this.mainNav.clickIcon ),
        this.newIconStateTemplate( "selected", "", "glass-nav-icon-selected glass-nav-%NAME", this.mainNav.clickIcon )
    ];
    this.mainNav.iconSet = this.newIconSet( this.mainNav.iconNames, this.mainNav.stateTemplates );



    /**** User Navigation Menu ****/
    this.userNav = {};
    this.userNav.iconNames = [
        'User Info', 'Minimize Maximize', 'Settings', 'Clock In Out',
        'Inbox', 'Requests', 'Workload'
    ];
    this.userNav.clickIcon = function( iconName ){
        goToUserNav( iconName );
    };
    this.userNav.stateTemplates = [
        this.newIconStateTemplate("default", "", "glass-usernav-%NAME", this.userNav.clickIcon),
        this.newIconStateTemplate("selected", "", "glass-usernav-icon-selected glass-usernav-%NAME", this.userNav.clickIcon)
    ];
    this.userNav.iconSet = this.newIconSet( this.userNav.iconNames, this.userNav.stateTemplates );


    /**** Sub Navigation Menu's ****/
    this.subnav = {};

    /** Subnav Intake Menu **/
    this.subnav['intake'] = {};
    this.subnav['intake'].iconNames = [
        'PreBook', 'Intake', 'TempHold', 'Inventory',
        'Supply', 'File', 'Reports'
    ];
    this.subnav['intake'].clickIcon = function( iconName ){
        goToSubNav( iconName );
    };
    this.subnav['intake'].stateTemplates = [
        this.newIconStateTemplate( "default", "", "glass-subnav-intake-%NAME", this.subnav['intake'].clickIcon ),
        this.newIconStateTemplate( "selected", "", "glass-subnav-icon-selected glass-subnav-intake-%NAME", this.subnav['intake'].clickIcon )
    ];
    this.subnav['intake'].iconSet = this.newIconSet( this.subnav['intake'].iconNames, this.subnav['intake'].stateTemplates );

};
glassHouseNavController.$inject = ['$scope'];

glassHouseApp.controller( "GlassHouseNavController", glassHouseNavController );

