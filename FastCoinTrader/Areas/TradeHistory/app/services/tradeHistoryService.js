(function () {
    var app = angular.module("tradehistory");

    app.service("tradeHistoryService", [
         "apiService",
         "notificationService",
         tradeHistoryService
    ]);


    function tradeHistoryService(apiService, notificationService) {
        var service = {};

        service.getUserSaleHistory = function (request, success, error) {
            apiService.getUserSaleHistory(request, function (result) {
                notificationService.addNotification("User History Successfully Loaded", false);

                if (success) {
                    success(result);
                }
            }, error);
        };


        return service;
    }

})();
