var eventManager = (function () {

    var BUTTONS = {
        LIKE: '.btn-like',
        DISLIKE: '.btn-dislike',
        SECTION_SHOW: '.btn-section-show',
        SECTION_ADD: '.btn-section-add',
        TOPIC_SHOW: '.btn-topic-show'
    }


    function attachLikeEvent() {
        $(BUTTONS.LIKE).on('click', function (e) {
            var $target = $(e.currentTarget),
             id = $($target).parent().attr('id'),
             counter = $target.next(),
             count = +$(counter).text();

            commentModel.like(id)
            .then(function () {
                counter.text(++count);
            }, function (err) {
                toastr.error(err.Message);
            });
        });
    }

    function attachDislikeEvent() {
        $(BUTTONS.DISLIKE).on('click', function (e) {
            var $target = $(e.currentTarget),
             id = $($target).parent().attr('id'),
             counter = $target.next(),
             count = +$(counter).text();

            commentModel.dislike(id)
            .then(function () {
                counter.text(++count);
            }, function (err) {
                toastr.error(err.Message);
            });
        });
    }

    function attachShowSection(context) {
        $(BUTTONS.SECTION_SHOW).on("click", function (e) {
            context.redirect('/#/category/' + categoryModel.currentId() + '/sections/' + $(e.currentTarget).attr("id"));
        });
    }

    function attachAddSection(context) {
        $(BUTTONS.SECTION_ADD).on("click", function () {
            context.redirect("/#/add/section");
        });
    }

    function attachShowTopic(context) {
        $(BUTTONS.TOPIC_SHOW).on("click", function (e) {
            var target = e.currentTarget;

            topicModel.currentId(+$(target).attr("id"));
            context.redirect('/#/category/' + categoryModel.currentId() + '/sections/' + sectionModel.currentId() + "/topics/" + topicModel.currentId());
        });
    }

    function attachCommentAdd() {
        $('#btn-comment').on('click', function () {
            var comment = $('#tb-comment').val();
            commentModel.add({ content: comment, topicid: topicModel.currentId() })
             .then(function (res) {
                 console.log(res);
             }, function (err) {
                 console.log(err);
                 toastr.error(err);
             });
        });
    }

    return {
        attachLikeEvent: attachLikeEvent,
        attachDislikeEvent: attachDislikeEvent,
        attachShowSection: attachShowSection,
        attachAddSection: attachAddSection,
        attachShowTopic: attachShowTopic,
        attachCommentAdd: attachCommentAdd
    }
}())