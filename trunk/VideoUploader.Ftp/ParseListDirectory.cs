using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VideoUploader.Ftp
{
    public enum FileListStyle
    {
        UnixStyle,
        WindowsStyle,
        Unknown
    }
    class ParseListDirectory
    {
        /*
         * parse la string récupérée à partir de WebRequestMethods.Ftp.ListDirectoryDetails(datastring) et renvoi list de fichiers et de répertoires
        */
        public FileStruct[] GetList(string datastring)
        {
            try
            {
                List<FileStruct> myListArray = new List<FileStruct>();
                string[] dataRecords = datastring.Split('\n');
                FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
                foreach (string s in dataRecords)
                {
                    if (_directoryListStyle != FileListStyle.Unknown && s != "")
                    {
                        FileStruct f = new FileStruct();
                        f.Name = "..";
                        switch (_directoryListStyle)
                        {
                            case FileListStyle.UnixStyle:
                                f = ParseFileStructFromUnixStyleRecord(s);
                                break;
                            case FileListStyle.WindowsStyle:
                                f = ParseFileStructFromWindowsStyleRecord(s);
                                break;
                        }
                        if (!(f.Name == "." || f.Name == ".."))
                        {
                            myListArray.Add(f);
                        }
                    }
                }
                return myListArray.ToArray(); ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private FileListStyle GuessFileListStyle(string[] recordList)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
            foreach (string s in recordList)
            {
                if (s.Length > 10
                 && Regex.IsMatch(s.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FileListStyle.UnixStyle;
                }
                else if (s.Length > 8
                 && Regex.IsMatch(s.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FileListStyle.WindowsStyle;
                }
            }
            return FileListStyle.Unknown;
        }

        private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
            ///Assuming the record style as 
            /// 02-03-04  07:46PM       <DIR>          Append
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            string dateStr = processstr.Substring(0, 8);
            processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
            string timeStr = processstr.Substring(0, 7);
            processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
            f.CreateTime = DateTime.Parse(dateStr + " " + timeStr);
            if (processstr.Substring(0, 5) == "<DIR>")
            {
                f.IsDirectory = true;
                processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
            }
            else
            {
                string[] strs = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                processstr = strs[1].Trim();
                f.IsDirectory = false;
            }
            f.Name = processstr;  //Rest is name   
            return f;
        }

        private FileStruct ParseFileStructFromUnixStyleRecord(string Record)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
            ///Assuming record style as
            /// dr-xr-xr-x   1 owner    group               0 Nov 25  2002 bussys
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            f.Flags = processstr.Substring(0, 9);
            f.IsDirectory = (f.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //skip one part
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //skip one part
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 8));
            f.Name = processstr;   //Rest of the part is name
            return f;
        }

        private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1)).Trim();
            return retString;
        }
    }
}
