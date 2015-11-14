var htmlElementCreator = (function() {

    function createForm($parent, itemName, properties) {
        var $item = $("<div/>").addClass("item")
            .css("display", "initial");

        for (var i = 0; i < properties.length; i++) {
            $("<input/>")
                .addClass("form-control")
                .addClass("col-md-6")
                .addClass(itemName + "-" + properties[i])
                .attr("placeholder", properties[i].replace("-", " "))
                .css("width", "20%")
                .appendTo($item);

            $parent.append($item);
        }
    }


    function createButton($parent, text, id) {
        return $("<button/>")
            .text(text)
            .addClass("btn")
            .addClass("btn-primary")
            .attr("id", id)
            .appendTo($parent);
    }

    function createUploadForm() {

    }

    return {
        createButton: createButton,
        createForm: createForm
    };
}())