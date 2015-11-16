var notificationController = (function () {

    var PUBLISH_KEY = "pub-c-b282b06d-8680-457b-9e5e-d2788be752a0",
           SUBSCRIBE_KEY = "sub-c-ff6b26f2-8c6c-11e5-a2e7-0619f8945a4f",
           SECRET_KEY = "sec-c-YzBlN2Q5Y2UtYjM3OC00YjUzLWJhYjctZDU1ZTAxNzBjNWRi",
           CHANEL = "E-Academy";

    var notifacationManager;

    function init() {
        notifacationManager = PUBNUB.init({
            publish_key: PUBLISH_KEY,
            subscribe_key: SUBSCRIBE_KEY
        });
    }

    function publish(notifacation) {
        notifacationManager.publish({
            channel: CHANEL,
            message: notifacation
        });
    }

    function subscribe() {
        notifacationManager.subscribe({
            channel: CHANEL,
            message: function (m) {
                toastr.success(m);
            },
        });
    }

    return {
        init: init,
        publish: publish,
        subscribe: subscribe
    }

}());