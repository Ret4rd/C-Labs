using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слова");
            
            var words = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            var wordsList = Methods.Sort(words);
            Console.WriteLine(String.Join(" ", wordsList));
            try
            {
                var word = Methods.LastWord(wordsList);
                Console.WriteLine(word);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
