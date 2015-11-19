var sectionsController = (function () {


    function byId(context) {
        var sectionId = +context.params["sectionId"];
        sectionModel.currentId(sectionId);
        categoryModel.currentId(+context.params["categoryId"]);

        appManager.loadView("category", context, false, categoryModel.byId, categoryModel.currentId())
        .then(function () {
            eventManager.attachShowSection(context);
            eventManager.attachAddSection(context);

            return appManager.loadView("section", context, Constants.CATEGORY_CONTENT_WRAPPER, sectionModel.getById, sectionId);
        })

          .then(function () {
              sectionModel.currentId(sectionId);
              return true;
          }, function (err) {
              var id = categoryModel.currentId() ? categoryModel.currentId() : 1;
              categoryModel.currentId(id);
              context.redirect("/#/category/" + categoryModel.currentId());
          })
          .then(function () {
              eventManager.attachShowTopic(context);
          });
    }

    function add(context) {
        var sectionId = context.params["sectionId"];
        sectionModel.currentId(sectionId);
        categoryModel.currentId(+context.params["categoryId"]);
        if (appManager.checkIfLogged() === false) {
            toastr.warning('You must be logged in to add sections');
        }
        else {
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
                                context.redirect("/#/category/" + categoryModel.currentId());
                                toastr.success('Successfully added new category ' + newSection.Name);
                            }, function (err) {
                                toastr.error("Invalid data");
                            });
                    });
                }, function (err) {
                    
                });
        }

    }

    return {
        byId: byId,
        add: add
    };
}())