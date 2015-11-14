var uploadController = (function () {

    function upload(context) {

        appManager.loadView('test-upload', context, false, false, false)
        .then(function () {
            $('#upload').submit(function () {

                // To keep things simple in this example, we'll
                // use the FormData XMLHttpRequest Level 2 object (which
                // requires modern browsers e.g. IE10+, Firefox 4+, Chrome 7+, Opera 12+ etc).
                var formData = new FormData();

                // We'll grab our file upload form element (there's only one, hence [0]).
                var opmlFile = $('#opmlFile')[0];

                // If this example we'll just grab the one file (and hope there's at least one).
                formData.append("opmlFile", opmlFile.files[0]);

                // Now we can send our upload!
                $.ajax({
                    url: 'http://localhost:56350/api/testupload', // We'll send to our Web API UploadController
                    data: formData, // Pass through our fancy form data

                    // To prevent jQuery from trying to do clever things with our post which
                    // will break our upload, we'll set the following to false
                    cache: false,
                    contentType: false,
                    processData: false,

                    // We're doing a post, obviously.
                    type: 'POST',

                    success: function () {
                        // Success!
                        alert('Woot!');
                    }
                });

                // Returning false will prevent the event from
                // bubbling and re-posting the form (synchronously).
                return false;
            });

        })
        // Hook into the form's submit event.
       
    }

    return {
    upload: upload
    }

}())