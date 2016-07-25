(function () {
    'use strict';

    var app = angular.module('buydashboard');

    app.controller('buyDashboardHomeController', [
        '$scope',
        'buyDashboardService',
        'notificationService',
        buyDashboardHomeController
    ]);

    function buyDashboardHomeController(
        $scope,
        buyDashboardService,
        notificationService) {

        $scope.buyOffer = {
            amount: null,
            pricePerBTC: null,
            fee: null,
            feePercentage: null,
            total: null,

            init: function() {
                this.feePercentage = 0.005;
            },

            configureTotal: function() {
                this.total = this.amount * this.pricePerBTC;
                this.configureFee();
            },

            configurePrice: function() {
                this.price = this.total / this.amount;
            },

            configureAmount: function() {
                this.amount = this.total / this.pricePerBTC;
            },

            configureFee: function() {
                this.fee = this.total * this.feePercentage;
            },

            detailsIncomplete: function() {
                var incomplete = false;

                if (this.total === undefined || this.total === null || this.total === 0)
                    incomplete = true;

                return incomplete;
            }
        }

        $scope.amountChanged = function() {
            $scope.buyOffer.configureTotal();
        }

        $scope.priceChanged = function () {
            $scope.buyOffer.configureTotal();
        }

        $scope.totalChanged = function () {
            if ($scope.buyOffer.total > 0) {
                $scope.buyOffer.configureAmount();
                $scope.buyOffer.configureFee();
            }
        }

        $scope.submitBuyBitCoin = function () {
            var request = {
                price: $scope.buyOffer.pricePerBTC,
                amount: $scope.buyOffer.amount,
                total: $scope.buyOffer.total,
                fee: $scope.buyOffer.fee
            };
            buyDashboardService.submitBuyBitCoin(request, buyBitCoinSuccess, buyBitCoinError);
        }

        //TODO: Link to production data
        ///Trade history table
        $scope.sellOffers = [{ 'total': 1, 'pricePerBTC': 5, 'btc': 1.2 },
            { 'total': 2, 'pricePerBTC': 5, 'btc': 1.2 },
            { 'total': 3, 'pricePerBTC': 5, 'btc': 1.2 }];

        /**
         * Initializes controller-specific data 
         */
        function getAvailableOffersSuccess() {
            
        }

        function buyBitCoinSuccess() {
            
        }

        function buyBitCoinError() {

        }

        function getAvailableOffersError() {

        }

        function init() {
            notificationService.addNotification("Helloo", true);
            $scope.buyOffer.init();
            //buyDashboardService.getAvaliableOffers(getAvailableOffersSuccess, getAvailableOffersError);
        }

        init();
    }
})();