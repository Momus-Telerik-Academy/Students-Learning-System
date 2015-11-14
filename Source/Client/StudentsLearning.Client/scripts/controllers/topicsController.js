var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];

        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            console.log('fine');
        });
    }

    function add(context) {
        var sectionId = context.params['id'];
        console.log(context);
        console.log("clicked");
        appManager.loadView('add-topic', context, Constants.CATEGORY_CONTENT_WRAPPER)
            .then(function (res) {
                //$('#add-example').on('click', function () {
                //    $('#topic-examples').load('partials/add-example.html');
                //});

                $('#btn-topic-add').on('click', function (e) {
                    console.log("clickedeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
                    var newExample = {
                        description: ($('#tb-example-description').val() ? undefined : ""),
                        content: ($('#tb-example-content').val() ? undefined : "")
                    };

                    var newFiles = {
                        "originalName": "originalName1",
                        "dbName": "dbName1",
                        "path": "path"
                    }

                    var video_id = $('#tb-topic-video').val().split('v=')[1];
                    var ampersandPosition = video_id.indexOf('&');
                    if (ampersandPosition != -1) {
                        video_id = video_id.substring(0, ampersandPosition);
                    }

                    //TODO: Fix sectionModel.currentId for sections
                    var id = sectionModel.currentId() || 1;

                    var newTopic = {
                        title: $('#tb-topic-title').val(),
                        content: $('#tb-topic-content').val(),
                        videoId: video_id,
                        sectionId: id,
                        examples: [],
                        zipFiles: []
                    };

                    console.log(newTopic);
                    topicModel.add(newTopic)
                    .then(function () {
                        var id = topicModel.currentId() ? topicModel.currentId() : 1;
                        topicModel.currentId(id);
                        console.log(id);
                        context.redirect('/#/topics/' + topicModel.currentId());
                    }, function (err) {
                        console.log(err);
                    })
                });
            }, function (err) {
                //console.log(err);
            });
    }

    return {
        byId: byId,
        add: add
    }

}())