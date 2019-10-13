using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Print
    {
        //控制控制台输出还是文件输出
        public static void print(Dictionary<string, int> result, String outPath)
        {
            if (outPath != null)
            {
                //文件输出
                StreamWriter streamWriter = new StreamWriter(outPath);
                foreach (var s in result)
                {
                    streamWriter.WriteLine(s.Key + ":" + s.Value);
                }
                Console.WriteLine("已成功输出至" + outPath + "文档");
                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            else
            {
                //控制台输出
                foreach (var s in result)
                {
                    Console.WriteLine(s.Key + ":" + s.Value);
                }
            }
        }
    }
}
