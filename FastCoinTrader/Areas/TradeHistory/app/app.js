(function () {
    "use strict";
    angular.module("tradeHistory", ["ngRoute", "ngSanitize", "ngiUI", "ui.bootstrap", "smart-table"])

    .config(function ($routeProvider) {
        $routeProvider.when("/home",
            {
                çontroller: "tradeHistoryController",
                templateUrl: "/Areas/BuyDashboard/app/templates/tradeHistoryView.html"
            }).otherwise({ redirectTo: "/home" });
    });
})();