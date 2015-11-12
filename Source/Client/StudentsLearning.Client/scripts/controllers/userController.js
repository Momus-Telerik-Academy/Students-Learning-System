var userController = (function () {

    //page, context, element, action, params
    function register(context) {
        appManager.loadView('signup', context, false, false, false)
        .then(function () {
            $(USER_CONSTANTS.BTN_REGISTER).on('click', function () {
                var user = {
                    Email: $(USER_CONSTANTS.TB_EMAIL).val(),
                    Password: $(USER_CONSTANTS.TB_PASSWORD).val(),
                    ConfirmPassword: $(USER_CONSTANTS.TB_CONFIRM_PASSWORD).val()
                };

                userModel.register(user)
                    .then(function () {
                        context.redirect('/#/login');
                    },
                    function (err) {
                       
                       alert('TODO: Insert toastr' + "")
                    });

                console.log(user);
                return false;
            });
        });
    }

    function login(contex) {
        appManager.loadView('login', contex, false, false, false)
        .then(function () {

        });
    }

    function logout(contex) { }


    return {
        register: register,
        login: login,
        logout: logout
    }

}())