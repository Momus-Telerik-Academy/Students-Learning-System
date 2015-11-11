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
                context.redirect('/#/category/1');
                categoryContent = context.$element().find(Constants.CATEGORY_CONTENT_WRAPPER);
            }
            categoryContent.html(partial(section))
        });

        console.log('in section')
    }

    return {
        byId: byId
    }
}())