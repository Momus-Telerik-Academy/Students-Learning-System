using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_Drive_Api_dotnetTests.Mocks
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Services;

    class GetRequestMock:AboutResource.GetRequest
    {
        public GetRequestMock(IClientService service)
            : base(service)
        {
        }

        public File Execute()
        {
            return new File() { DownloadUrl = string.Empty };
        }
    }
}
