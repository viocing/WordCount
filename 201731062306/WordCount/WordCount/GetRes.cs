using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class GetRes
    {
        //将单词进行词频排序并且输出前n个词频的单词
        public static void SortKey(Dictionary<string, int> keyValues, Dictionary<string, int> result, int count)
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
            //如果参数是-1 则默认输出前10个
            if (count == -1)
            {
                count = 10;
            }
            //次数变量
            int index = 0;
            foreach (var s in keyValues)
            {
                //找出单词频数为最高的单词
                if (s.Value.Equals(value[0]) && index <= count)
                {
                    //提取对应的单词以及出现的频数

                    result.Add(s.Key, value[0]);
                    index++;
                }
            }
            //顺序提取单词频数前10的单词 同频的按照字典序排列
            for (int i = 1; i < value.Count && index <= count; i++)
            {
                if (value[i] == value[i - 1])
                    continue;
                foreach (var s in keyValues)
                {
                    if (s.Value.Equals(value[i]))
                    {
                        if (index < count)
                        {
                            //按照制定格式输出对应的写入流中
                            result.Add(s.Key, value[i]);
                            index++;
                        }
                        else
                            break;
                    }
                }
            }
        }
    }
}
