atimsApp.controller('IntakeController', function ($scope, $http) {

    $scope.prebookSection = "Views/JMS/Intake/PreBook1.cshtml";
    var currentPage = 1;

    $scope.addInmate = function () {

        $http.post('/api/Inmates/', this.newInmate).success(function (data) {
            alert("Added Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Inmate: " + data;
        });
    };


    $http.get('/api/Facilities/').success(function (data) {
        $scope.facilities = data;
        
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
    });
    $scope.changeFac = function (fac) {
        $scope.Facility = fac.FacilityName;
    };

    $scope.updateProgress = function (direction) {
        //85 is the width of each step
        
        if(direction === 'next'){
            //increase width
            currentPage++;
            if(($('.completion').width()/85)+1 == $('li').first().text()){ 
            }
            $('.completion').animate({'width':'+=85px'},1500);
        }else{
            //decrease width
            currentPage--;
            $('.completion').animate({'width':'-=85px'},1500);
        }
        $scope.prebookSection = "Views/JMS/Intake/PreBook"+currentPage+".cshtml";
    }
    $scope.jumpToSection = function (section) {
        currentPage = section;
        width = 85 * section;
        $('.completion').animate({ 'width': width + 'px' }, 1500);
        $scope.prebookSection = "Views/JMS/Intake/PreBook" + currentPage + ".cshtml";
    }
  }
);