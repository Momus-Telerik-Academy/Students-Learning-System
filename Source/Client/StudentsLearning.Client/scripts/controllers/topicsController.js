var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];

        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            console.log('fine');
        });
    }

    function edit(context) {
        var topicId = context.params['id'];
        appManager.loadView('edit-topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            $('.btn-edit-topic').on('click', function (e) {
                var $target =  $(e.currentTarget);
                var $parent =$target.parent();

                // $parent, itemName, properties)
                htmlElementCreator.createForm($parent, 'tb-topic-edit', [$target.attr('id')]);

            });
        });
    }

    return {
        byId: byId,
        edit: edit
    }

}())