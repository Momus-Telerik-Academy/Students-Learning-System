var homeController = (function () {


    function showHome(context) {
        var categories;
        notificationController.init();
        // Login

        appManager.loadView("home", context, false, categoryModel.all)
            .then(function () {
                // set events
                $(".btn-category-show").on("click", function (e) {
                    var target = e.currentTarget;
                    // TODO: Save on localeStorage for better behave on refresh
                    categoryModel.currentId(+$(target).attr("id"));
                    context.redirect("/#/category/" + categoryModel.currentId());
                });

                notificationController.subscribe();
            });
    }

    return {
        startUp: showHome
    };
}())