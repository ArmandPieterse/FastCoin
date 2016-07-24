(function () {
    var app = angular.module("buydashboard");

    app.service("buyDashboardService", [
         "apiService",
         "buyDashboardModel",
         buyDashboardService
    ]);


    function buyDashboardService(apiService, buyDashboardModel) {
        var service = {};
        service.buyDashboardModel = buyDashboardModel;

        service.getAvaliableOffers = function (success, error) {
            apiService.getAvaliableOffers(function (result) {
                if (success) {
                    success(result);
                }
            }, error);
        }

        return service;
    }

})();
