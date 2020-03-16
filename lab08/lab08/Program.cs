using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            var str = Console.ReadLine();
            if(str.Length == 0)
            {
                Console.WriteLine("Пустая строка");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Введите 0 - найти количество заданных слов, 1 - замена предпоследнего слова, 2 - найти k-ое слово с заглавной буквы");
            var key = Console.ReadKey().KeyChar;
            if(key == '0')
            {
                Console.WriteLine("\nВведите искомое слово");
                var word = Console.ReadLine();
                Console.WriteLine("Количество слов = " + Methods.NumWords(str, word));
            }
            else if (key == '1')
            {
                Console.WriteLine("\nВведите слово на замену");
                var word = Console.ReadLine();
                var newStr = String.Empty;
                try
                {
                    newStr = Methods.Repl(str, word);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine(newStr);
            }
            else if (key == '2')
            {
                Console.WriteLine("\nВведите номер слова");
                var kStr = Console.ReadLine();
                var k = 0;
                try
                {
                    int.TryParse(kStr, out k);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                var word = Methods.Find(str, k);
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    }
}
