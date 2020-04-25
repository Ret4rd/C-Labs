using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название файла");
            var path = Console.ReadLine();
            char c = ' ';
            char c1;
            char[] punctuation = { '-','.','?','!',')','(',',',':','\t'};
            Dictionary<string, int> words = new Dictionary<string, int>();
            StringBuilder word = new StringBuilder();
            try
            {
                using (var fileStream = new StreamReader(Path.Combine(Environment.CurrentDirectory, path)))
                {
                    while (!fileStream.EndOfStream)
                    {
                        c1 = (char)fileStream.Read();
                        if (punctuation.Contains(c1))
                            c1 = ' ';
                        if (c1 != ' ')
                            word.Append(c1);
                        if ((c1 == ' ' && c != ' ') || fileStream.EndOfStream)
                        {
                            if (words.ContainsKey(word.ToString()))
                                words[word.ToString()]++;
                            else
                                words.Add(word.ToString(), 1);
                            word.Clear();
                        }
                        c = c1;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            foreach (KeyValuePair<string, int> item in words)
            {
                Console.WriteLine("Слово: " + item.Key + " Повторений: " + item.Value);
            }
            Console.WriteLine("Введите слово для поиска");
            var find = Console.ReadLine();
            if (words.ContainsKey(find))
                Console.WriteLine("Слово: " + find + " Повторений: " + words[find]);
            else
                Console.WriteLine("Такого слова нет");

            Console.WriteLine("Самое часто встречающееся слово");
            Console.WriteLine("Слово: " + words.Aggregate((x, y) => 
            x.Value > y.Value ? x : y).Key + " Повторений: " + words.Values.Max());
            Console.ReadKey();
        }
    }
}
