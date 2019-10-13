using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class CountLine
    {
        //返回行数
        public static int countLine(StreamReader sr)
        {
            //重置文件流指针为文件开头位置
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //行数
            int line = 0;
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                line++;

            }
            return line;
        }
    }
}
