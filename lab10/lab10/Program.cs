using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] num = new double[6, 6] { { 1, 7, 4, 0, 9, 4}, { 8, 8, 2, 4, 5, 5 },
            {1, 7, 1, 1, 5, 2 }, {7, 6, 1, 4, 2, 3 }, {2, 2, 1, 6, 8, 5 }, 
            {7, 6, 1, 8, 9, 2 } };

            double[,] num1 = new double[3, 3] { { 1, 7, 4 }, { 0, 9, 4 }, { 8, 8, 2 } };

            double[,] num2 = new double[3, 3] { { 4, 5, 5 }, { 1, 7, 1 }, {1, 5, 2 }
             };
           
            try
            {
                Matrix<double> mat1 = new Matrix<double>(num1);
                Matrix<double> mat2 = new Matrix<double>(num2);
                //mat1.Random(3);
                //mat2.Random(3);
                Console.WriteLine("Матрицы");
                Console.WriteLine("Матрица 1");
                mat1.Print();
                Console.WriteLine("Матрица 2");
                mat2.Print();
                Console.WriteLine("Вычитание");
                (mat1 - mat2).Print();
                Console.WriteLine("Сложение");
                (mat1 + mat2).Print();
                Console.WriteLine("Умножение");
                (mat1 * mat2).Print();
                Console.WriteLine("Деление");
                (mat1 / mat2).Print();
                Console.WriteLine("Транспонирование первой матрицы");
                (mat1.Transport()).Print();
                Console.WriteLine("Обратная первая матрица");
                (mat1.Reverse()).Print();
                Console.WriteLine("Определитель первой матрицы");
                Console.WriteLine(mat1.Determ());
                Console.WriteLine("foreach первая матрица");
                foreach (double a in mat1)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine("Полиномы");
                Polynom<double> pol1 = new Polynom<double>();
                Polynom<double> pol2 = new Polynom<double>();

                //pol1.Add(3, 4);
                //pol1.Add(-1, 2);
                //pol1.Add(5, 3);
                //pol2.Add(2, 0);
                //pol2.Add(1, 2);
                //pol2.Add(2, 1);
                pol1.Add(2, 0);
                pol1.Add(7, 1);
                pol1.Add(1, 2);
                pol2.Add(1, 1);
                pol2.Add(2, 0);
                Console.WriteLine("Первый полином");
                pol1.Print();
                Console.WriteLine("Второй полином");
                pol2.Print();
                Console.WriteLine("Сумма");
                (pol1 + pol2).Print();
                Console.WriteLine("Разность");
                (pol1 - pol2).Print();
                Console.WriteLine("Произведение");
                (pol1 * pol2).Print();
                Console.WriteLine("Деление");
                (pol1 / pol2).Print();
                Console.WriteLine("Значение первого полинома в точке 2");
                Console.WriteLine(pol1.Point(2));
                Console.WriteLine("Композиция");
                (pol1.Super(pol2)).Print();

                Polynom<Matrix<double>> polMat1 = new Polynom<Matrix<double>>();
                Polynom<Matrix<double>> polMat2 = new Polynom<Matrix<double>>();
                Matrix<double> mat3 = new Matrix<double>(2);
                Matrix<double> mat4 = new Matrix<double>(2);
                Matrix<double> mat5 = new Matrix<double>(2);
                Console.WriteLine("Полиномы матриц");
                mat3.Random(2);
                mat4.Random(2);
                mat5.Random(2);
                polMat1.Add(mat3, 4);
                polMat1.Add(mat5, 2);
                polMat1.Add(mat4, 3);
                polMat2.Add(mat5, 0);
                polMat2.Add(mat3, 2);
                polMat2.Add(mat3, 1);
                Console.WriteLine("Первый полином");
                polMat1.Print();
                Console.WriteLine("Второй полином");
                polMat2.Print();
                Console.WriteLine("Сумма");
                (polMat1 + polMat2).Print();
                Console.WriteLine("Разность");
                (polMat1 - polMat2).Print();
                Console.WriteLine("Произведение");
                (polMat1 * polMat2).Print();
                Console.WriteLine("Деление");
                (polMat1 / polMat2).Print();
                Console.WriteLine("Значение первого полинома в точке 2");
                Console.WriteLine(polMat1.Point(2));
                Console.WriteLine("Композиция");
                (polMat1.Super(polMat2)).Print();
                Console.WriteLine("foreach");
                foreach(Matrix<double> coef in polMat2)
                {
                    Console.WriteLine(coef + " ");
                }
            }
            catch (MyException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
