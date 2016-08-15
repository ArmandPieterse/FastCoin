/// <reference path="C:\Users\Arno\Documents\Visual Studio 2015\Projects\Personal\FastCoinTest\FastCoinTrader\Views/Home/Index.cshtml" />
/// <reference path="C:\Users\Arno\Documents\Visual Studio 2015\Projects\Personal\FastCoinTest\FastCoinTrader\Views/Home/Index.cshtml" />
(function () {
    "use strict";
    angular.module("root", ["ngRoute", "ngSanitize", "ngiUI", "ui.bootstrap", "smart-table", "buydashboard", "selldashboard", "tradeHistory"])

    .controller("myApp",[function() {
            go = function() {
                alert("Success");
            }

            go();
        }])

    .config(function ($routeProvider) {
        $routeProvider
            .when("/home",
                {  
                    templateUrl: "/Views/Home/Index"
                })
                .when("/test",
                {
                    templateUrl: "/Areas/BuyDashboard/app/templates/myTest.html"
                })
            .when("/buy",
                {
                    templateUrl: "/Areas/BuyDashboard/app/templates/buyDashBoardHomeView.html"
                })
            .when("/sell",
                {
                    templateUrl: "/Areas/SellDashboard/app/templates/sellDashBoardHomeView.html"
                })
            .when("trade",
                {
                    templateUrl: "/Areas/SellDashboard/app/templates/sellDashBoardHomeView.html"
                });

            //.otherwise({ redirectTo: "/home" });
        });
})();