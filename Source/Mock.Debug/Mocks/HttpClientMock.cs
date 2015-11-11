namespace Mock.Debug.Mocks
{
    using System;
    using System.Threading.Tasks;

    public class HttpClientMock//:HttpClient
    {
        public virtual Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            Func<byte[]> func = delegate { return new byte[] { }; };
            return new Task<byte[]>(func);
        }
    }
}
