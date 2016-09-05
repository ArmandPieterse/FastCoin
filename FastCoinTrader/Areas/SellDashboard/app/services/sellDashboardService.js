(function () {
    var app = angular.module("selldashboard");

    app.service("sellDashboardService", [
         "apiService",
         "notificationService",
         sellDashboardService
    ]);


    function sellDashboardService(apiService, notificationService) {
        var service = {};

        service.submitSellBitCoin = function(request, success, error) {
            apiService.submitSellBitCoin(request, function (result) {
                notificationService.addNotification("Bit Coin successfully sold.", true);
                
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
