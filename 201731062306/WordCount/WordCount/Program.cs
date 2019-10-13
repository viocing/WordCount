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
            //设置读取路径变量
            String Inpath ="ming.txt";
            String Outpath = "out.txt";
            //默认讲标志量设为-1
            int count = -1;
            //设置读取词组的个数
            int group = -1;
            //遍历命令参数
            count = 5;
            group= 5;
            //路径读取失败
            if (Inpath == null)
            {
                Console.Write("未输入文档路径");
                Environment.Exit(404);
            }
            else if (!Inpath.EndsWith(".txt"))
            {
                Console.Write("文档格式不正确,请使用txt文档");
                Environment.Exit(404);
            }
            else
            {
                try
                {
                    StreamReader streamReader = new StreamReader(Inpath);
                    //封存结果的一个集合
                    Dictionary<string, int> result = new Dictionary<string, int>();
                    //得到文本字符串
                    string txt = CountChar.countChar(streamReader);
                    //统计字符数
                    result.Add("characters",txt.Length);
                    //得到符合要求的英语单词集合
                    List<string> words = CountWords.CreateWords(streamReader, txt);
                    //统计单词数
                    result.Add("words", words.Count);
                    //统计行数
                    result.Add("lines", CountLine.countLine(streamReader));
                    //Dictionary<string,int> 也是一个泛型集合，得到对应的单词以及单词的数量
                    Dictionary<string, int> keyValues = GetDic.createDic(streamReader, words);
                    //得到频数前n的单词及频数封装到result集合里
                    GetRes.SortKey(keyValues, result, count);
                    if (group != -1)
                    {
                        WordGroup.wordgroup(group, words, result);
                    }
                    Print.print(result, Outpath);
                }catch(Exception e)
                {
                    Console.Write("文件读取异常，未找到该资源，请检查输入");
                    Environment.Exit(404);
                }
            }
        }
       
    }
    
}
