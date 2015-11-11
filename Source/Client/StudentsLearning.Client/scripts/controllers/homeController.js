var homeController = (function () {

    function showHome(context) {
        var categories;

        // Login

        appManager.loadView('home', context, false, categoryModel.all)
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