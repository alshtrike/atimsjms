
var glassHouseNavController = function( $scope ){
    this.init = function( ){
        // Default Variables
        this.mainSection = "";
        this.subSection = "";
        this.currentSubNav = this.subNav['Intake'];
    };



    /**** Navigation Control ****/
    this.selectUserNav = function( event, sectionName ){
        // TODO: User Section Auth
        // TODO: Switch To Selected Section
    };
    this.selectMainNav = function( event, sectionName ){
        // TODO: Main Section Auth
        // TODO: Switch To Selected Section
        $scope.glassHouseNavCtrl.currentSubNav = $scope.glassHouseNavCtrl.subNavSet[sectionName];
    };
    this.selectSubNav = function( event, sectionName ){
        // TODO: Sub Section Auth
        // TODO: Switch To Selected Section
    };
    $scope.$on( 'selectUserNav', this.selectUserNav );
    $scope.$on( 'selectMainNav', this.selectMainNav );
    $scope.$on( 'selectSubNav', this.selectSubNav );



    /**** Nav Icon Constructors ****/

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



    /**** User Navigation Menu ****/
    this.userNav = {};
    this.userNav.iconNames = [
        'User Info', 'Minimize Maximize', 'Settings', 'Clock In Out',
        'Inbox', 'Requests', 'Workload'
    ];
    this.userNav.clickIcon = function( iconName ) {
        $scope.$emit( 'selectUserNav', iconName );
    };
    this.userNav.stateTemplates = [
        this.newIconStateTemplate("default", "", "glass-usernav-%NAME", this.userNav.clickIcon),
        this.newIconStateTemplate("selected", "", "glass-usernav-icon-selected glass-usernav-%NAME", this.userNav.clickIcon)
    ];
    this.userNav.iconSet = this.newIconSet(this.userNav.iconNames, this.userNav.stateTemplates);



    /**** Main Navigation Menu ****/
    this.mainNav = {};
    this.mainNav.iconNames = [
        'Intake', 'Booking', 'Classify', 'Records',
        'Property', 'Facility', 'Monitor', 'Programs',
        'Alt Sent', 'Money', 'Medical'
    ];
    this.mainNav.clickIcon = function( iconName ){
        $scope.$emit( 'selectMainNav', iconName );
    };
    this.mainNav.stateTemplates = [
        this.newIconStateTemplate( "default", "", "glass-nav-%NAME", this.mainNav.clickIcon ),
        this.newIconStateTemplate( "selected", "", "glass-nav-icon-selected glass-nav-%NAME", this.mainNav.clickIcon )
    ];
    this.mainNav.iconSet = this.newIconSet( this.mainNav.iconNames, this.mainNav.stateTemplates );



    /**** Sub Navigation Menu's ****/

    this.buildSubNavMenu = function (subNavSet, subNavName, iconNames) {
        /** Subnav Booking Menu **/
        subNavSet[subNavName] = {};
        subNavSet[subNavName].iconNames = iconNames;
        subNavSet[subNavName].clickIcon = function (iconName) {
            $scope.$emit('selectSubNav', iconName);
        };
        subNavSet[subNavName].stateTemplates = [
            this.newIconStateTemplate("default", "", this.cssStringFormat("glass-subnav-%NAME", subNavName) + "-%NAME", subNavSet[subNavName].clickIcon),
            this.newIconStateTemplate("selected", "", this.cssStringFormat("glass-subnav-icon-selected glass-subnav-%NAME", subNavName) + "-%NAME", subNavSet[subNavName].clickIcon)
        ];
        subNavSet[subNavName].iconSet = this.newIconSet(subNavSet[subNavName].iconNames, subNavSet[subNavName].stateTemplates);
    }

    this.subNav = {};

    this.buildSubNavMenu( subNav, 'Intake', [
        'PreBook', 'Intake', 'Temp Hold', 'Inventory',
        'Supply', 'File', 'Reports'
    ]);

    this.buildSubNavMenu( subNav, 'Booking', [
        'Booking', 'Release', 'Supervisor', 'Active',
        'Search', 'Housing', 'Appt', 'Attach',
        'File', 'Reports'
    ]);

    this.buildSubNavMenu( subNav, 'Classify', [
        'Class File', 'Queue', 'Viewer', 'Housing',
        'Transfer', 'Attach', 'Incident', 'Grievance',
        'Alerts', 'Search', 'File', 'Reports'
    ]);

    // TODO: Finish Menus
    // TODO: Move to Model Class

};
glassHouseNavController.$inject = ['$scope'];

glassHouseApp.controller( "GlassHouseNavController", glassHouseNavController );

