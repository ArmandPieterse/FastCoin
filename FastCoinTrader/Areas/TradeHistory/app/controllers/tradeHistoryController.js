(function () {
    'use strict';

    var app = angular.module('tradehistory');

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