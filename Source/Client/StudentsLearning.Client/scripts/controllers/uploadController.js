var uploadController = (function () {

    function upload(id, formDataFile) {

        if (!formDataFile) {
            var formData = new FormData();
            var opmlFile = $('#opmlFile')[0];

            formData.append("opmlFile", opmlFile.files[0]);
            formDataFile = formData;
        }
        console.log(formData);
        console.log(opmlFile.files[0]);
        if (!opmlFile.files[0]) {
            return false;
        }

        $.ajax({
            url: 'http://localhost:56350/api/topics/upload/' + id,
            data: formDataFile,
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

        return false;
    }

    return {
        upload: upload
    }
}())