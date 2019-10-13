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
        //解析文件，统计字符数。
        public static string countChar(StreamReader sr)
        {
            string txt = null;
            //重置文件流指针为文件开头位置
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            txt = sr.ReadToEnd();
            //返回对应文本的字符串
            return txt;
        }
    }
}
