(function () {
    'use strict';

    var app = angular.module('buydashboard');

    app.controller('buyDashboardHomeController', [
        '$scope',
        '$routeParams',
        buyDashboardHomeController
    ]);

    function buyDashboardHomeController(
        $scope,
        $routeParams
        ) {

        $scope.helloText = "Buy Dashboard";

        function init() {
            alert("Invoked");
        }

        init();
    }
})();