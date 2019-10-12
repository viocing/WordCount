using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class CountChar
    {
        //统计字符数。
        public static string countChar(string path)
        {
            string txt;
            //读入。
            StreamReader sr = new StreamReader(path);
            //统计文件的字符数。
            txt = sr.ReadToEnd();
            return txt;
        }
    }
}
