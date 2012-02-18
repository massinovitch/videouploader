using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace VideoUploader.Log
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log.Info("massinissa");
        }
    }
}
