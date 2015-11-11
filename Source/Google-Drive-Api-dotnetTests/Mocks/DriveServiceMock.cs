using Google.Apis.Drive.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Drive_Api_dotnetTests.Mocks
{
    using Google.Apis.Http;
    using System.Net.Http;

    using Google.Apis.Drive.v2.Data;

    public class DriveServiceMock:DriveService
    {
        public HttpClientMock HttpClient
        {
            get
            {
                return new HttpClientMock();
            }
        }

        public override FilesResource Files
        {
            get
            {
                return new FilesResource(this);
            }
        }
    }
}
