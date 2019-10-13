using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordCount
{
    public class WordUti
    {
        //pattern1正则表达式表示的是任意非英文数字字符。
        private  static string pattern1 = @"\W+";
        //pattern2正则表达式代表的是前面至少含有4个字母后面再接上任意的字母或者是数字。
        private  static string pattern2 = @"^[a-zA-Z]{4,}[a-zA-Z0-9]*$";
        //正则表达式。
        private  static Regex regex = null;
        //txt文件的字符串。
        private  static string txt = null;
        //单词集合。
        private static List<string> words = new List<string>();

        //统计行数。
        public static int CountLine(StreamReader sr)
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
        //统计字符数。
        public static int CountChar(StreamReader sr)
        {
            //重置文件流指针为文件开头位置
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            txt = sr.ReadToEnd();
            return txt.Length;
        }

        //统计单词数。
        public static List<string> CreateWords(string txt)
        {
            regex = new Regex(pattern1);
            string[] output = regex.Split(txt);
            regex = new Regex(pattern2);
            foreach (string s in output)
            {
                if (regex.IsMatch(s))
                {
                    //转换为小写字母。
                    words.Add(s.ToLower());
                }
            }
            return words;
        }


        //得到单词以及对应的数目存入泛型数组keyValues
        public static Dictionary<string,int> createDic(List<string> words)
        {
           
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            //如果这个泛型集合里面如果有这个单词的话就数量增加如果没有这个单词的话就把它加入这个集合
            foreach (string s in words)
            {
                if (keyValues.ContainsKey(s))
                {
                    keyValues[s]++;
                }
                else
                {
                    keyValues.Add(s, 1);
                }
            }
            return keyValues;
        }

        //词组统计
        public static void wordgroup(int m, List<string> words, ref string res)
        {
            //存入最开始得到的词组
            List<String> now = new List<string>();
            //用于消去重复的词组
            Dictionary<string, int> group = new Dictionary<string, int>();
            //用来得到最后的词组
            string Result = null;
            //得到总的单词数目
            int L = words.Count();
            //得到词组
            for (int i = 0; i <= L - m; i++)
            {
                string moment = null;
                for (int j = i; j < i + m; j++)
                {
                    moment += words[j] + " ";
                }
                //将词组加入到字符串列表now中
                if (moment != null)
                    now.Add(moment);
            }
            //将字符串列表加入到集合
            foreach (string s in now)
            {
                if (group.ContainsKey(s))
                {
                    group[s]++;
                }
                else
                {
                    group.Add(s, 1);
                }
            }
            //添加结果集合
            foreach (KeyValuePair<string, int> matching in group)
            {
                res += matching.Key + " : " + matching.Value + "\r\n";
            }
        }

        //将单词进行词频排序并且输出前十个词频的单词
        public static void SortKey(Dictionary<string, int> keyValues, ref string result,int count)
        {
            //对该集合进行字典序排序
            keyValues = keyValues.OrderBy(o => o.Key, StringComparer.Ordinal).ToDictionary(p => p.Key, o => o.Value);
            //单词频数集合
            List<int> value = new List<int>();
          
            foreach(int i in keyValues.Values)
            {
                value.Add(i);
            }
            //进行单词频数排序
            value.Sort((x, y) => -x.CompareTo(y));
            //如果参数是-1 则默认输出前10个
            if (count == -1)
            {
                count = 10;
            }
            //次数变量
            int index = 0;
            foreach(var s in keyValues)
            {
                //找出单词频数为最高的单词
                if (s.Value.Equals(value[0])&&index<=count)
                {
                    //提取对应的单词以及出现的频数
                   
                    result+=s.Key+":"+s.Value+"\r\n";
                    index++;
                }
            }
            //顺序提取单词频数前10的单词 同频的按照字典序排列
            for(int i = 1; i < value.Count&&index<=count; i++)
            {
                if (value[i] == value[i - 1])
                    continue;
                foreach(var s in keyValues)
                {
                    if (s.Value.Equals(value[i]))
                    {
                        if (index < count)
                        {
                            //按照制定格式输出对应的写入流中
                            result += s.Key + ":" + s.Value+"\r\n";
                            index++;
                        }
                        else
                            break;
                    }
                }
            }       
        }

        //控制控制台输出还是文件输出
        public static void Print(Dictionary<string,int> result,String outPath)
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
