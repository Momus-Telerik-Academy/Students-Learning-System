var topicsController = (function () {

    function byId(context) {
        var topicId = context.params['id'];

        //page, context, element, action, params
        appManager.loadView('topic', context, Constants.CATEGORY_CONTENT_WRAPPER, topicModel.byId, topicId)
        .then(function () {
            console.log('fine');
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
        edit: edit
    }

}())