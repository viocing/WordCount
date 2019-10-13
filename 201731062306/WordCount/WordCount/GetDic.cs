using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class GetDic
    {
        //传入有countWords使用的单词集合
        //得到单词以及对应的数目存入泛型数组keyValues
        public static Dictionary<string, int> createDic(StreamReader sr,List<string>words)
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
    }
}
