var sectionsController = (function () {

    function byId(context) {
        var sectionId = context.params['id'];
        //get data -> then ->
        var section = {
            Id: 1,
            Name: "Algo",
            Topics: [
                {
                    Id: 1,
                    Name: "Data Structures",
                    Description: "Lorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsum  Lorem ipsum "
                },
                {
                    Id: 2,
                    Name: "Combinatorics",
                    Description: "Lorem ipsum Lorem ipsum Lorem ipsumLorem ipsumLorem ipsum  Lorem ipsum "
                }
            ]
        }
        templatesManager.get('section')
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