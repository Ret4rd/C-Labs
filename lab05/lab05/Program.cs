using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консоль - 0, файл - 1");
            var key = Console.ReadKey().KeyChar;
            string str = String.Empty;
            if (key == '0')
            {
                Console.WriteLine("\nВведите значение и основание");
                str = Console.ReadLine();
                if(str.Length == 0)
                {
                    Console.WriteLine("Вы ничего не ввели");
                    Console.ReadKey();
                    return;
                }
            }
            else if (key == '1')
            {
                Console.WriteLine("\nВведите название файла");
                string path = "C:/Users/Никита Пестов/Documents/Visual Studio 2015/Projects/Cem6/lab05/" + Console.ReadLine();
                if(!File.Exists(path))
                {
                    Console.WriteLine("Файла не существует");
                    Console.ReadKey();
                    return;
                }
                try
                {
                    str = File.ReadLines(path).First();
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
            }
            var strArr = str.Split(' ', ',');
            strArr[1] = "0," + strArr[1];
            var numList = new List<decimal>();
            var ok = true;

            if (strArr.Length == 3)
            {
                for (int i = 0; i < strArr.Length; i++)
                {
                    decimal num;
                    ok = decimal.TryParse(strArr[i], out num);
                    if (ok)
                    {
                        numList.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Недопустимые символы");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
            if (numList[2] >= 2 && numList[2] <= 36)
            {
                Console.WriteLine(Methods.NewSystem((int)numList[0], numList[1], (int)numList[2]));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
        }
    }
}
