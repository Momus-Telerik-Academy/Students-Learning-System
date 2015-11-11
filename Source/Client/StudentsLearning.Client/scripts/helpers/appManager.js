var appManager = function () {

    function loadView(page, context, element, action, params) {
        var data;

        if (action) {
            return action(params)
                 .then(function (res) {
                     data = res;
                     return templatesManager.get(page)
                 })
                 .then(function (partial) {
                     templatesManager.fill(context, partial, element, data);
                 })
        } else {
            return templatesManager.get(page)
                .then(function (partial) {
                    templatesManager.fill(context, partial, element);
                })
        }
    }

    return {
        loadView: loadView
    }

}();