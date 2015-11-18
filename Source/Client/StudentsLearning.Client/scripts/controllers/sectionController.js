﻿var sectionsController = (function () {

    function byId(context) {
        console.log('in section');
        var sectionId = context.params["sectionId"];
        sectionModel.currentId(sectionId);
        categoryModel.currentId(+context.params["categoryId"]);

        appManager.loadView("category", context, false, categoryModel.byId, categoryModel.currentId())
        .then(function () {
            console.log(+context.params["categoryId"]);
            $(".btn-section-show").on("click", function (e) {
                context.redirect('/#/category/' + categoryModel.currentId() + '/sections/' + $(e.currentTarget).attr("id"));
            });

            $(".btn-section-add").on("click", function () {
                context.redirect("/#/add/section");
            });
            return appManager.loadView("section", context, Constants.CATEGORY_CONTENT_WRAPPER, sectionModel.getById, sectionId);
        })
       
          .then(function () {
              sectionModel.currentId(sectionId);
              return true;
              console.log("Hooray");
          }, function (err) {
              var id = categoryModel.currentId() ? categoryModel.currentId() : 1;
              categoryModel.currentId(id);
              console.log(err);
              context.redirect("/#/category/" + categoryModel.currentId());
          })
          .then(function () {
              $(".btn-topic-show").on("click", function (e) {

                  var target = e.currentTarget;
                  // TODO: Save on localeStorage for better behave on refresh
                  topicModel.currentId(+$(target).attr("id"));
                  context.redirect('/#/category/' + categoryModel.currentId() + '/sections/' + sectionModel.currentId() + "/topics/" + topicModel.currentId());
                  //context.redirect("/#/topics/" + topicModel.currentId());
              });
          });
    }

    function add(context) {
        console.log("in section");
        appManager.loadView("add-section", context, Constants.CATEGORY_CONTENT_WRAPPER)
            .then(function (res) {
                console.log("after app");
                $("#btn-section-add").on("click", function (e) {
                    console.log("click?");
                    var newSection = {
                        Name: $("#tb-section-name").val(),
                        Description: $("#tb-section-description").val(),
                        CategoryId: categoryModel.currentId()
                    };

                    sectionModel.add(newSection)
                        .then(function () {
                            var id = categoryModel.currentId() ? categoryModel.currentId() : 1;
                            categoryModel.currentId(id);
                            console.log(id);
                            context.redirect("/#/category/" + categoryModel.currentId());
                        }, function (err) {
                            alert(err);
                        });
                });
            }, function (err) {
                alert(err);
            });

    }

    return {
        byId: byId,
        add: add
    };
}())