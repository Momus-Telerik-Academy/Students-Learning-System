(function () {

    $(window).on('load', function () {
        console.log('reloaded');
        appManager.toggleUserState();
    });

    var sammyApp = Sammy("#main-content", function () {
  
        // this.get('#/', {controller.method});
        this.get('#/', homeController.startUp);
        this.get('#/category/:id', categoriesController.current)
        this.get('#/sections/:id', sectionsController.byId);
        this.get('#/add/category', categoriesController.add);
        this.get('#/add/section', sectionsController.add);
        this.get('#/topics/:id', topicsController.byId);
        this.get('#/login', userController.login);
        this.get('#/register', userController.register);
        this.get('#/logout', userController.logout);
        this.get('#/test', uploadController.upload);
        this.get('#/topic/edit/:id', topicsController.edit);
    });


    $(function () {
        sammyApp.run('#/');
    });
}())