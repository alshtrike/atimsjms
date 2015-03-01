﻿ atimsMainApp.controller('calendarController', function ($scope, $compile, uiCalendarConfig, $http) {
    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth();
    var year = date.getFullYear();

     // event source that contains custom events on the scope
    $scope.events = [];
    var loadCalendar = function () {
        $http.get("api/Appointments/")
            .success(function (data) { setupCalendar(data) })
            .error(function (data) { failed(data) })
    };

    var failed = function (data) {
        console.log("Calendar http load failed: " + data);
    };

    var setupCalendar = function (data) {
        var calendarList = angular.fromJson(data);
       /* for (var i = 0; i < calendarList.length; i++) {
            var appointment = calendarList[i];

        }*/
    };

    
    // event source that calls a function on every view switch
    $scope.eventsF = function (start, end, timezone, callback) {
        var s = new Date(start).getTime() / 1000;
        var e = new Date(end).getTime() / 1000;
        var m = new Date(start).getMonth();
        var events = [{ title: 'Feed Me ' + month, start: s + (50000), end: s + (100000), allDay: false, className: ['customFeed'] }];
        callback(events);
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
    $scope.addEvent = function () {
        $scope.events.push({
           //custom event object here
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

    // event sources array//
    $scope.eventSources = [$scope.events, $scope.eventSource, $scope.eventsF];
    $scope.eventSources2 = [$scope.calEventsExt, $scope.eventsF, $scope.events];
});