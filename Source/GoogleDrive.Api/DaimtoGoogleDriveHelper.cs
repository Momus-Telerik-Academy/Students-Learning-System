namespace GoogleDrive.Api
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;

    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;

    using Microsoft.Win32;

    using File = Google.Apis.Drive.v2.Data.File;

    #endregion

    public class DaimtoGoogleDriveHelper
    {
        /// <summary>
        ///     add a file
        ///     Documentation: https://developers.google.com/drive/v2/reference/files/get
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>
        /// <param name="id">File resource id of the file to download</param>
        /// <param name="saveTo">location of where to save the file including the file name to save it as.</param>
        /// <returns>Is download successful</returns>
        public static bool DownloadFileById(DriveService service, string id, string saveTo)
        {
            var fileResource = service.Files.Get(id).Execute();

            if (!string.IsNullOrEmpty(fileResource.DownloadUrl))
            {
                try
                {
                    var x = service.HttpClient.GetByteArrayAsync(fileResource.DownloadUrl);
                    var arrBytes = x.Result;
                    System.IO.File.WriteAllBytes(saveTo, arrBytes);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return false;
                }
            }

            // The file doesn't have any content stored on Drive.
            return false;
        }

        

        /// <summary>
        ///     Uploads a file
        ///     Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>
        /// <param name="uploadFile">path to the file to upload</param>
        /// <param name="parentDirectoryId">
        ///     Collection of parent folders which contain this file.
        ///     Setting this field will put the file in all of the provided folders. root folder.
        /// </param>
        /// <returns>
        ///     If upload succeeded returns the File resource of the uploaded file
        ///     If the upload fails returns null
        /// </returns>
        public static File UploadFile(DriveService service, string uploadFile, string parentDirectoryId)
        {
            if (System.IO.File.Exists(uploadFile))
            {
                var body = new File();
                body.Title = Path.GetFileName(uploadFile);
                body.Description = "File uploaded by Diamto Drive Sample";
                body.MimeType = GetMimeType(uploadFile);
                body.Parents = new List<ParentReference> { new ParentReference { Id = parentDirectoryId } };

                // File's content.
                var byteArray = System.IO.File.ReadAllBytes(uploadFile);
                var stream = new MemoryStream(byteArray);
                try
                {
                    var request = service.Files.Insert(body, stream, GetMimeType(uploadFile));

                    // request.Convert = true;   // uncomment this line if you want files to be converted to Drive format
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }

            Console.WriteLine("File does not exist: " + uploadFile);
            return null;
        }

        /// <summary>
        ///     Updates a file
        ///     Documentation: https://developers.google.com/drive/v2/reference/files/update
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>
        /// <param name="uploadFile">path to the file to upload</param>
        /// <param name="parentFolderId">
        ///     Collection of parent folders which contain this file.
        ///     Setting this field will put the file in all of the provided folders. root folder.
        /// </param>
        /// <param name="fileId">the resource id for the file we would like to update</param>
        /// <returns>
        ///     If upload succeeded returns the File resource of the uploaded file
        ///     If the upload fails returns null
        /// </returns>
        public static File UpdateFile(DriveService service, string uploadFile, string parentFolderId, string fileId)
        {
            if (System.IO.File.Exists(uploadFile))
            {
                var body = new File();
                body.Title = Path.GetFileName(uploadFile);
                body.Description = "File updated by Diamto Drive Sample";
                body.MimeType = GetMimeType(uploadFile);
                body.Parents = new List<ParentReference> { new ParentReference { Id = parentFolderId } };

                // File's content.
                var byteArray = System.IO.File.ReadAllBytes(uploadFile);
                var stream = new MemoryStream(byteArray);
                try
                {
                    var request = service.Files.Update(body, fileId, stream, GetMimeType(uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }

            Console.WriteLine("File does not exist: " + uploadFile);
            return null;
        }

        /// <summary>
        ///     Create a new Directory.
        ///     Documentation: https://developers.google.com/drive/v2/reference/files/insert
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>
        /// <param name="title">The title of the file. Used to identify file or folder name.</param>
        /// <param name="description">A short description of the file.</param>
        /// <param name="parentDirectoryId">
        ///     Collection of parent folders which contain this file.
        ///     Setting this field will put the file in all of the provided folders. root folder.
        /// </param>
        /// <returns></returns>
        public static File CreateDirectory(
            DriveService service, 
            string title, 
            string description, 
            string parentDirectoryId)
        {
            File newDirectory = null;

            // Create metaData for a new Directory
            var body = new File();
            body.Title = title;
            body.Description = description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference> { new ParentReference { Id = parentDirectoryId } };
            try
            {
                var request = service.Files.Insert(body);
                newDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return newDirectory;
        }

        /// <summary>
        ///     List all of the files and directories for the current user.
        ///     Documentation: https://developers.google.com/drive/v2/reference/files/list
        ///     Documentation Search: https://developers.google.com/drive/web/search-parameters
        /// </summary>
        /// <param name="service">a Valid authenticated DriveService</param>
        /// <param name="search">if Search is null will return all files</param>
        /// <returns>A list of files</returns>
        public static IList<File> GetFiles(DriveService service, string search)
        {
            IList<File> files = new List<File>();

            try
            {
                // List all of the files and directories for the current user.  
                // Documentation: https://developers.google.com/drive/v2/reference/files/list
                var list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = search;
                }

                var filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (var item in filesFeed.Items)
                    {
                        files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);
            }

            return files;
        }

        // TODO: handle exceptions
        public static File GetFileById(DriveService service, string fileId)
        {
            return service.Files.Get(fileId).Execute();
        }

        // TODO: handle exceptions
        public static string GetDownloadUrlById(DriveService service, string fileId)
        {
            return service.Files.Get(fileId).Execute().AlternateLink;
        }

        // TODO: handle exceptions
        public static string DeleteFileById(DriveService service, string fileId)
        {
            string request = service.Files.Delete(fileId).Execute();
            return request;
        }

        private static string GetMimeType(string fileName)
        {
            var mimeType = "application/unknown";
            var ext = Path.GetExtension(fileName).ToLower();
            var regKey = Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }

            return mimeType;
        }
    }
}