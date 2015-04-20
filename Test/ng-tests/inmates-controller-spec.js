/// <reference path="../../atimsweb/js/atims-app.js" />
'use strict';
describe('Controller: InmatesController', function() {
    var ctrl, scope, InmatesService;
    
    beforeEach(function() {
        var mockInmatesService = {};

        module('atimsApp', function($provide) {
            $provide.value('InmatesService', mockInmatesService);
        });

        inject(function($q) {
            mockInmatesService.data = [
              {
                  id: 0,
                  number: 12345,
                  firstName: 'Fred',
                  middleName: 'Flint',
                  lastName: 'Stone',
                  age: 100,
                  dob: null,
                  facilityName: null,
                  recieved: null,
                  release: null,
                  status: 1
              },
              {
                  id: 1,
                  number: 23456,
                  firstName: 'Barney',
                  middleName: 'Freakin',
                  lastName: 'Rubble',
                  age: 100,
                  dob: null,
                  facilityName: null,
                  recieved: null,
                  release: null,
                  status: 1
              },
              {
                  id: 2,
                  number: 34567,
                  firstName: 'Al',
                  middleName: 'SweetiePie',
                  lastName: 'Capone',
                  age: 75,
                  dob: null,
                  facilityName: null,
                  recieved: null,
                  release: null,
                  status: 1
              },
              {
                  id: 3,
                  number: 45678,
                  firstName: 'The',
                  middleName: 'Dude',
                  lastName: 'Lebowski',
                  age: 50,
                  dob: null,
                  facilityName: null,
                  recieved: null,
                  release: null,
                  status: 1
              }
            ];

            mockInmatesService.getActiveInmates = function() {
                var defer = $q.defer();

                defer.resolve(this.data);

                return defer.promise;
            };
        });
    });

    beforeEach(inject(function ($controller, $rootScope, _InmatesService_) {
        scope = $rootScope.$new();
        InmatesService = _InmatesService_;

        ctrl = $controller('InmatesController',
                { $scope: scope, InmatesService: InmatesService });
        //scope.gridOptions.data = InmatesService.data;
        ctrl.loadInmates(InmatesService.data);
        scope.$digest();
    }));

    it('should have scope.gridOptions to be defined', function () {
        console.log(scope.gridOptions);
        expect(scope.gridOptions).toBeDefined();
    });

    it('should have inmate values loaded at startup', function () {
        var data = InmatesService.data;
        console.log(data);
        expect(scope.gridOptions.data[0].firstName).toEqual('Fred');
        expect(scope.gridOptions.data[2].number).toEqual(34567);
    });
})
