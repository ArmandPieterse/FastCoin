(function () {
    'use strict';

    var app = angular.module('buydashboard');

    app.controller('buyDashboardHomeController', [
        '$scope', buyService, buyDashboardHomeController
    ]);

    function buyDashboardHomeController(
        $scope) {

        //TODO: Link to production data
        ///Trade history table
        $scope.tradeHistory = [{ 'id': 1,'name': 'tommy', 'amount': 1.2 },
            { 'id': 2, 'name': 'jimmy', 'amount': 1.2 },
            { 'id': 3, 'name': 'jacky', 'amount': 1.2 }];


        //TODO: Link to production data
        ///Current Buy offers table
        $scope.currentSellOffers = [{ 'id': 1, 'name': 'tommy', 'amount': 1.2 },
            { 'id': 2, 'name': 'jimmy', 'amount': 1.2 },
            { 'id': 3, 'name': 'jacky', 'amount': 1.2 }];

        /**
         * Initializes controller-specific data 
         */
        function init() {
        }

        init();
    }
})();