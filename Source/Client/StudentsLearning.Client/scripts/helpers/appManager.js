var appManager = function () {

    function loadView(page, context, action) {
        var data;

        if (action) {
            return action()
                 .then(function (res) {
                     data = res;
                     return templatesManager.get(page)
                 })
                 .then(function (partial) {
                     templatesManager.fill(context, partial, data);
                 })
        } else {
            return templatesManager.get(page)       
                .then(function (partial) {
                 templatesManager.fill(context, partial);
        })
        }
    }

    return {
        loadView: loadView
    }

}();