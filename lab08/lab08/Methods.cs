using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab08
{
    class Methods
    {
        public static string[] ParserList(string str)
        {
            var newStr = Regex.Replace(str, "[-.?!)(,:\t]", " ");
            var wordList = newStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return wordList;
        }

        public static string ParserString(string str)
        {
            var newStr = Regex.Replace(str, "[-.?!)(,:\t]", " ");
            var wordList = newStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return String.Join(" ", wordList);
        }

        public static int NumWords(string str, string word)
        {
            var newStr = Methods.ParserString(str);
            return Regex.Matches(newStr, word).Count;
        }

        public static string Repl(string str, string word)
        {
            var wordList = Methods.ParserList(str);
            if (wordList.Length < 2)
                throw new Exception("Недостаточно слов");
            var oldWord = wordList[wordList.Length - 2];
            var oldList = str.Split(' ');
            oldList[oldList.Length - 2] = oldList[oldList.Length - 2].Replace(oldWord, word);
            return String.Join(" ", oldList);
        }

        public static string Find(string str, int k)
        {
            var wordList = Methods.ParserList(str);
            foreach(string word in wordList)
            {
                if(Char.IsUpper(word[0]))
                {
                    k--;
                    if (k == 0)
                        return word;
                }
            }
            return "Такого слова нет";

        }
    }
}
