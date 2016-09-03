(function () {
    'use strict';

    var app = angular.module('selldashboard');

    app.controller('sellDashboardHomeController', [
        '$scope',
        'notificationService',
        'sellDashboardService',
        sellDashboardHomeController
    ]);

    function sellDashboardHomeController(
        $scope,
        notificationService,
        sellDashboardService) {

        $scope.sellOffer = {
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
            $scope.sellOffer.configureTotal();
        }

        $scope.priceChanged = function () {
            $scope.sellOffer.configureTotal();
        }

        $scope.totalChanged = function () {
            if ($scope.sellOffer.total > 0) {
                $scope.sellOffer.configureAmount();
                $scope.sellOffer.configureFee();
            }
        }

        $scope.populateOffer = function (offer) {
            $scope.sellOffer.total = offer.total;
            $scope.sellOffer.pricePerBTC = offer.pricePerBTC;
            $scope.sellOffer.configureFee();
            $scope.sellOffer.configureAmount();
        }

        $scope.submitSellBitCoin = function () {
            var request = {
                price: $scope.sellOffer.pricePerBTC,
                amount: $scope.sellOffer.amount,
                total: $scope.sellOffer.total,
                fee: $scope.sellOffer.fee
            };
            sellDashboardService.submitSellBitCoin(request, sellBitCoinSuccess, sellBitCoinError);
        }

        //TODO: Link to production data
        ///Trade history table
        $scope.sellOffers = [];

        /**
         * Initializes controller-specific data 
         */
        function getAvailableOffersSuccess() {
            angular.extend($scope.buyOffers, result);
            console.log(result);
        }

        function sellBitCoinSuccess() {
            
        }

        function sellBitCoinError() {

        }

        function getAvailableOffersError() {

        }

        function init() {
            $scope.sellOffer.init();
            sellDashboardService.getAvaliableOffers(getAvailableOffersSuccess, getAvailableOffersError);
        }

        init();
    }
})();