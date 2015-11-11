var sectionModel = (function () {

    function getById(id) {
        id = id | 0;
        return ajaxRequester.get('api/sections/' + id)
    }

    return {
        getById: getById
    }

}())