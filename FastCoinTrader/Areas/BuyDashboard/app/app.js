(function () {
    "use strict";
    var app = angular.module("buydashboard", ["ngRoute", "ngSanitize"]);
    
    // Directives
    //app.directive('countries', countriesDropdownDirective);
    //app.directive('provinces', provincesDropdownDirective);

    // Factories
    //app.factory("buyDashboardModel", buyDashboardModel);

    //// Services
    //app.service("apiService", apiService);
    //app.service("navigationService", navigationService);
    //app.service("buyDashboardService", buyDashboardService);

    app.config(function ($routeProvider) {
        $routeProvider.when("/home",
            {
                çontroller: "buyDashboardHomeController",
                templateUrl: "/Areas/BuyDashboard/app/templates/buyDashboardHomeView.html"
            }).otherwise({ redirectTo: "/home" });
    });
})();