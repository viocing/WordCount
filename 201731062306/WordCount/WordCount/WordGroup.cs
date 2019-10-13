using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class WordGroup
    {
        //词组统计
        public static void wordgroup(int m,List<string> words,Dictionary<string,int> rt)
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
                rt.Add(matching.Key, matching.Value);
            }
        }
    }
}
