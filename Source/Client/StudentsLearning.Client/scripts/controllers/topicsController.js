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


                //$('#upload').submit(function () {
                //    var opmlFile = $('#opmlFile')[0];

                //    formData.append("opmlFile", opmlFile.files[0]);

                //});



            });

            $saveBtn.on('click', function () {

                var formData = new FormData();

                var opmlFile = $('#opmlFile')[0];

                formData.append("opmlFile", opmlFile.files[0]);
                topicModel.Properties.ZipFiles.push(formData);

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
                    ZipFiles: topicModel.Properties.ZipFiles,
                    Examples: updatedExamples
                }

                topicModel.edit(topicModel.currentId(), updatedTopic);
                console.log(updatedTopic);
            });
        });
    }

    return {
        byId: byId,
        edit: edit
    }

}())