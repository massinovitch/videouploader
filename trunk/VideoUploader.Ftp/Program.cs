using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace VideoUploader.Ftp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            FTP ftp = new FTP()
            {
                Server = "192.168.1.15",
                Username = "massi",
                Password = "massi"
            };
            ftp.Download(@"massi.txt", @"c:\massi.txt");
            log.Info("massinissa");
        }
    }
}
