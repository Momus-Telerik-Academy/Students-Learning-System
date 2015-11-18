var uploadController = (function () {

    function upload(id, file) {
        console.log('upload');
        var formDataFile = file;
        if (!formDataFile) {
            var formData = new FormData();
            var opmlFile = $('#opmlFile')[0];
            console.log(opmlFile);
            if (!opmlFile || !opmlFile.files[0]) {
                return false;
            }

            formData.append("opmlFile", opmlFile.files[0]);
            formDataFile = formData;
           
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