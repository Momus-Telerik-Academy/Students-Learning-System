using NUnit.Framework;
using GoogleDrive.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleDrive.Api.Tests
{
    using System.Threading.Tasks;


    using Moq;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;

    using Google_Drive_Api_dotnetTests.Mocks;

    [TestFixture()]
    public class DaimtoGoogleDriveHelperTests
    {
        private static Mock<DriveService> DriveServiceMock;

        private static DriveServiceMock MockDriveService;


        [TestFixtureSetUp]
        public void Init()
        {
            //MockDriveService=new DriveServiceMock();
            DriveServiceMock = new Mock<DriveService>();
            Func<byte[]> func = delegate { return new byte[] { }; };
            DriveServiceMock.Setup(m => m.HttpClient.GetByteArrayAsync(It.IsAny<string>())).Returns(new Task<byte[]>(func));
            DriveServiceMock.Setup(m => m.Files.Get(It.IsAny<string>()).Execute()).Returns(new File() { DownloadUrl = string.Empty });
        }

        [Test()]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "The ID of the file to download can not be empty!")]
        public void DownloadFileByNullIdShouldThrowTest()
        {

            DaimtoGoogleDriveHelper.DownloadFileById(DriveServiceMock.Object, " ", "test");
            //DaimtoGoogleDriveHelper.DownloadFileById(MockDriveService, " ", "test");
        }
    }
}