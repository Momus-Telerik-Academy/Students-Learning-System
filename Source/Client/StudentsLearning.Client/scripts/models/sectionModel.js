var sectionModel = (function() {
    var sectionId = 1;

    function currentId(id) {
        if (id) {
            sectionId = id;
        } else {
            return sectionId;
        }

    }

    function getById(id) {
        id = id | 0;
        return ajaxRequester.get("api/sections/" + id);
    }

    function add(section) {
        return ajaxRequester.post("api/sections", { data: section });
    }

    return {
        getById: getById,
        add: add,
        currentId: currentId
    };
}())