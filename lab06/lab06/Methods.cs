using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06
{
    class Methods
    {
        public static List<string> Sort(string[] str)
        {
            var wordsList = new List<string>(str);
            wordsList.Sort();
            return wordsList;
        }

        public static string LastWord(List<string> wordsList)
        {
            var res = string.Empty;
            if (wordsList.Count == 0)
                throw new Exception("Нет слов");
            foreach(string str in wordsList)
            {
                res += str.Last();
            }
            return res;
        }
    }
}
