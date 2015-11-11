using Google.Apis.Drive.v2;
using Google.Apis.Services;

namespace GoogleDrive.Api
{
    public interface IDriveService : IClientService
    {
        FilesResource Files { get; }
    }
}
