namespace Mock.Debug.Mocks
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Services;

    public class FileResourceMock
    {
        private IClientService service;

        public FileResourceMock()
        {
            //this.service = service;
        }

        public FileResourceMock(IClientService service)
        {
            this.service = service;
        }

        public virtual GetRequestMock Get(string fileId)
        {
            return new GetRequestMock();
        }
    }
}
