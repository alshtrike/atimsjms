atimsApp.controller('HousingController', function ($scope) {
    //tabs and subtabs array
    $scope.tabs = [
        {
            title: 'Closet',
            subTabs: []
        },
        {
            title: 'Supply',
            subTabs: [{ title: 'Item' }, { title: 'Check List' }, { title: 'History' }, { title: 'Manage' }]
        }
    ];
    //default page to load
    $scope.subPage = "Views/JMS/Property/Closet/index.cshtml";


    $scope.getSubSub = function (mod, subSub, subSubSub) {
        
        $scope.subPage = "Views/JMS/" + encodeURI(mod) + "/" + encodeURI(subSub) + "/" + encodeURI(subSubSub)+".cshtml";
    };
    $scope.getSub = function (mod, subSub) {
        
        $scope.subPage = "Views/JMS/" + encodeURI(mod) +  "/" + encodeURI(subSub) + "/" + "index.cshtml";
        
    };
    
    });