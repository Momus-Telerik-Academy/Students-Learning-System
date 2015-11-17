var commentModel = (function () {

    function add(comment) {
       
        var headers = {};// 'Authorization': 'Bearer ' + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN) }
        headers.Authorization = 'Bearer ' + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);

       // console.log(options.headers);
        return ajaxRequester.post("api/Comments", { data: comment, headers: headers });
    }

    return {
        add: add
    }
}())