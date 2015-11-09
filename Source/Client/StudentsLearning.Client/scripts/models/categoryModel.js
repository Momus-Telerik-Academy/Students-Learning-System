var categoryModel = (function () {

    function all() {
        return ajaxRequester.get('api/categories');
    }

    function add(name) {
        return ajaxRequester.post('api/categories', {data:name})
    }

    return {
        all: all,
        add:add
    }

}())