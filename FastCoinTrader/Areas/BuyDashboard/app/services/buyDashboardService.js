(function () {
    var app = angular.module("buydashboard");

    app.service("buyDashboardService", [
         "apiService",
         "buyDashboardModel",
         "notificationService",
         buyDashboardService
    ]);


    function buyDashboardService(apiService, buyDashboardModel, notificationService) {
        var service = {};
        service.buyDashboardModel = buyDashboardModel;

        service.submitBuyBitCoin = function(request, success, error) {
            apiService.submitBuyBitCoin(request, function(result) {
                notificationService.addNotification("Helloo", true);

                if (success) {
                    success(result);
                }
            }, error);
        };

        service.getAvaliableOffers = function(success, error) {
            apiService.getAvaliableOffers(function(result) {
                if (success) {
                    success(result);
                }
            }, error);
        };

        return service;
    }

})();
