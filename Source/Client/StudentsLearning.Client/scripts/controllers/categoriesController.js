var categoriesController = (function () {

    function all(context) {
        var categories;

        categoryModel.all()
            .then(function (res) {
                categories = res;
                return templatesManager.get('home')
            })
            .then(function (partial) {
                templatesManager.fill(context, partial, categories);
            })
            .then(function () {
                $('#btn-add').on('click', function () {
                    categoryModel.add($('#tb-new-category-name').val());
                })

            })

    }

    function byId(context) {
        var categoryId = context.params['id'];
        var category;

        categoryModel.byId(categoryId)
        .then(function (res) {
            category = res;
            return templatesManager.get('category');
        })
        .then(function (partial) {
            templatesManager.fill(context, partial, category);
        })
        .then(function () {
            sidebarController.config;
           
            context.redirect('/#/sections/2')
            // atach events
        });
    }

    return {
        all: all,
        current: byId
    }

}())