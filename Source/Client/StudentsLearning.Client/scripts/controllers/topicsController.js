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
        console.log("clicked");
        appManager.loadView('add-topic', context, Constants.CATEGORY_CONTENT_WRAPPER)
            .then(function (res) {
                $('#add-example').on('click', function () {
                    $('#topic-examples').load('partials/add-example.html');
                });

                $('#btn-topic-add').on('click', function (e) {
                    console.log("clickedeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
                    var newExample = {
                        description: $('#tb-example-description').val(),
                        content: $('#tb-example-content').val()
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

                    var newTopic = {
                        title: $('#tb-topic-title').val(),
                        content: $('#tb-topic-content').val(),
                        videoId: video_id,
                        sectionId: sectionModel.currentId().toString(),
                        examples: [
                            newExample
                        ],
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

    function edit(context) {
        var topicId = context.params['id'];
        appManager.loadView('edit-topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            $('.btn-edit-topic').on('click', function (e) {
                var $target = $(e.currentTarget),
                 $parent = $target.parent(),
                 targetId = $target.attr('id'),
                 editBtnId = 'btn-change-topic-' + targetId,
                 inputId = '.tb-topic-edit-' + targetId,
                 $saveBtn = $('#btn-edit-topic-save');

                // $parent, itemName, properties)
                htmlElementCreator.createForm($parent, 'tb-topic-edit', [targetId]);
                htmlElementCreator.createButton($parent, 'Ok', editBtnId);

                var formData = new FormData();

                //$('#upload').submit(function () {
                //    var opmlFile = $('#opmlFile')[0];

                //    formData.append("opmlFile", opmlFile.files[0]);
                    
                //});

                $saveBtn.on('click', function () {

                    var opmlFile = $('#opmlFile')[0];

                    formData.append("opmlFile", opmlFile.files[0]);
                    topicModel.Properties.ZipFiles.push(formData);
                    var updatedTopic = {
                        VideoId: $('.tb-topic-edit-video-url').val() || topicModel.Properties.VideoId,
                        Content: $('.tb-topic-edit-content').val() || topicModel.Properties.Content,
                        ZipFiles: topicModel.Properties.ZipFiles
                    }

                    console.log(updatedTopic);
                });

            });
        });
    }

    return {
        byId: byId,
        add: add,
        edit: edit
    }

}())