atimsApp.controller('HousingController', function ($scope) {
    $scope.tabs = [
        {
            title: 'Closet',
            subTabs: []
        },
        {
            title: 'Supply',
            subTabs: [{ title: 'Item' }, { title: 'Check List' }, { title: 'History' }, {title:'Manage'}]
        }


    ]
});