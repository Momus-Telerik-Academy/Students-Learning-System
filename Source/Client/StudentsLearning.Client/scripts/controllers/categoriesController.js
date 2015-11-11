var categoriesController = (function () {

    function all(context) {
        var categories;

        categoryModel.all()
            .then(function (res) {
                categories = res;
                console.log(categories);
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
        categoryModel.currentId(+context.params['id'])

        var category;

        appManager.loadView('category', context, false, categoryModel.byId, categoryModel.currentId())
        .then(function () {
            sidebarController.config;

            $('.btn-section-show').on('click', function (e) {
                context.redirect('/#/sections/' + $(e.currentTarget).attr('id'));
            });

            $('.btn-section-add').on('click', function () {
                context.redirect('/#/add/section');
            });
        });
    }

    function add(context) {
        appManager.loadView('add-category', context)
        .then(function () {
            $('#btn-category-add').on('click', function () {
                console.log($('#tb-category-add').val());
                categoryModel.add({ name: $('#tb-category-add').val() })
                .then(function () {
                    context.redirect('/#/')
                });
            });
        });
    }

    return {
        all: all,
        current: byId,
        add: add
    }

}())