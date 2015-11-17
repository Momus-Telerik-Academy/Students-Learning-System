var topicModel = (function () {
    var categoryId;

    var Properties = {
        Title: "none",
        VideoId: "none",
        Content: "none",
        SectionId: "",
        Examples: [],
        ZipFiles: []
    };

    function currentId(id) {
        if (id) {
            categoryId = id;
        } else {
            return categoryId;
        }

    }

    function add(topic) {
        var headers = {};
        headers.Authorization = 'Bearer ' + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        return ajaxRequester.post("api/Topics", { data: topic, headers: headers });
    }

    function byId(id) {
        return ajaxRequester.get("api/topics/" + id);
    }

    function edit(id, topic) {
        var headers = {};
        headers.Authorization = 'Bearer ' + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        return ajaxRequester.put("api/topics/" + id, { data: topic , headers:headers});
    }

    return {
        add: add,
        byId: byId,
        edit: edit,
        currentId: currentId,
        Properties: Properties
    };
}())