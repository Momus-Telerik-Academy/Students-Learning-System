var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];
        
        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            console.log('fine');
        });
    }

    return {
        byId: byId
    }

}())