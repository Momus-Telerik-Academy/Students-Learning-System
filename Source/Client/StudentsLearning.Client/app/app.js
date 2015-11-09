(function () {
    var sammyApp = Sammy("#main-content", function () {

        // this.get('#/', {controller.method});
        this.get('#/', categoriesController.all)
        
    });

    $(function () {
        sammyApp.run('#/');
    });
}())