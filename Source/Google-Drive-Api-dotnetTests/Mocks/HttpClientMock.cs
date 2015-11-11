using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Google_Drive_Api_dotnetTests.Mocks
{
    public class HttpClientMock//:HttpClient
    {
        public Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            Func<byte[]> func = delegate { return new byte[] { }; };
            return new Task<byte[]>(func);
        }
    }
}
