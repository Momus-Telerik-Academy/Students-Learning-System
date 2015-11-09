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

    return {
        all: all
    }

}())