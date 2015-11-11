(function () {
    var sammyApp = Sammy("#main-content", function () {

        // this.get('#/', {controller.method});
        this.get('#/', homeController.startUp);
        this.get('#/category/:id', categoriesController.current)
        this.get('#/sections/:id', sectionsController.byId);

    });


    $(function () {
        sammyApp.run('#/');
    });
}())