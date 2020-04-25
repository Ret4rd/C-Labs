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
            var res = new StringBuilder();
            if (wordsList.Count == 0)
                throw new Exception("Нет слов");
            foreach(string str in wordsList)
            {
                res.Append(str.Last());
                //res.Insert(res.Length, str.Last()); //+= str.Last();
            }
            return res.ToString();
        }
    }
}
