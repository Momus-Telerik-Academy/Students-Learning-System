var categoryModel = (function() {
    var categoryId;

    function currentId(id) {
        if (id) {
            categoryId = id;
        } else {
            return categoryId;
        }

    }

    function all() {
        return ajaxRequester.get("api/categories");
    }

    function add(name) {
        return ajaxRequester.post("api/categories", { data: name });
    }

    function byId(id) {
        return ajaxRequester.get("api/categories/" + id);
    }

    return {
        all: all,
        add: add,
        byId: byId,
        currentId: currentId
    };
}())