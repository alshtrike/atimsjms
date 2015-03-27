

    /// Appointments Appointments Controller
atimsApp.controller('calendarController', function ($scope, $modal, $compile, $http, uiCalendarConfig) {
    // Current Date

    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth();
    var year = date.getFullYear();

    // event source that contains custom events on the scope
    $scope.events = [];

    $scope.openModal = function () {

        var modalInstance = $modal.open({
            templateUrl: '/Views/JMS/Records/NewEvent.html',
            controller: 'newEventModalController'
        });

        modalInstance.result.then(function (modalEvent) {
            $scope.addEvent(modalEvent);
        }, function () {
            $log.info('Modal dismissed');
        });


    };

    // Event source that contains custom events on the scope
    $scope.events = [];




            // Loads ALL appointments from the database for the calendar
            var loadCalendar = function () {
                $http.get("api/Appointments")
                    .success(function (data) { setupCalendar(data) })
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
                        title: Appointment.Reason,
                        start: Appointment.Date
                    });

                }
                
            };

    
         

            // add custom event
            $scope.addEvent = function (modalEvent) {
                    $scope.events.push({
                        title: modalEvent.title,
                        start: modalEvent.start
                    });
                    $scope.debugCalendar.push({
                        title: modalEvent.title,
                        start: modalEvent.start
                    });
                    $scope.postEvent(modalEvent);
                             
            };

        // add custom events all at once
           /* $scope.addEvents = function (modalEvents) {
                for (var i = 0; i < modalEvents.length; i++) {
                    var Appointment = modalEvents[i];
                    $scope.events.push({
                        title: Appointment.title,
                        start: Appointment.startDate
                    });
                    $scope.debugCalendar.push({
                        title: Appointment.title,
                        start: Appointment.startDate
                    });
                    $scope.postEvent(Appointment);
                }

            };*/

            $scope.postEvent = function (data) {
                var appointmentVM = {
                    reason: data.title,
                    notes: data.reason,
                    time: data.start,
                    duration: data.duration
                };
                console.log("post data: ");
                console.log(data);
                console.log(JSON.stringify(data.start));
                console.log(appointmentVM);
                console.log(JSON.stringify(appointmentVM));
                $http.post(
                        '/api/Appointments/',
                        JSON.stringify(appointmentVM)
                        );
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
        atimsApp.controller('newEventModalController', function ($scope, $modalInstance) {
            $scope.today = function () {
                //$scope.dt = new Date();
                $scope.start = new Date();
                $scope.end = new Date();
            };
            $scope.today();
            $scope.changeStart = function () {
                if ($scope.start.getTime() > $scope.end.getTime()) {
                    $scope.end.setTime($scope.start.getTime());
                }
            };

            $scope.add = function (Event) {
                console.log("start: "+$scope.start);
                console.log("end: "+$scope.end);
                //console.log("dt: " + $scope.dt);
                console.log("title: " + $scope.title);
                console.log("reason: " + $scope.reason);
                /*var startDate = new Date();
                startDate.setDate($scope.start.getDate());
                startDate.setMonth($scope.dt.getMonth());
                startDate.setYear($scope.dt.getYear());
                startDate.setHours($scope.start.getHours());
                startDate.setMinutes($scope.start.getMinutes());*/
                eventDate = $scope.start.toISOString().slice(0, 19); 
                var duration = ($scope.end.getHours() * 60 + $scope.end.getMinutes())
                    - ($scope.start.getHours() * 60 + $scope.start.getMinutes());
                console.log("start: "+eventDate);
                console.log("duration: "+duration);
                $scope.modalEvent={ title: $scope.title, reason: $scope.reason, start: eventDate, duration: duration };
            };

            $scope.ok = function (Event) {
                $scope.add(Event);
                $modalInstance.close($scope.modalEvent);
            };

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        });

