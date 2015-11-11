namespace Mock.Debug.Mocks
{
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Services;

    public class GetRequestMock//:AboutResource.GetRequest
    {
        /*public GetRequestMock(IClientService service)
            : base(service)
        {
        }*/

        public virtual File Execute()
        {
            return new File() { DownloadUrl = string.Empty };
        }
    }
}
