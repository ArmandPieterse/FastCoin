(function () {
    var app = angular.module("buydashboard");

    app.service("buyDashboardService", [
         "apiService",
         "buyDashboardModel",
         "notificationService",
         "$timeout",
         buyDashboardService
    ]);


    function buyDashboardService(apiService, buyDashboardModel, notificationService, $timeout) {
        var service = {};
        var getAvailableOffersCall = false;
        service.buyDashboardModel = buyDashboardModel;

        service.submitBuyBitCoin = function (request, success, error) {
            apiService.submitBuyBitCoin(request, function (result) {
                notificationService.addNotification("Bit Coin successfully purchased.", true);

                if (success) {
                    success(result);
                }
            }, error);
        };

        service.getAvaliableOffers = function (success, error) {
            if (!getAvailableOffersCall) {
                getAvailableOffersCall = true;
                apiService.getAvaliableOffers(function (result) {
                    console.log("Offers received");

                    getAvailableOffersCall = false;

                    if (success) {
                        success(result);
                    }
                }, function(error) {
                    getAvailableOffersCall = false;
                });

            }

            $timeout(function() {
                service.getAvaliableOffers(success, error);
            }, 5000);
        };

        var getTradableStockPoll = function () {

            if (!getAvailableOffersCall) {
                getAvailableOffersCall = true;
                apiService.getTradableStock({},
                    function (result, warnings) {
                        marketFloorModel.setTradableStock(result);
                        marketFloorModel.logInformation("Retrieved Tradable stock");

                        $rootScope.$broadcast('tradableStockLoaded');

                        getAvailableOffersCall = false;

                        console.log(service.marketFloorModel.tradableStock);

                    },
                    function (error) {

                        getAvailableOffersCall = false;
                    });
            }

            $timeout(getTradableStockPoll, 20000);
        }

        return service;
    }

})();
