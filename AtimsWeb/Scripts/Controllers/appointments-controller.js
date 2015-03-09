<<<<<<< HEAD:AtimsWeb/scripts/app/calendar-controller.js
﻿ atimsMainApp.controller('calendarController', function ($scope,$log, $compile, $modal, uiCalendarConfig, $http) {
=======
﻿/// Appointments Appointments Controller
 atimsApp.controller('AppointmentsController', function ($scope, $compile, $http, uiCalendarConfig) {
    // Current Date
>>>>>>> 9b5787ec2e8672f96e85df2a627d9da9f2fccc90:AtimsWeb/Scripts/Controllers/appointments-controller.js
    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth();
    var year = date.getFullYear();

<<<<<<< HEAD:AtimsWeb/scripts/app/calendar-controller.js
     // event source that contains custom events on the scope
    $scope.events = [];

    $scope.openModal = function () {

        var modalInstance = $modal.open({
            templateUrl: '~/Views/Records/NewEvent.html',
            controller: 'newEventModalController'
        });

        modalInstance.result.then(function (modalEvent) {
            addEvent(modalEvent);
        }, function () {
            $log.info('Modal dismissed');
        });

    };
    var loadCalendar = function () {
        //we can add an int to pass to determine what day/week/month to get events for
        $http.get("api/Appointments/0")
            .success(function (data) {  setupCalendar(data) })
=======
    // Event source that contains custom events on the scope
    $scope.events = [{ title: 'test', start: new Date(2015, 2, 20, 9, 20, 0, 0) }];

    // Loads ALL appointments from the database for the calendar
    var loadCalendar = function () {
        $http.get("api/Appointments")
            .success(function (data) { setupCalendar(data) })
>>>>>>> 9b5787ec2e8672f96e85df2a627d9da9f2fccc90:AtimsWeb/Scripts/Controllers/appointments-controller.js
            .error(function (data) { failed(data) })
    };

     //called on error http get
    var failed = function (data) {
        $scope.calendarData = "Failed to load";
        console.log("Calendar http load failed: " + data);
    };

     //called on successful http get
    var setupCalendar = function (data) {
        var calendarData = angular.fromJson(data);
        $scope.debugCalendar = calendarData;

        for (var i = 0; i < calendarData.length; i++) {
            var Appointment = calendarData[i];
            /*more information is really needed about how the dates are 
                set up in the db before the end can really be determined
                for now they are just set up to be an hour long*/
            /*more parameters can be set here as well for events*/
            $scope.events.push({
<<<<<<< HEAD:AtimsWeb/scripts/app/calendar-controller.js
                title: Appointment.appointment_reason,
                start: Appointment.appointment_date,
                end: Appointment.appointment_end
=======
                title: Appointment.Reason,
                start: Appointment.Date
>>>>>>> 9b5787ec2e8672f96e85df2a627d9da9f2fccc90:AtimsWeb/Scripts/Controllers/appointments-controller.js
            });

        }
    };

    
    // alert on eventClick 
    $scope.alertOnEventClick = function (date, jsEvent, view) {
        $scope.alertMessage = (date.title + ' was clicked ');
    };
    // alert on Drop 
    $scope.alertOnDrop = function (event, delta, revertFunc, jsEvent, ui, view) {
        $scope.alertMessage = ('Event Dropped');
    };
    // alert on Resize
    $scope.alertOnResize = function (event, delta, revertFunc, jsEvent, ui, view) {
        $scope.alertMessage = ('Event Resized');
    };
    // add and removes an event source of choice 
    $scope.addRemoveEventSource = function (sources, source) {
        var canAdd = 0;
        angular.forEach(sources, function (value, key) {
            if (sources[key] === source) {
                sources.splice(key, 1);
                canAdd = 1;
            }
        });
        if (canAdd === 0) {
            sources.push(source);
        }
    };
    // add custom event
    $scope.addEvent = function (modalEvent) {
        $scope.newEvent = modalEvent;
        $scope.events.push(newEvent);
        $http.post('api/Appointments', newEvent)
        .success(function (data) {
            console.log('put success: ' + data);
        })
        .error(function (data) {
            console.log('put error: ' + data);
        });
    };
    // remove event 
    $scope.remove = function (index) {
        $scope.events.splice(index, 1);
    };
    // Change View 
    $scope.changeView = function (view, calendar) {
        uiCalendarConfig.calendars[calendar].fullCalendar('changeView', view);
    };
    // Change View 
    $scope.renderCalender = function (calendar) {
        if (uiCalendarConfig.calendars[calendar]) {
            uiCalendarConfig.calendars[calendar].fullCalendar('render');
        }
    };
    // Render Tooltip 
    $scope.eventRender = function (event, element, view) {
        element.attr({
            'tooltip': event.title,
            'tooltip-append-to-body': true
        });
        $compile(element)($scope);
    };
    // config object 
    $scope.uiConfig = {
        calendar: {
            height: 450,
            editable: true,
            header: {
                left: 'title',
                center: '',
                right: 'today prev,next'
            },
            eventClick: $scope.alertOnEventClick,
            eventDrop: $scope.alertOnDrop,
            eventResize: $scope.alertOnResize,
            eventRender: $scope.eventRender
        }
    };

     // event sources array
    $scope.eventSources = [$scope.events];
    loadCalendar();
    });

//modal Controller
 atimsMainApp.controller('newEventModalController', function ($scope, $modalInstance) {
     $scope.modalEvent;
        $scope.ok = function () {
            $modalInstance.close($scope.modalEvent);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });
