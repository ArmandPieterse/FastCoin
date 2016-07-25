(function () {

    var app = angular.module('buydashboard');

    app.service('apiService', [
    '$http', apiService]);

    function apiService($http) {
        var service = {};

        //URLs
        service.getAvaliableOffersUrl = '/api/BuyDashboardApi/GetAvaliableOffers';
        service.submitBuyBitCoinUrl = '/api/BuyDashboardApi/BuyBitCoin';
        
        service.methods = {
            post: 'POST',
            get: 'GET'
        };

        var processException = function (ex, error) {
            if (error) {
                error([{ code: 'EXCEPTION', description: ex }]);
            }
        };

        var processResult = function (result, success, error) {
            if (!result) {
                processException('Invalid result returned from server', error);
                return;
            }

            // Add any warnings to model
            //if (result.warnings && result.warnings.length > 0) {
            //    _.each(result.warnings, function (warning) {
            //        notificationService.addWarning(warning);
            //    });
            //}

            // Add any errors to model
            //if (result.errors && result.errors.length > 0) {
            //    _.each(result.errors, function (errorItem) {
            //        notificationService.addError(errorItem);
            //    });
            //}

            //if (error && !result.isSuccess) {
            //    error(result.errors, result.warnings);
            //    return;
            //}

            //if (success) {
            //    success(result.data, result.warnings);
            //}
        };

        var post = function (data, url, success, error) {
            $http({
                method: service.methods.post,
                url: url,
                data: data
            }).success(function (result) {
                    processResult(result, success, error);
                }).error(function (ex) {
                    processException(ex, error);
                });
        };

        var get = function (url, success, error) {
            $http({
                method: service.methods.get,
                url: url
            })
                .success(function (result) {
                    processResult(result, success, error);
                })
                .error(function (ex) {
                    processException(ex, error);
                });
        };

        service.submitBuyBitCoin = function (request, success, error) {
            var url = service.submitBuyBitCoinUrl;
            var data = {
                price: request.price,
                amount: request.amount,
                total: request.total,
                fee: request.fee
            }
            post(data, url, success, error);
        };

        service.getAvaliableOffers = function (success, error) {
            var url = service.getAvaliableOffersUrl;

            get(url, success, error);
        };

        return service;
    }
})();