var topicModel = (function () {
    var categoryId;

    var Properties = {
        VideoId: 'none',
        Content: 'none',
        ZipFiles : []
    };

    function currentId(id) {
        if (id) {
            categoryId = id;
        } else {
            return categoryId;
        }

    }

    function add(topic) {
        return ajaxRequester.post('api/Topics', { data: topic })
    }

    function byId(id) {
        return ajaxRequester.get('api/topics/' + id);
    }

    return {
        add: add,
        byId: byId,
        currentId: currentId,
        Properties : Properties
    }

}())