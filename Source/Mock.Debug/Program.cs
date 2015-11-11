using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using GoogleDrive.Api;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Debug
{
    using Mock.Debug.Mocks;

    class Program
    {
        //private static Mock<DriveService> DriveServiceMock;

        private static DriveServiceMock MockDriveService;

        private static Mock<DriveServiceMock> MockMockMockMock;

        static void Main(string[] args)
        {
            
            //DriveServiceMock = new Mock<DriveService>();
            //MockDriveService = new DriveServiceMock();

            //var obj = DriveServiceMock.Object;
            //var req = new GetRequestMock(obj);
            //Func<byte[]> func = delegate { return new byte[] { }; };
            //DriveServiceMock.Setup(m => m.Files.Get(It.IsAny<string>())).Returns(req);
            //DriveServiceMock.Setup(m => m.HttpClient.GetByteArrayAsync(It.IsAny<string>())).Returns(new Task<byte[]>(func));

            //DaimtoGoogleDriveHelper.DownloadFileById(DriveServiceMock.Object, " ", "test");
            //DaimtoGoogleDriveHelper.DownloadFileById(MockDriveService, " ", "test");

            /*MockMockMockMock=new Mock<DriveServiceMock>();
            Func<byte[]> func = delegate { return new byte[] { }; };
            MockMockMockMock.Setup(m => m.HttpClient.GetByteArrayAsync(It.IsAny<string>()))
                .Returns(new Task<byte[]>(func));
            MockMockMockMock.Setup(m => m.Files.Get(It.IsAny<string>()).Execute()).Returns(new File() { DownloadUrl = string.Empty });

            DaimtoGoogleDriveHelper.DownloadFileById(MockMockMockMock.Object, " ", "test");*/
        }
    }
}
