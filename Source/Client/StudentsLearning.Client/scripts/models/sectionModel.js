﻿var sectionModel = (function () {
    var sectionId;

    function sectionId(id) {
        if (id) {
            sectionId = id;
        } else {
            return sectionId;
        }

    }
    function getById(id) {
        id = id | 0;
        return ajaxRequester.get('api/sections/' + id)
    }

    function add(section) {
        return ajaxRequester.post('api/sections', { data: section })
    }

    return {
        getById: getById,
        add: add
    }

}())