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
        public static int CountLine(string path)
        {
            //行数
            int line = 0;
            string str = "";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {
                line++;
            }
            sr.Close();
            return line;
        }

        //统计字符数。
        public static int CountChar(string path)
        {
            StreamReader sr = new StreamReader(path);
            txt = sr.ReadToEnd();
            sr.Close();
            return txt.Length;
        }

        //统计单词数。
        public static int CreateWords(string path)
        {
            CountChar(path);
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
            return words.Count;
        }


        //得到单词以及对应的数目存入泛型数组keyValues
        public static Dictionary<string,int> createDic(string path)
        {
            //读入。
            StreamReader sr = new StreamReader(path);
            //统计文件的字符数。
            txt = sr.ReadToEnd();
            //使用正则表达式分割
            regex = new Regex(pattern1);
            string[] output = regex.Split(txt);
            //使用正则表达式找出符合要求的单词
            regex = new Regex(pattern2);
            foreach (string s in output)
            {
                if (regex.IsMatch(s))
                {
                    //转换为小写字母。
                    words.Add(s.ToLower());
                }
            }
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
            sr.Close();
            return keyValues;
        }

        //将单词进行词频排序并且输出前十个词频的单词
        public static void SortKey(Dictionary<string, int> keyValues, Dictionary<string, int> result)
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
            int count = 0;
            foreach(var s in keyValues)
            {
                //找出单词频数为最高的单词
                if (s.Value.Equals(value[0])&&count<=10)
                {
                    //提取对应的单词以及出现的频数
                    result.Add(s.Key, value[0]);
                    count++;
                }
            }
            //顺序提取单词频数前10的单词 同频的按照字典序排列
            for(int i = 1; i < value.Count&&count<=10; i++)
            {
                if (value[i] == value[i - 1])
                    continue;
                foreach(var s in keyValues)
                {
                    if (s.Value.Equals(value[i]))
                    {
                        if (count < 10)
                        {
                            //按照制定格式输出对应的写入流中
                            result.Add(s.Key, value[i]);
                            count++;
                        }
                        else
                        break;
                    }
                }
            }       
        }  
    }
}
