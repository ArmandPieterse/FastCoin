(function () {
    'use strict';

    var app = angular.module('buydashboard');

    app.controller('tradeHistoryController', [
        '$scope',
        'tradeHistoryService',
        'notificationService',
        tradeHistoryController
    ]);

    function tradeHistoryController(
        $scope,
        tradeHistoryService,
        notificationService) {



        function init() {
                
        }

        init();
    }
})();