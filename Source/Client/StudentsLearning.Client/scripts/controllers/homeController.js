var homeController = (function () {

    function showHome(context) {
        var categories;

        // Login

        categoryModel.all()
            .then(function (res) {
                categories = res;
                return templatesManager.get('home')
            })
            .then(function (partial) {
                templatesManager.fill(context, partial, categories);
            })
            .then(function () {
               // set events
                $('.btn-category-show').on('click', function (e) {
                    var target = e.currentTarget;
                    console.log(e.currentTarget);
                    context.redirect('/#/category/' + $(target).attr('id'));
                });
            })
    }

    return {
        startUp: showHome
    }

}())