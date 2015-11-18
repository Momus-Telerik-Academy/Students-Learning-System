var categoriesController = (function() {

    function all(context) {
        var categories;

        //categoryModel.all()
        //    .then(function(res) {
        //        categories = res;
        //        console.log(categories);
        //        return templatesManager.get("categories");
        //    })
        //    .then(function(partial) {
        //        templatesManager.fill(context, partial, categories);
        //    })
        appManager.loadView("categories", context, false, categoryModel.all, false)
            .then(function() {
                $("#btn-add").on("click", function() {
                    categoryModel.add($("#tb-new-category-name").val());
                });

                $(".btn-category-show").on("click", function (e) {
                    var target = e.currentTarget;
                    // TODO: Save on localeStorage for better behave on refresh
                    categoryModel.currentId(+$(target).attr("id"));
                    context.redirect("/#/category/" + categoryModel.currentId());
                });               
            });
    }

    function byId(context) {
        console.log('categories');
        categoryModel.currentId(+context.params["categoryId"]);
        var category;

        appManager.loadView("category", context, false, categoryModel.byId, categoryModel.currentId())
            .then(function() {
                sidebarController.config;

                eventManager.attachShowSection(context);
                eventManager.attachAddSection(context);
               
            });
        return false;
    }

    function add(context) {
        appManager.loadView("add-category", context)
            .then(function() {
                $("#btn-category-add").on("click", function() {
                    console.log($("#tb-category-add").val());
                    categoryModel.add({ name: $("#tb-category-add").val() })
                        .then(function () {
                            notificationController.publish('new category added');

                            context.redirect("/#/");
                        });
                });
            });
    }

    return {
        all: all,
        current: byId,
        add: add
    };
}())