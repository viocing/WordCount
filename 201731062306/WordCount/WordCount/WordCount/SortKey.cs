using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class SortKey
    {
         //将单词进行词频排序并且输出前十个词频的单词
        public static void Sortkey(Dictionary<string, int> keyValues, StreamWriter streamWriter)
        {
            //对该集合进行字典序排序
            keyValues = keyValues.OrderBy(o => o.Key, StringComparer.Ordinal).ToDictionary(p => p.Key, o => o.Value);
            //单词频数集合
            List<int> value = new List<int>();
            foreach (int i in keyValues.Values)
            {
                value.Add(i);
            }
            //进行单词频数排序
            value.Sort((x, y) => -x.CompareTo(y));
            int count = 0;
            foreach (var s in keyValues)
            {
                //找出单词频数为最高的单词
                if (s.Value.Equals(value[0]))
                {
                    //输出对应的单词以及出现的频数
                    streamWriter.WriteLine("<" + s.Key + ">" + ":" + value[0]);
                    Console.WriteLine("<" + s.Key + ">" + ":" + value[0]);
                    count++;
                }
            }
            //顺序输出单词频数前10的单词 同频的按照字典序排列
            for (int i = 1; i < value.Count && count <= 10; i++)
            {
                if (value[i] == value[i - 1])
                    continue;
                foreach (var s in keyValues)
                {
                    if (s.Value.Equals(value[i]))
                    {
                        if (count < 10)
                        {
                            //按照制定格式输出对应的写入流中
                            streamWriter.WriteLine("<" + s.Key + ">" + ":" + value[i]);
                            Console.WriteLine("<" + s.Key + ">" + ":" + value[i]);
                            count++;
                        }
                        else
                            break;
                    }
                }
            }
            //刷新缓冲区并关闭流
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
