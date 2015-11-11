var categoryModel = (function () {
    var categoryId;

    function currentId(id) {
        if (id) {
            categoryId = id;
        } else {
            return categoryId;
        }

    }

    function add(topic) {
        return ajaxRequester.post('api/topics', { data: topic })
    }

    function byId(id) {
        return ajaxRequester.get('api/topics/' + id);
    }

    return {
        add: add,
        byId: byId,
        currentId: currentId
    }

}())