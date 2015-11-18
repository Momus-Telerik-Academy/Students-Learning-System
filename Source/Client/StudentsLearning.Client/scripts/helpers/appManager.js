var appManager = function () {

    function loadView(page, context, element, action, params) {
        var data;

        if (action) {
            return action(params)
                .then(function (res) {
                    data = res;
                    return templatesManager.get(page);
                })
                .then(function (partial) {
                    templatesManager.fill(context, partial, element, data);
                    return data;
                });
        } else {
            return templatesManager.get(page)
                .then(function (partial) {
                    templatesManager.fill(context, partial, element);
                });
        }
    }

    function toggleUserState() {
        var element = $("#bs-example-navbar-collapse-1").find("#login-container");
        var elementRegister = $(".register-container");
        var state = element.text();

        if (localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_USERNAME)
            && localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN)) {

            if (state.indexOf("In") == -1) {
                element.text("Log In");
                elementRegister.text("Register")
            }

            element.text("Log Out");
            element.attr("href", "#/logout");

            elementRegister.hide();

        } else if (state.indexOf("In") == -1) {
            element.text("Log In");
            element.attr("href", "/#/login");

            elementRegister.show();
        }
    }

    function validateEmail(email) {
        var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        return re.test(email);
    }

    return {
        loadView: loadView,
        toggleUserState: toggleUserState,
        validateEmail: validateEmail

    };
}();