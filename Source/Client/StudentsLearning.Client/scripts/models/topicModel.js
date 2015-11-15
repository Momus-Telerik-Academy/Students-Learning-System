var topicModel = (function() {
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
        return ajaxRequester.post("api/Topics", { data: topic });
    }

    function byId(id) {
        return ajaxRequester.get("api/topics/" + id);
    }

    function edit(id, topic) {
        return ajaxRequester.put("api/topics/" + id, { data: topic });
    }

    return {
        add: add,
        byId: byId,
        edit: edit,
        currentId: currentId,
        Properties: Properties
    };
}())