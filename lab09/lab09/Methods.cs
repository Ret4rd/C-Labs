using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    class Methods
    {
        public static double Dihotomia(double a, double b, double epsilon, Func func)
        {

            var i = 0;
            var c = 0.0;
            while (b - a > epsilon)
            {
                i += 1;
                c = (a + b) / 2;
                if (func(b) * func(c) < 0)
                    a = c;
                else
                    b = c;
            }
            return (a + b) / 2;
        }

        public delegate double Func(double x);

        public static double f(double x)
        {
            return x + Math.Pow(x, 2) - 5;
        }

    }
}
