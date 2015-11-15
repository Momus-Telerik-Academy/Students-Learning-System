/*
 * Copyright 2014 Daimto.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace GoogleDrive.Api
{
    #region

    using System;
    using System.IO;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v2;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;

    #endregion

    public class Authentication
    {
        /// <summary>
        ///     Authenticate to Google Using Oauth2
        ///     Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="userName">A string used to identify a user.</param>
        /// <returns></returns>
        public static DriveService AuthenticateOauth(string clientId, string clientSecret, string userName)
        {
            // Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
            string[] scopes =
                {
                    DriveService.Scope.Drive, // view and manage your files and documents
                    DriveService.Scope.DriveAppdata, // view and manage its own configuration data
                    DriveService.Scope.DriveAppsReadonly, // view your drive apps
                    DriveService.Scope.DriveFile, // view and manage files created by this app
                    DriveService.Scope.DriveMetadataReadonly, // view metadata for files
                    DriveService.Scope.DriveReadonly, // view files and documents on your drive
                    DriveService.Scope.DriveScripts
                }; // modify your app scripts

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                var credential =
                    GoogleWebAuthorizationBroker.AuthorizeAsync(
                        new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }, 
                        scopes, 
                        userName, 
                        CancellationToken.None, 
                        new FileDataStore("Students-Learning-System")).Result;

                var service =
                    new DriveService(
                        new BaseClientService.Initializer
                            {
                                HttpClientInitializer = credential, 
                                ApplicationName = "Students-Learning-System-C#-Client"
                            });
                return service;
            }
            catch (Exception ex)
            {
                throw new AuthenticationException(
                    "Failed to authenticate! Please check credentials and internet access!");
            }
        }

        /// <summary>
        ///     Authenticating to Google using a Service account
        ///     Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
        /// </summary>
        /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
        /// <param name="keyFilePath">
        ///     Location of the Service account key file downloaded from Google Developer console
        ///     https://console.developers.google.com
        /// </param>
        /// <returns></returns>
        public static DriveService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {
            // check the file exists
            if (!File.Exists(keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            // Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
            string[] scopes =
                {
                    DriveService.Scope.Drive, // view and manage your files and documents
                    DriveService.Scope.DriveAppdata, // view and manage its own configuration data
                    DriveService.Scope.DriveAppsReadonly, // view your drive apps
                    DriveService.Scope.DriveFile, // view and manage files created by this app
                    DriveService.Scope.DriveMetadataReadonly, // view metadata for files
                    DriveService.Scope.DriveReadonly, // view files and documents on your drive
                    DriveService.Scope.DriveScripts
                }; // modify your app scripts     

            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                var credential =
                    new ServiceAccountCredential(
                        new ServiceAccountCredential.Initializer(serviceAccountEmail) { Scopes = scopes }
                            .FromCertificate(certificate));

                // Create the service.
                var service =
                    new DriveService(
                        new BaseClientService.Initializer
                            {
                                HttpClientInitializer = credential, 
                                ApplicationName = "Students-Learning-System-C#-Client"
                            });
                return service;
            }
            catch (Exception ex)
            {
                throw new AuthenticationException("Failed to authenticate! Please check credentials!");
            }
        }
    }
}