using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class WordUtiTests
    {
        [TestMethod()]
        public void createDicTest()
        {
            Dictionary<string, int> keyValuePairs = WordUti.createDic("ming.txt");
            Assert.AreNotEqual(keyValuePairs, null);

        }

        [TestMethod()]
        public void SortKeyTest()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            WordUti.SortKey(WordUti.createDic("ming.txt"), result);
            Console.Write(result.ToString());
        }
    }
}