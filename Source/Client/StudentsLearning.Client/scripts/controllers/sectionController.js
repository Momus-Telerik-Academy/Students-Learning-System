var sectionsController = (function () {

    function byId(context) {
        var sectionId = context.params['id'];
        var section;

        sectionModel.getById(sectionId)
        .then(function (res) {

            console.log(res);
            section = res;
            return templatesManager.get('section');
        })
        .then(function (partial) {
            var categoryContent = context.$element().find(Constants.CATEGORY_CONTENT_WRAPPER);
            console.log(categoryContent);
            if (categoryContent.html() == undefined) {
                context.redirect('/#/category/2   ');
                categoryContent = context.$element().find(Constants.CATEGORY_CONTENT_WRAPPER);
            }
            categoryContent.html(partial(section))
        });

        console.log('in section')
    }

    function add(context) {
        console.log('in section');
        appManager.loadView('add-section', context, Constants.CATEGORY_CONTENT_WRAPPER)
            .then(function (res) {
                console.log('after app');
                $('#btn-section-add').on('click', function (e) {
                    console.log('click?');
                    var newSection = {
                        Name: $('#tb-section-name').val(),
                        Description: $('#tb-section-description').val(),
                        CategoryId: categoryModel.currentId()
                    };

                    sectionModel.add(newSection)
                    .then(function () {
                        var id = categoryModel.currentId() ? categoryModel.currentId() : 1;
                        categoryModel.currentId(id);
                        console.log(id);
                        context.redirect('/#/category/' + categoryModel.currentId());
                    }, function (err) {
                        alert(err);
                    })
                })
            }, function (err) {
                alert(err);
            });

    }

    return {
        byId: byId,
        add: add
    }
}())