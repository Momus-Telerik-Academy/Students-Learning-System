var userModel = function () {

    function register(user) {
        return ajaxRequester.post('api/account/register', { data: user });
    }

    function login() {

    }

    return {
        register: register,
        login: login
    }

}()