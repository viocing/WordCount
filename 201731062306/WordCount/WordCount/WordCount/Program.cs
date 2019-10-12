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
            if(args.Length!=0)
            {
                path = args[0];
            }
            // StreamWriter 专门用来处理文本文件的类，可向文件写入字符串
            StreamWriter streamWriter = new StreamWriter("demo.txt");
            //将characters words lines 写入到文件ning.txt当中
            //统计字符数
            string txt = CountChar.countChar(path);
            Console.WriteLine("characters: " + txt.Length);
            streamWriter.WriteLine("characters: " + txt.Length);
            //统计单词数
            List<string> words = CreateWords.Createwords(txt);
            Console.WriteLine("words: " + words.Count);
            streamWriter.WriteLine("words: " + words.Count);
            //统计行数
            Console.WriteLine("lines: " + CountLine.ountLine(path));
            streamWriter.WriteLine("lines: " + CountLine.ountLine(path));
            //Dictionary<string,int> 也是一个泛型集合，得到对应的单词以及单词的数量
            Dictionary<string, int> keyValues = CreateDic.createDic(words);
            //将单词按照字典序排序过后输出
            SortKey.Sortkey(keyValues, streamWriter);
            Console.ReadKey();
        
        }
    }
}
