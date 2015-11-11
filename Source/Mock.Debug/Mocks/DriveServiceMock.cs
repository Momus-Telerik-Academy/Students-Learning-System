namespace Mock.Debug.Mocks
{
    using Google.Apis.Drive.v2;

    public class DriveServiceMock:DriveService
    {
        public virtual HttpClientMock HttpClient
        {
            get
            {
                return new HttpClientMock();
            }
        }
        
        public virtual FileResourceMock Files
        {
            get
            {
                return new FileResourceMock(this);
            }
        }
        
    }
}
