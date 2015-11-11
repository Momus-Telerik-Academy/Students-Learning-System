using NUnit.Framework;
using GoogleDrive.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleDrive.Api.Tests
{
    using Google.Apis.Drive.v2;

    [TestFixture()]
    public class DaimtoGoogleDriveHelperIntegrationTests
    {
        private static string clientID;

        private static string clientSecret;

        private static string rootDirectoryID;

        private static DriveService service;

        [TestFixtureSetUp]
        public void Init()
        {
            clientID = "122586258718-lbpu876ap5o81fib62egce3aiqa87bpu.apps.googleusercontent.com";
            clientSecret = "JxjLSk0O0tYNjAeoW39qBGbH";
            rootDirectoryID = "0B9-BhHxB4VqLSE9BNlV0NFNsd2M";

            service = Authentication.AuthenticateOauth(clientID, clientSecret, Environment.UserName);
        }

        [Test()]
        public void UploadValidFileTest()
        {
            var fileName = "Recovery.txt";
            Google.Apis.Drive.v2.Data.File result = DaimtoGoogleDriveHelper.UploadFile(service, fileName, rootDirectoryID);

            // name should be as set
            Assert.AreEqual(result.OriginalFilename, fileName);

            // should exist
            DaimtoGoogleDriveHelper.DownloadFileById(service, result.Id, "download.txt");
        }
    }
}