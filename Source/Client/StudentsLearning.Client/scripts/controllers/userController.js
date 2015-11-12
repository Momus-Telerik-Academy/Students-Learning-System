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

    function login(context) {
        console.log('Login');
        appManager.loadView('login', context, false, false, false)
        .then(function () {
            console.log('before click');
            $(USER_CONSTANTS.BTN_LOGIN).on('click', function () {
                console.log('clickeddd');
                var user = {
                    Email: $(USER_CONSTANTS.TB_EMAIL).val(),
                    Password: $(USER_CONSTANTS.TB_PASSWORD).val()
                };

                console.log(user);

                userModel.login(user)
                    .then(function (res) {
                        console.log(res);
                        context.redirect('/#/');
                    },
                    function (err) {

                        alert('TODO: Insert toastr' + "")
                    });

                console.log(user);
                return false;
            });
            
        }, function (err) {
            console.log(err);
        });
    }

    function logout(contex) { }


    return {
        register: register,
        login: login,
        logout: logout
    }

}())