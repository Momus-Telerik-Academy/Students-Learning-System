var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];
        
        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            console.log('fine');
        });
    }

    function add(context) {
        appManager.loadView('add-topic', context, Constants.CATEGORY_CONTENT_WRAPPER)
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