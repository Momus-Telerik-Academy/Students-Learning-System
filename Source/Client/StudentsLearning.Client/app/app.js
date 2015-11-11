(function () {
    var sammyApp = Sammy("#main-content", function () {

        // this.get('#/', {controller.method});
        this.get('#/', homeController.startUp);
        this.get('#/category/:id', categoriesController.current)
        this.get('#/sections/:id', sectionsController.byId);
        this.get('#/add/category', categoriesController.add)
        this.get('#/add/section', sectionsController.add)
        this.get('#/topics/:id', topicsController.byId)
    });


    $(function () {
        sammyApp.run('#/');
    });
}())