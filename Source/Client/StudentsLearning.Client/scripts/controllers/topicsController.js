var topicsController = (function () {

    function byId(context) {
        var topicId = +context.params['topicId'];
        categoryModel.currentId(+context.params['categoryId']);
        sectionModel.currentId(+context.params['sectionId'])

        appManager.loadView("category", context, false, categoryModel.byId, categoryModel.currentId())
       .then(function () {
           sidebarController.config;

           eventManager.attachShowSection(context);
           eventManager.attachAddSection(context);

           return appManager.loadView("section", context, Constants.CATEGORY_CONTENT_WRAPPER, sectionModel.getById, sectionModel.currentId());;
       })
        .then(function () {
            return appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId);
        })
        .then(function (data) {
            topicModel.Properties = data;
            eventManager.attachCommentAdd();
            eventManager.attachLikeEvent();
            eventManager.attachDislikeEvent();
        }, function (err) {
            toastr.error(err);
            console.log(err);
        });
    }

    function add(context) {
        if (appManager.checkIfLogged() === false) {
            toastr.warning('You must be logged in to add topics');
        }
        else {
            appManager.loadView("add-topic", context, Constants.CATEGORY_CONTENT_WRAPPER)
                .then(function (res) {
                    $("#add-example").on("click", function (e) {
                        e.preventDefault();
                        $("#topic-examples").load("partials/add-example.html");
                    });

                    $("#btn-topic-add").on("click", function (e) {
                        e.preventDefault();

                        var newExample = {
                            description: $("#tb-example-description").val(),
                            content: $("#tb-example-content").val()
                        };

                        var video_id = $("#tb-topic-video").val().split("v=")[1];
                        var ampersandPosition = video_id.indexOf("&");
                        if (ampersandPosition != -1) {
                            video_id = video_id.substring(0, ampersandPosition);
                        }

                        if ($("#tb-example-description").val() === undefined && $("#tb-example-content").val() === undefined) {
                            var newTopic = {
                                title: $("#tb-topic-title").val(),
                                content: $("#tb-topic-content").val(),
                                videoId: video_id,
                                sectionId: sectionModel.currentId().toString(),
                                examples: []
                            };
                        }
                        else {
                            var newTopic = {
                                title: $("#tb-topic-title").val(),
                                content: $("#tb-topic-content").val(),
                                videoId: video_id,
                                sectionId: sectionModel.currentId().toString(),
                                examples: [
                                    newExample
                                ]
                            };
                        }
                        
                        topicModel.add(newTopic)
                            .then(function (id) {
                                // var id = topicModel.currentId() ? topicModel.currentId() : 1;
                                topicModel.currentId(id);
                                uploadController.upload(id);

                            }, function (err) {
                                console.log(err);
                            }).then(function () {
                                notificationController.publish('New topic has been added');
                            });

                    });
                }, function (err) {
                    //console.log(err);
                });
        }

    }

    function edit(context) {
        var topicId = context.params['id'];
        if (appManager.checkIfLogged() === false) {
            toastr.warning('You must be logged in to edit topics');
        }
        else {
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
                    $('.tb-topic-edit-content').attr('maxlength', '500');
                    //  htmlElementCreator.createButton($parent, 'Ok', editBtnId);

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
    }

    return {
        byId: byId,
        add: add,
        edit: edit
    }
}());