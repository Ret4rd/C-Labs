using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите левую границу");
            var a = 0.0;
            var b = 0.0;
            var eps = 0.0;
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите правую границу");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите точность");
                eps = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            if(a > b)
            {
                var tmp = a;
                a = b;
                b = tmp;
            }
            var res = Methods.Dihotomia(a, b, eps, Methods.f);
            Console.WriteLine("Корень: " + res);
            Console.ReadKey();
        }
    }
}
