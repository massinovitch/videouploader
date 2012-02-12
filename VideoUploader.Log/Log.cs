using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace VideoUploader.Log
{
    //ajouter cette ligne : 	[assembly: XmlConfigurator(ConfigFile = "Config/Log4Net.config", Watch = true)]  dans AssemblyInfo.cs
    public static class Log
    {
        public static ILog MonitoringLogger
        {
            get { return LogManager.GetLogger("MonitoringLogger"); }
        }

        public static ILog ExceptionLogger
        {
            get { return LogManager.GetLogger("ExceptionLogger"); }
        }
    }
}
