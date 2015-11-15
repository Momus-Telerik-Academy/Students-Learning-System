var sidebarController = (function() {


    function config() {

        console.log("nanan");

        //$('#mainNav').css('background-image', 'url(../images/header.jpg)');

        var trigger = $(".hamburger"),
            overlay = $(".overlay"),
            isClosed = false;

        trigger.click(function() {
            hamburger_cross();
            console.log("clicked");
        });

        overlay.show();
        trigger.removeClass("is-closed");
        trigger.addClass("is-open");
        isClosed = true;

        $("[data-toggle=\"offcanvas\"]").click(function() {
            $("#wrapper-sections").toggleClass("toggled");
        });
    }

    return {
        config: config()
    };
}());