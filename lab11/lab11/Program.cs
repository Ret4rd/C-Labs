using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Complex com1 = new Complex(4, 3);
                Complex com2 = new Complex(0, 0);
                Console.WriteLine("Первое комплексное число");
                Console.WriteLine(com1.ToString());
                Console.WriteLine("Второе комплексное число");
                Console.WriteLine(com2.ToString());
                Console.WriteLine("Сложение");
                Console.WriteLine((com1 + com2).ToString());
                Console.WriteLine("Разность");
                Console.WriteLine((com1 - com2).ToString());
                Console.WriteLine("Умножение");
                Console.WriteLine((com1 * com2).ToString());
                Console.WriteLine("Деление");
                Console.WriteLine((com1 / com2).ToString());
                Console.WriteLine("Модуль первого числа");
                Console.WriteLine(Complex.Module(com1));
                Console.WriteLine("Возведение первого числа в степень 4");
                Console.WriteLine(Complex.Pow(com1, 4).ToString());
                Console.WriteLine("Возведение первого числа в степень 1/2");
                var sq = Complex.Sqrt(com1, 2);
                for (int i = 0; i < sq.Length; i++)
                    Console.WriteLine(sq[i]);
                
                Vector<double> vec1 = new Vector<double>(new double[3] { 1, 2, 3 });
                Vector<double> vec2 = new Vector<double>(new double[3] { 1, 5, 2 });
                Console.WriteLine("Первый вектор");
                vec1.Print();
                Console.WriteLine("Второй вектор");
                vec2.Print();
                Console.WriteLine("Сложение");
                (vec1 + vec2).Print();
                Console.WriteLine("Разность");
                (vec1 - vec2).Print();
                Console.WriteLine("Умножение на 2");
                (vec1 * 2).Print();
                Console.WriteLine("Модуль первого вектора");
                Console.WriteLine(Vector<double>.Module(vec1));
                Console.WriteLine("Скалярное произведение");
                Console.WriteLine(Vector<double>.Scalar(vec1, vec2));
                Console.WriteLine("Ортогонализация 1 и 2 вектора");
                var vecArr = new Vector<double>[2] { vec1, vec2 };
                var res = Vector<double>.Ortogonalization(vecArr);
                for (int i = 0; i < res.Length; i++)
                {
                    res[i].Print();
                }
                var doubleV = (double[])vec1;
                for (int i = 0; i < doubleV.Length; i++)
                    Console.WriteLine(doubleV[i]);
                var arrVec = (Vector<double>)doubleV;
                arrVec.Print();

                Vector<Complex> vecCom1 = new Vector<Complex>(new Complex[2] { com1, com2 });
                Vector<Complex> vecCom2 = new Vector<Complex>(new Complex[2] { com2, com1 });
                Console.WriteLine("Первый вектор");
                vecCom1.Print();
                Console.WriteLine("Второй вектор");
                vecCom2.Print();
                Console.WriteLine("Сложение");
                (vecCom1 + vecCom2).Print();
                Console.WriteLine("Разность");
                (vecCom1 - vecCom2).Print();
                Console.WriteLine("Модуль первого вектора");
                Console.WriteLine(Vector<Complex>.Module(vecCom1));
                Console.WriteLine("Скалярное произведение");
                Console.WriteLine(Vector<Complex>.Scalar(vecCom1, vecCom2));
                Console.WriteLine("Ортогонализация 1 и 2 вектора");
                Console.WriteLine(Vector<Complex>.Scalar(vecCom1, vecCom2));
                Console.WriteLine("Ортогонализация 1 и 2 вектора");
                var vecComArr = new Vector<Complex>[2] { vecCom1, vecCom2 };
                var resCom = Vector<Complex>.Ortogonalization(vecComArr);
                for (int i = 0; i < resCom.Length; i++)
                {
                    resCom[i].Print();
                }
                var comV = (Complex[])vecCom1;
                for(int i = 0; i < comV.Length; i++)
                    Console.WriteLine(comV[i]);
                var comVec = (Vector<Complex>)comV;
                comVec.Print();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }
}
