var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];

        console.log(topicId);
    }

    return {
        byId: byId
    }

}())