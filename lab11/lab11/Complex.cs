using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public delegate void Handler(Event obj);

    public class Complex : IComparable
    {
        private double real, imaginary;
        public static event Handler DivisionByZero;

        public Complex()
        {
            this.real = 0;
            this.imaginary = 0;
        }

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public Complex(double real)
        {
            this.real = real;
            this.imaginary = 0;
        }

        public static Complex operator +(Complex com1, Complex com2)
        {
            return Sum(com1, com2);
        }

        public static Complex Sum(Complex com1, Complex com2)
        {
            Complex res = new Complex();
            res.real = com1.real + com2.real;
            res.imaginary = com1.imaginary + com2.imaginary;
            return res;
        }

        public static Complex operator -(Complex com1, Complex com2)
        {
            return Sub(com1, com2);
        }

        public static Complex Sub(Complex com1, Complex com2)
        {
            Complex res = new Complex();
            res.real = com1.real - com2.real;
            res.imaginary = com1.imaginary - com2.imaginary;
            return res;
        }

        public static Complex operator *(Complex com1, Complex com2)
        {
            return Mult(com1, com2);
        }

        public static Complex Mult(Complex com1, Complex com2)
        {
            Complex res = new Complex();
            res.real = com1.real * com2.real - com1.imaginary * com2.imaginary;
            res.imaginary = com1.real * com2.imaginary + com1.imaginary * com2.real;
            return res;
        }

        public static Complex operator *(Complex com, double num)
        {
            return MultNum(com, num);
        }

        public static Complex MultNum(Complex com, double num)
        {
            Complex res = new Complex();
            res.real = com.real * num;
            res.imaginary = com.imaginary * num;
            return res;
        }

        public static Complex operator /(Complex com1, Complex com2)
        {
            
            return Div(com1, com2);
        }

        public static Complex Div(Complex com1, Complex com2)
        {
            if (Math.Abs(com2.real * com2.real + com2.imaginary + com2.imaginary) < double.Epsilon)
            {
                var obj = new Event(com1, com2);
                DivisionByZero?.Invoke(obj);
                return new Complex();
            }
            Complex res = new Complex();
            res.real = (com1.real * com2.real + com1.imaginary * com2.imaginary) / 
                (com2.real * com2.real + com2.imaginary * com2.imaginary);
            res.imaginary = (com1.imaginary * com2.real - com1.real * com2.imaginary) /
                (com2.real * com2.real + com2.imaginary * com2.imaginary);
            return res;
        }

        public static double Module(Complex com)
        {
            var res = 0.0;
            res = Math.Sqrt(com.real * com.real + com.imaginary * com.imaginary);
            return res;
        }

        public static Complex Pow(Complex com, double deg)
        {
            Complex res = new Complex();
            var module = Module(com);
            if (com.real == 0)
            {
                var obj = new Event(new Complex(0, com.imaginary), new Complex(com.real, 0));
                DivisionByZero?.Invoke(obj);
                throw new Exception("Деление на ноль при вычислении аргумента");
            }
                
            var arg = Math.Atan(com.imaginary / com.real);
            res.real = Math.Pow(module, deg) * Math.Cos(deg * arg);
            res.imaginary = Math.Pow(module, deg) * Math.Sin(deg * arg);
            return res;
        }

        public static Complex[] Sqrt(Complex com, double deg)
        {
            if (deg < 0.0001)
            {
                var obj = new Event(new Complex(1, 0), new Complex(deg, 0));
                DivisionByZero?.Invoke(obj);
                throw new Exception("Деление степени на ноль");
            }
                
            Complex[] res = new Complex[(int) deg];
            //Complex obj = new Complex();
            var module = Module(com);
            var arg = Math.Atan(com.imaginary / com.real);
            for(int k = 0; k < deg; k++)
            {
                res[k] = new Complex(Math.Pow(module, 1 / deg) * Math.Cos((arg + 2 * Math.PI * k) / deg),
                    Math.Pow(module, 1 / deg) * Math.Sin((arg + 2 * Math.PI * k) / deg));
                
                //res.Add(obj);
            }
            return res;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.real + " + i" + this.imaginary);
            return str.ToString();
        }

        public int CompareTo(object B)
        {
            if (!(B is Complex))
            {
                throw new ArgumentException("Это не комплексное число");
            }
            Complex num = (Complex)B;
            return this.real.CompareTo(num.real);
        }

    }
}
