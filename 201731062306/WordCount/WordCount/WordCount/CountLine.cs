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
        //统计行数。
        public static int ountLine(string path)
        {
            int line = 0;//行数。
            string str = "";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {
                line++;

            }
            return line;
        }
    }
}
