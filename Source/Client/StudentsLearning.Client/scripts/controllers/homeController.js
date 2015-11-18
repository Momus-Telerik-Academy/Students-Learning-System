var homeController = (function () {


    function showHome(context) {
        //toastr.options.progressBar = true;
        toastr.options.closeButton = true;
        var categories;
        notificationController.init();
        // Login

        appManager.loadView('home', context, false, categoryModel.all)
            .then(function () {
                appManager.toggleUserState();
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

    function aboutPage(context) {
        appManager.loadView('about', context, false);
    }

    function contactPage(context) {
        appManager.loadView('contact', context, false);
    }

    return {
        startUp: showHome,
        about: aboutPage,
        contact: contactPage
    };
}())