(function () {
    'use strict';

    var app = angular.module('ngiUI');

    app.factory('notificationModel', notificationModel);

    function notificationModel() {
        var model = {};
        toastr.options.positionClass = "toast-top-center";
        toastr.options.newestOnTop = true;

        model.notificationCodes = {
            general: 'GE'
        };

        model.pageErrors = [];
        model.globalNotifications = [];

        // Adds to the notification and sets the type
        function addMessage (message, type) {
            var errorObject = message;

            if (typeof message !== 'object') {
                errorObject = {
                    code: model.notificationCodes.general,
                    description: message
                };
            }

            if (type === "ERROR") {
                model.pageErrors.push(errorObject);
            }

            errorObject.type = type;
            model.globalNotifications.push(errorObject);            
        };

        model.addError = function (error) {
            addMessage(error, "ERROR");
        };

        model.clear = function () {
            model.pageErrors.length = 0;
        };

        model.addWarning = function (warning) {
            addMessage(warning, "WARNING");
        };

        model.addNotification = function (notification) {
            addMessage(notification, "INFO");
        };

        model.removeErrorByIndex = function (index) {
            if (typeof index !== 'undefined') {
                model.pageErrors.splice(index, 1);
            }
        };
//Changed to return the model
        return model;
    };
})();