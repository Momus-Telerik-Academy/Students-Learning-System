using Google.Apis.Drive.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Drive_Api_dotnetTests.Mocks
{
    using Google.Apis.Services;

    class FileResourceMock
    {
        private IClientService service;

        public FileResourceMock(IClientService service)
        {
            this.service = service;
        }

        public AboutResource.GetRequest Get(string fileId)
        {
            return new GetRequestMock(service);
        }
    }
}
