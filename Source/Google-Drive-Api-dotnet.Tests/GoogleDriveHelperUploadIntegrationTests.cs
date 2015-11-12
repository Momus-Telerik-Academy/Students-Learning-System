using NUnit.Framework;
using GoogleDrive.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleDrive.Api.Tests
{
    using System.Security.Authentication;

    using Google.Apis.Drive.v2;
    using System.Net;

    [TestFixture()]
    public class GoogleDriveHelperUploadIntegrationTests
    {
        private static string clientID;

        private static string clientSecret;

        private static string rootDirectoryID;

        private const string TestFile = "Recovery.txt";

        private static string testFileId;

        private static DriveService service;

        [TestFixtureSetUp]
        public void Init()
        {
            clientID = "122586258718-lbpu876ap5o81fib62egce3aiqa87bpu.apps.googleusercontent.com";
            clientSecret = "JxjLSk0O0tYNjAeoW39qBGbH";
            rootDirectoryID = "0B9-BhHxB4VqLcmh1TXZYV1NkZGc";

            service = Authentication.AuthenticateOauth(clientID, clientSecret, Environment.UserName);
        }

        [Test()]
        public void UploadValidFileTest()
        {
            var fileName = TestFile;
            Google.Apis.Drive.v2.Data.File result = DaimtoGoogleDriveHelper.UploadFile(service, fileName, rootDirectoryID);

            testFileId = result.Id;

            // name should be as set
            Assert.AreEqual(result.OriginalFilename, fileName);

            // should exist (not throw)
            DaimtoGoogleDriveHelper.GetFileById(service, result.Id);
        }

        [Test()]
        [ExpectedException(typeof(AuthenticationException), ExpectedMessage = "Authentication error! Please use the Authentication class to initialize the Google Drive service!")]
        public void UploadUnauthenticatedServiceShouldThrowTest()
        {
            DriveService unauthenticated=new DriveService();

            var fileName = TestFile;
            DaimtoGoogleDriveHelper.UploadFile(unauthenticated, fileName, rootDirectoryID);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "Parent folder ID can not be empty!")]
        public void UploadEmptyDirectoryIdShouldThrowTest(string id)
        {
            var fileName = TestFile;
            DaimtoGoogleDriveHelper.UploadFile(service, fileName, id);
        }

        [TestCase("lizzaARD")]
        [ExpectedException(typeof(WebException), ExpectedMessage = "Directory not found!")]
        public void UploadInvalidIdShouldThrowTest(string id)
        {
            var fileName = TestFile;
            DaimtoGoogleDriveHelper.UploadFile(service, fileName, id);
        }

        [TestFixtureTearDown]
        public void Clean()
        {
            if (!string.IsNullOrEmpty(testFileId))
            {
                try
                {
                    DaimtoGoogleDriveHelper.DeleteFileById(service, testFileId);
                }
                catch
                {
                    
                }
            }

        }
    }
}