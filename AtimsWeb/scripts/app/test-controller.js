atimsMainApp.controller('testController',  function ($scope,$http){

   /* $scope.myData = [
      {
          "firstName": "Cox",
          "lastName": "Carney",
          "company": "Enormo",
          "employed": true
      },
      {
          "firstName": "Lorraine",
          "lastName": "Wise",
          "company": "Comveyer",
          "employed": false
      },
      {
          "firstName": "Nancy",
          "lastName": "Waters",
          "company": "Fuelton",
          "employed": false
      }
    ];*/
    $http.get('/api/inmate/50').success(function (data) {
        $scope.myData = data;

    })
    .error(function () {
        $scope.error="failed to load inmates"
    });
   
});