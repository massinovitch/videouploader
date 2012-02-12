using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace VideoUploader.Ftp
{
    class FTP
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        /*
         *  here is format of string srcFilePath : @"massi.txt" or @"exemple/massi/massi.txt"
         *  here is format of string destFilePath : @"c:\massi.txt"
        */
        public void Download(string srcFilePath, string destFilePath)
        {
            try
            {
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + srcFilePath);
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                reqFTP.Proxy = null;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream fs = new FileStream(destFilePath, FileMode.Create);

                byte[] buffer = new byte[2000];
                int read = 0;

                do
                {
                    read = responseStream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, read);
                    fs.Flush();
                } while (!(read == 0));

                response.Close();
                responseStream.Close();
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         *  here is format of string srcFilePath : "c:\massi.txt"
         *  here is format of string destFilePath : @"massi.txt" or @"exemple/massi/massi.txt"@
        */
        public void Upload(string srcFilePath, string destFilePath)
        {
            try
            {
                FtpWebRequest reqFTP;
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + destFilePath);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                // By default KeepAlive is true, where the control connection is not closed
                // after a command is executed.
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

                // Stream to which the file to be upload is written
                FileStream srcStream = File.OpenRead(srcFilePath);
                // Stream to which the file to be upload is written
                Stream destStream = reqFTP.GetRequestStream();

                // The buffer size is set to 2kb
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                // Read from the file stream 2kb at a time
                int contentLen = srcStream.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    destStream.Write(buff, 0, contentLen);
                    contentLen = srcStream.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                srcStream.Close();
                destStream.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         *  here is format of string destFilePath : @"exemple/massi"
         *  renvoi list de répertoires et de fichiers qui sont dans directoryPath
        */
        public FileStruct[] GetListDirectories(String directoryPath)
        {
            try
            {
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + directoryPath + "/");
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                //WebProxy wproxy = new WebProxy("HAL-SVIP.MC2.RENAULT.FR");
                //wproxy.Credentials = new NetworkCredential("p054122", "MSH15MSH");
                reqFTP.Proxy = null;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                String content = reader.ReadToEnd();
                //il renvoie la liste des directories et fichiers en tant que chaine séparé par \r\n
                ParseListDirectory parseListDirectory = new ParseListDirectory();
                FileStruct[] directoriesAndFiles = parseListDirectory.GetList(content);
                reader.Close();
                response.Close();
                stream.Close();
                return directoriesAndFiles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         *  here is format of string destFilePath : @"exemple/massi"
        */
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                foreach (FileStruct fileOrDir in GetListDirectories(directoryPath))
                {
                    if (fileOrDir.IsDirectory)
                    {
                        DeleteDirectory(directoryPath + "/" + fileOrDir.Name);
                    }
                    else
                    {
                        DeleteFile(directoryPath + "/" + fileOrDir.Name);
                    }
                }
                DeleteDirectoryEmpty(directoryPath);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*
         *  here is format of string destFilePath : @"exemple/massi"
         *  supprimer le dossier quand il est vide
        */
        public void DeleteDirectoryEmpty(string directoryPath)
        {
            try
            {
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + directoryPath);
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                reqFTP.Proxy = null;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
         *  here is format of string destFilePath : @"exemple/massi/massi.txt"
        */
        public void DeleteFile(string filePath)
        {
            try
            {
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + filePath);
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                reqFTP.Proxy = null;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         *  here is format of string oldDirectoryPath : @"exemple/massi"
         *  here is format of string newDirectoryName : malik
        */
        public void RenameDirectory(string oldDirectoryPath, string newDirectoryName)
        {
            try
            {
                Uri serverUri = new Uri("ftp://" + this.Server + "/" + oldDirectoryPath);
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(this.Username, this.Password);
                reqFTP.Proxy = null;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newDirectoryName;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
