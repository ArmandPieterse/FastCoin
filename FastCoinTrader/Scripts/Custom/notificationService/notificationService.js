(function() {
    'use strict';

    var app = angular.module('ngiUI');

    app.service('notificationService', [
        'notificationModel',
        notificationService
    ]);

    function notificationService(notificationModel) {
        var service = {};

        service.notificationModel = notificationModel;

        toastr.options.preventDuplicates = true;

        service.addError = function (error) {
            service.notificationModel.addError(error);
        };

        service.addWarning = function (warning) {
            service.notificationModel.addWarning(warning);
            if(warning !== null && typeof warning === 'object')
                toastr.warning(warning.description);
            else 
                toastr.warning(warning);
        };

        service.addNotification = function (notification, showToastr) {
            if (!showToastr) 
                showToastr = false;

            service.notificationModel.addNotification(notification);
            if (showToastr) {
                if (typeof warning === 'object')
                    toastr.success(notification.description);
                else
                    toastr.success(notification);
            }
        };

        service.removeErrorByIndex = function (index) {
            if (typeof index !== 'undefined') {
                service.notificationModel.removeErrorByIndex(index);
            }
        };

        service.clearNotifications = function () {
            service.notificationModel.clear();
        };

        return service;
    };
})();