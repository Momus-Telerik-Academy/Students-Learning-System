var userController = (function () {

    //page, context, element, action, params
    function register(context) {
        appManager.loadView("signup", context, false, false, false)
            .then(function () {
                $(USER_CONSTANTS.BTN_REGISTER).on("click", function () {
                    var user = {
                        Username: $("#tb-username").val(),
                        Email: $(USER_CONSTANTS.TB_EMAIL).val(),
                        Password: $(USER_CONSTANTS.TB_PASSWORD).val(),
                        ConfirmPassword: $(USER_CONSTANTS.TB_CONFIRM_PASSWORD).val()
                    };
                    console.log(user);
                    userModel.register(user)
                        .then(function () {
                            context.redirect("/#/login");
                        },
                            function (err) {

                                alert("TODO: Insert toastr" + "");
                            });

                    console.log(user);
                    return false;
                });
            });
    }

    function login(context) {
        console.log("Login");
        appManager.loadView("login", context, false, false, false)
            .then(function () {
                console.log("before click");
                $(USER_CONSTANTS.BTN_LOGIN).on("click", function () {
                    console.log("clickeddd");
                    var user = {
                        Username: $("#tb-username").val(),
                        Password: $(USER_CONSTANTS.TB_PASSWORD).val()
                    };

                    console.log(user);

                    userModel.login(user)
                        .then(function (res) {
                            console.log(res);
                            localStorage.setItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN, res.access_token);
                            localStorage.setItem(USER_CONSTANTS.LOCAL_STORAGE_USERNAME, res.userName);

                            appManager.toggleUserState();

                            context.redirect("/#/");
                        },
                            function (err) {

                                alert("TODO: Insert toastr" + "");
                            });

                    console.log(user);
                    return false;
                });

            }, function (err) {
                console.log(err);
            });
    }

    function logout(context) {
        localStorage.removeItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        localStorage.removeItem(USER_CONSTANTS.LOCAL_STORAGE_USERNAME);

        appManager.toggleUserState();
        context.redirect("/#/");
    }


    return {
        register: register,
        login: login,
        logout: logout
    };
}())