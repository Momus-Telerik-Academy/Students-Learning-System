var ajaxRequester = (function() {

    function send(method, url, options) {
        options = options || {};
        contentType = options.contentType || "application/json";
        url = Constants.DOMAIN + url;

        var headers = options.headers || { 'Cache-Control': "no-cache" },
            data = options.data || undefined;

        if (!options.noStringify) {
            data = JSON.stringify(data);
        }

        var promise = new Promise(function(resolve, reject) {
            $.ajax({
                url: url,
                method: method,
                contentType: contentType,
                headers: headers,
                data: data,
                success: function(res) {
                    resolve(res);
                },
                error: function(err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function get(url, options) {
        return send("GET", url, options);
    }

    function post(url, options) {
        return send("POST", url, options);
    }

    function put(url, options) {
        return send("PUT", url, options);
    }

    function del(url, options) {
        return send("DELETE", url, options);
    }

    return {
        send: send,
        get: get,
        post: post,
        put: put,
        delete: del
    };
}());