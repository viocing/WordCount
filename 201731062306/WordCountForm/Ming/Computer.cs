using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCount;

namespace WordFormUtil
{
    public class Computer
    {
        public static string WordGroup(string text,int m)
        {
            string result;
            if (text!= null)
            {
                result = "";
                List<string> words = WordUti.CreateWords(text);
                WordUti.wordgroup(m, words, ref result);
                return result;
            }
            return null;
        }
        public static string WordCount(string text,int m,int line)
        {
            string result;
            if ( text!= null)
            {
                result = "";
                int num = text.Length;
                result = "characters: " + num + "\r\n";
                List<string> words = WordUti.CreateWords(text);
                result += "lines: " + line + "\r\n";
                result += "words: " + words.Count + "\r\n";
                Dictionary<string, int> keyValues = WordUti.createDic(words);
                WordUti.SortKey(keyValues, ref result, m);
                return result;
            }
            return null;
        }
    }
}
