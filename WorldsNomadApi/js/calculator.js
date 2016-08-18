
var app = angular.module("calculator", []);

app.controller("sequenceGenerator", function ($scope, $location, $http) {
    $scope.disable = false;
    $scope.number = '';
    $scope.sequenceType = null;
    $scope.isModelValid = function () {
        var input = $scope.number.trim();
        return input === '' || (!isNaN(input) && parseInt(input) && parseInt(input) > 0 && input % 1 === 0 && Number(input) && input < Number.MAX_SAFE_INTEGER);
    }

    $scope.responses = [];

    $scope.calculate = function () {
        if (!$scope.isModelValid() || $scope.number.trim()=== '')
            return;

        $scope.disable = true;

        $http({
            method: 'get',
            url: $scope.ajaxUrl()
        }).then(function (response) {
            $scope.responses = [];

            if (response && response.data) {
                if ($scope.isArray(response.data)) {
                    angular.forEach(response.data, function(value, index){
                        $scope.responses.push(value);
                    })
                } else {
                    $scope.responses.push(response.data);
                }
            }
        }).then(function () {
            $scope.disable = false;
        });


    };

    $scope.ajaxUrl = function () {
        var apiUrl = '/api/v1/sequence';

        if ($scope.sequenceType !== null && $scope.sequenceType !== '')
            apiUrl = apiUrl + '/' + $scope.sequenceType

        apiUrl = apiUrl + '/' + $scope.number.trim()

        return apiUrl;
    }

    $scope.isArray = function (a) {
        return (!!a) && (a.constructor === Array);
    }
});

