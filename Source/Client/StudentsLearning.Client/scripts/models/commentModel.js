var commentModel = (function () {
    var headers = {},
        BEARER = 'Bearer ',
        API_ROUTE = {
            COMMENTS: "api/Comments",
            LIKES: "api/Likes/",
            DISLIKES: "api/Dislikes/"
        }

    function add(comment) {
        headers.Authorization = BEARER + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        return ajaxRequester.post(API_ROUTE.COMMENTS, { data: comment, headers: headers });
    }

    function like(id) {
        headers.Authorization = BEARER + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        return ajaxRequester.post(API_ROUTE.LIKES + id, { headers: headers });
    }

    function dislike(id) {
        headers.Authorization = BEARER + localStorage.getItem(USER_CONSTANTS.LOCAL_STORAGE_TOKEN);
        return ajaxRequester.post(API_ROUTE.DISLIKES + id, { headers: headers });
    }

    return {
        add: add,
        like: like,
        dislike: dislike
    }
}())