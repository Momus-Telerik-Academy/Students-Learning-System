var userModel = function () {

    function register(user) {
        return ajaxRequester.post("api/account/register", { data: user });
    }

    function login(user) {
        var options = {};
        options.contentType = "application/x-www-form-urlencoded";
        options.noStringify = true;
        options.data = "grant_type=password&username=" + user.Username + "&password=" + user.Password;

        return ajaxRequester.post("token", options);
    }

    return {
        register: register,
        login: login
    };
}()