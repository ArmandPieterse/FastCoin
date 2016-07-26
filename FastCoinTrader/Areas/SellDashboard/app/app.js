(function () {
    "use strict";
    angular.module("selldashboard", ["ngRoute", "ngSanitize", "ngiUI", "ui.bootstrap", "smart-table"])

    .config(function ($routeProvider) {
        $routeProvider.when("/home",
            {
                çontroller: "sellDashboardHomeController",
                templateUrl: "/Areas/SellDashboard/app/templates/sellDashboardHomeView.html"
            }).otherwise({ redirectTo: "/home" });
    });
})();