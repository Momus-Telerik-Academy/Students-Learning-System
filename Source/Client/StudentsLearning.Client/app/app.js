(function () {

    $(window).on("load", function () {
        console.log("reloaded");
        appManager.toggleUserState();
    });

    var sammyApp = Sammy("#main-content", function () {

        // this.get('#/', {controller.method});
        this.get("#/", homeController.startUp);
        this.get("#/categories", categoriesController.all);
        this.get("#/about", homeController.about);
        this.get("#/contact", homeController.contact);
        this.get("#/category/:categoryId/sections/:sectionId/topics/:topicId", topicsController.byId);
        this.get("#/category/:categoryId", categoriesController.current);
        this.get("#/category/:categoryId/sections/:sectionId", sectionsController.byId);
        this.get("#/add/category", categoriesController.add);
        this.get("#/add/section", sectionsController.add);
        this.get("#/add/topic", topicsController.add);
        this.get("#/login", userController.login);
        this.get("#/register", userController.register);
        this.get("#/logout", userController.logout);
        this.get("#/test", uploadController.upload);
        this.get("#/topic/edit/:id", topicsController.edit);
    });


    $(function () {
        sammyApp.run("#/");
    });
}())