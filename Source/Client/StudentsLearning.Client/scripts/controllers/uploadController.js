var uploadController = (function () {

    function upload(id) {
        var formData = new FormData();
        var opmlFile = $('#opmlFile')[0];

        formData.append("opmlFile", opmlFile.files[0]);

        $.ajax({
            url: 'http://localhost:56350/api/topics/upload/' + id,
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'PUT',
            success: function () {

                alert('Debug: Zip uploaded and added to db!');
            },
            error: function (err) {
                console.log(err)
            }
        });

        // Returning false will prevent the event from
        // bubbling and re-posting the form (synchronously).
        return false;
    }



    return {
        upload: upload
    }

}())