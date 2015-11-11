namespace GoogleDrive.Api
{
    #region

    using System;

    #endregion

    //source: https://github.com/LindaLawton/Google-Dotnet-Samples/tree/master/Google-Drive/Google-Drive-Api-dotnet
    //TODO: delete demo and make the project class library
    public class Program
    {
        private const string CLIENT_ID = "122586258718-lbpu876ap5o81fib62egce3aiqa87bpu.apps.googleusercontent.com";

        private const string CLIENT_SECRET = "JxjLSk0O0tYNjAeoW39qBGbH";

        private const string ROOT_DIRECTORY_ID = "0B9-BhHxB4VqLSE9BNlV0NFNsd2M";

        public static void Main()
        {
            // Connect with Oauth2 Ask user for permission
            var service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, Environment.UserName);

            if (service == null)
            {
                Console.WriteLine("Authentication error");
                Console.ReadLine();
            }

            // Upload a file
            var newFile = DaimtoGoogleDriveHelper.UploadFile(service, "test-image.jpg", ROOT_DIRECTORY_ID);

            //newFile.AlternateLink
            // Find a file
            var get = DaimtoGoogleDriveHelper.GetFileById(service, newFile.Id);
            Console.WriteLine("File name: {0}", get.OriginalFilename);

            // Download a file
            bool isDownloaded = DaimtoGoogleDriveHelper.DownloadFileById(service, newFile.Id, "Downloaded.txt");
            Console.WriteLine("File downloadedloaded: {0}", isDownloaded);

            //Get download link (probably temporary)
            string url = DaimtoGoogleDriveHelper.GetDownloadUrlById(service, newFile.Id);
            Console.WriteLine("Open in Drive link: {0}", url);

            Console.WriteLine("Press any key to continie. All new generated files will be deleted!");
            Console.ReadLine();

            // Clear test
            string deleteResult = DaimtoGoogleDriveHelper.DeleteFileById(service, newFile.Id);
            Console.WriteLine(deleteResult);
        }
    }
}