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
            Dictionary<string, int> words = new Dictionary<string, int>();
            try
            {
                words = Methods.ReadFile(path);
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
            //if (words.ContainsKey(find))
            //    Console.WriteLine("Слово: " + find + " Повторений: " + words[find]);
            //else
            //    Console.WriteLine("Такого слова нет");
            Console.WriteLine("Слово: " + find + " Повторений: " + Methods.FindWord(words, find));

            Console.WriteLine("Самое часто встречающееся слово");
            Dictionary<string, int> oftenWord = new Dictionary<string, int>();
            try
            {
                oftenWord = Methods.OftenWord(words);
                Console.WriteLine("Слово: " + oftenWord.First().Key + " Повторений: " + oftenWord.First().Value);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
