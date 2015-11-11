var templatesManager = function () {
    var handlebars = window.handlebars || window.Handlebars,
      Handlebars = window.handlebars || window.Handlebars,
      cache = {};

    function get(name) {
        var promise = new Promise(function (resolve, reject) {

            var url = Constants.PARTIALS_DIRECTORY + name + Constants.PARTIALS_FILE_EXTENSION;
           
            $.get(url, function (html) {
                var template = handlebars.compile(html);
                cache[name] = template;
                resolve(template);
            });
        });
        return promise;
    }

    function fillData(context, partial, data) {
       
        if (data) {
            return context.$element().html(partial(data));
        } else {
            return context.$element().html(partial);
        }
    }

    return {
        get: get,
        fill: fillData
    };
}();
