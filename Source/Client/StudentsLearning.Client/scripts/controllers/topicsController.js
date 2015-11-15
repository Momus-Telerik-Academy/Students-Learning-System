var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];

        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function (data) {
            //topicModel.Properties.VideoId = data.VideoId;
            //topicModel.Properties.Content = data.Content;
            //topicModel.Properties.Examples = data.Examples;
            //topicModel.Properties.ZipFiles = data.ZipFiles;
            topicModel.Properties = data;
            console.log(topicModel);
            console.log('fine');
        });
    }

    function add(context) {
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

                    var newTopic = {
                        title: $('#tb-topic-title').val(),
                        content: $('#tb-topic-content').val(),
                        videoId: video_id,
                        sectionId: sectionModel.currentId().toString(),
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

    function edit(context) {
        var topicId = context.params['id'];
        appManager.loadView('edit-topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {

            $saveBtn = $('#btn-edit-topic-save');

            $('.btn-edit-topic').on('click', function (e) {
                var $target = $(e.currentTarget),
                $parent = $target.parent(),
                targetId = $target.attr('id'),
                editBtnId = 'btn-change-topic-' + targetId,
                inputId = '.tb-topic-edit-' + targetId;

                // $parent, itemName, properties)
                htmlElementCreator.createForm($parent, 'tb-topic-edit', [targetId]);
                htmlElementCreator.createButton($parent, 'Ok', editBtnId);

            });

            $saveBtn.on('click', function () {

               
                uploadController.upload(topicModel.currentId());
                //var formData = new FormData();

                //var opmlFile = $('#opmlFile')[0];

                //formData.append("opmlFile", opmlFile.files[0]);
               // topicModel.Properties.ZipFiles.push(formData);

                // editing already ezisting examples
                var updatedExamplesContent = $('.tb-topic-edit-example-content'),
                    updatedExamplesDescription = $('.tb-topic-edit-description'),
                    examples = $('.example');
                updatedExamples = [];


                for (var i = 0; i < examples.length; i++) {

                    updatedExamples.push({
                        Id: topicModel.Properties.Examples[i].Id,
                        Content: $($(examples[i]).find('.tb-topic-edit-example-content')).val() || topicModel.Properties.Examples[i].Content,
                        Description: $($(examples[i]).find('.tb-topic-edit-description')).val() || topicModel.Properties.Examples[i].Description
                    })
                }

                var updatedTopic = {
                    Title: topicModel.Properties.Title,
                    Content: $('.tb-topic-edit-content').val() || topicModel.Properties.Content,
                    VideoId: $('.tb-topic-edit-video-url').val() || topicModel.Properties.VideoId,
                    SectionId: sectionModel.currentId(), // or topicModel.SectionId
                  //  Zip: topicModel.Properties.ZipFiles,
                    Examples: updatedExamples
                }

                topicModel.edit(topicModel.currentId(), updatedTopic);
                console.log(updatedTopic);
            });
        });
    }

    return {
        byId: byId,
        add: add,
        edit: edit
    }

}())