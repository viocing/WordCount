using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class CreateWords
    {
        //pattern1正则表达式表示的是任意非英文数字字符。
        private static string pattern1 = @"\W+";
        //pattern2正则表达式代表的是前面至少含有4个字母后面再接上任意的字母或者是数字。
        private static string pattern2 = @"^[a-zA-Z]{4,}[a-zA-Z0-9]*$";
        //正则表达式。
        private static Regex regex = null;
        //统计单词数。
        public static List<string> Createwords(string txt)
        {
            List<string> words = new List<string>();
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
    }
}
