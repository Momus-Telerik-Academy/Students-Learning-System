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
                    if ($("#tb-username").val() === "") {
                        toastr.warning("Username field cannot be empty");
                    }
                    else if ($(USER_CONSTANTS.TB_EMAIL).val() === "") {
                        toastr.warning("Email field cannot be empty");
                    }
                    else if ($(USER_CONSTANTS.TB_PASSWORD).val() === "") {
                        toastr.warning("Password field cannot be empty");
                    }
                    else if ($(USER_CONSTANTS.TB_CONFIRM_PASSWORD).val() === "") {
                        toastr.warning("Confirm password field cannot be empty");
                    }
                    else if (!appManager.validateEmail($(USER_CONSTANTS.TB_EMAIL).val())) {
                        toastr.warning('Invalid email address');
                    }
                    else if ($(USER_CONSTANTS.TB_PASSWORD).val().length < 6) {
                        toastr.warning('Password must be longer than 6 symbols')
                    }
                    else if ($(USER_CONSTANTS.TB_PASSWORD).val() !== $(USER_CONSTANTS.TB_CONFIRM_PASSWORD).val()) {
                        toastr.warning('Password does not match the confirm password');
                    }
                    else {
                        userModel.register(user)
                        .then(function () {
                            context.redirect("/#/login");
                            toastr.success('Successful register! Redirecting to login page..');
                        },
                            function (err) {
                                toastr.error('Invalid username or password.');
                            });
                        return false;
                    }
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

                    if ($("#tb-username").val() === "") {
                        toastr.warning('Username field cannot be empty');
                    }
                    else if ($(USER_CONSTANTS.TB_PASSWORD).val() === "") {
                        toastr.warning('Password field cannot be empty');
                    }
                    else {
                        userModel.login(user)
                        .then(function (res) {
                            localStorage.setItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN, res.access_token);
                            localStorage.setItem(USER_CONSTANTS.LOCAL_STORAGE_USERNAME, res.userName);

                            appManager.toggleUserState();

                            context.redirect("/#/");
                            toastr.success('Welcome back ' + res.userName + '!');
                        },
                            function (err) {
                                toastr.error('Invalid username or password');
                            });
                        return false;
                    }
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
        location.reload();
    }


    return {
        register: register,
        login: login,
        logout: logout
    };
}())