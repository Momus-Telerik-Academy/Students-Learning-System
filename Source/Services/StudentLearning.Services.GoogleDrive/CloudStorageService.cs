namespace StudentsLearning.Services.GoogleDrive
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Models;
    using Contracts;
    using System.Collections.Generic;
    using System.Net;
    using System;

    public class CloudStorageService : ICloudStorageService
    {
        private const string CLIENT_ID = "557664026130-pb19tq4ign0mltsev1aboc58pcvq21mc.apps.googleusercontent.com";

        private const string CLIENT_SECRET = "BQzdej71HpYxrg0f7OujyRIC";

        private const string ROOT_DIRECTORY_ID = "0B9xztR8jvpkhblZiZ3lHQnlRcWc";

        private DriveService service;

        public CloudStorageService()
        {
           // this.Service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "E-Academy");
            // this.CreateDirectory();
        }

        //public DriveService Service
        //{
        //    get
        //    {
        //        return this.service;
        //    }

        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new System.ArgumentException();
        //        }
        //        this.service = value;
        //    }
        //}

        //public ZipFileGoogleDriveResponseModel Upload(ZipFileGoogleDriveRequestModel uploadFile)
        //{
        //    var body = new File();
        //    body.Title = uploadFile.OriginalName;
        //    body.MimeType = "application/zip";
        //    body.Description = "test";

        //    body.Parents = new List<ParentReference> { new ParentReference() { Id = ROOT_DIRECTORY_ID } };

        //    var request = this.Service.Files.Insert(body, uploadFile.Content, "application/zip");
        //    request.Upload();

        //    File file = request.ResponseBody;
        //    var res = new ZipFileGoogleDriveResponseModel { Id = file.Id, EmbededLink = file.EmbedLink, DownloadLink = file.DownloadUrl };
        //    return res;
        //}

        //public File CreateDirectory()
        //{
        //    File NewDirectory = null;

        //    File body = new File();
        //    body.Title = "E-Academy-Materials";
        //    body.Description = "Directory for hosting zip files of topics";
        //    body.MimeType = "application/vnd.google-apps.folder";
        //    body.Parents = new List<ParentReference>() { new ParentReference() { Id = ROOT_DIRECTORY_ID } };

        //    try
        //    {
        //        FilesResource.InsertRequest request = this.service.Files.Insert(body);
        //        NewDirectory = request.Execute();
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("An error occurred: " + e.Message);
        //    }

        //    return NewDirectory;
        //}

    }
}
