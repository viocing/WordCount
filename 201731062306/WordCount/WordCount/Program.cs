using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "ning.txt";
            if (args.Length != 0)
            {
                path = args[0];
            }
            else
            {
                // StreamWriter 专门用来处理文本文件的类，可向文件写入字符串
                StreamWriter streamWriter = new StreamWriter(@"E:\demo.txt");
                //将characters words lines 写入到文件ning.txt当中

                //Dictionary<string,int> 也是一个泛型集合，得到对应的单词以及单词的数量
                Dictionary<string, int> keyValues = WordUti.createDic(path);
                //封存结果的一个集合
                Dictionary<string, int> result = new Dictionary<string, int>();
                //统计字符数
                result.Add("characters: " ,WordUti.CountChar(path));
                //统计单词数
                result.Add("words: ", WordUti.CreateWords(path));
                //统计行数
                result.Add("lines: ", WordUti.CountLine(path));
                //得到频数前十的单词及频数封装到result集合里
                WordUti.SortKey(keyValues, result);
                foreach (var s in result)
                {
                    streamWriter.WriteLine(s.Key + ":" + s.Value);
                    Console.WriteLine(s.Key + ":" + s.Value);
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
           
        }
       
    }
    
}
