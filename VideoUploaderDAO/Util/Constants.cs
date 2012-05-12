using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;

namespace VideoUploaderDAO.Util
{
    public sealed class Constants
    {
        public static readonly Hashtable factoryPattern = (Hashtable)ConfigurationManager.GetSection("FactoryPattern");
        public static readonly String factoryPatternMySql = factoryPattern["mySql"].ToString();
    }
}
