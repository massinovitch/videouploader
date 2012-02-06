using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoUploader.Ftp
{
    class FileStruct
    {
        private string flags;//les droits de lecture

        public string Flags
        {
            get { return flags; }
            set { flags = value; }
        }
        private string owner;//propriètaire

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        private string group;// le groupe

        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        private bool isDirectory;

        public bool IsDirectory
        {
            get { return isDirectory; }
            set { isDirectory = value; }
        }
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
