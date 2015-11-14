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
                     return data;
                 })
        } else {
            return templatesManager.get(page)
                .then(function (partial) {
                    templatesManager.fill(context, partial, element);
                })
        }
    }

    function toggleUserState() {
        var element = $('#bs-example-navbar-collapse-1').find('#login-container');
        var state = element.text();

        if (localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_USERNAME)
            && localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN)) {

            if (state.indexOf('In') == -1) {
                element.text('Log In');
            }

            element.text('Log Out');
            element.attr('href', '#/logout');

        } else {

            if (state.indexOf('In') == -1) {
                element.text('Log In');
                element.attr('href', '/#/login');
            }
        }

       
       

    }

    return {
        loadView: loadView,
        toggleUserState: toggleUserState
    }

}();