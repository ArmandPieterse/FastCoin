(function () {
    "use strict";
    angular.module("buydashboard", ["ngRoute", "ngSanitize", "ngiUI", "ui.bootstrap", "smart-table"])
    
    // Directives
    //app.directive('countries', countriesDropdownDirective);
    //app.directive('provinces', provincesDropdownDirective);

    // Factories
    //app.factory("buyDashboardModel", buyDashboardModel);

    //// Services
    //app.service("apiService", apiService);
    //app.service("navigationService", navigationService);
    //app.service("buyDashboardService", buyDashboardService);

    .config(function ($routeProvider) {
        $routeProvider.when("/home",
            {
                çontroller: "buyDashboardHomeController",
                templateUrl: "/Areas/BuyDashboard/app/templates/buyDashboardHomeView.html"
            }).otherwise({ redirectTo: "/home" });
    });
})();