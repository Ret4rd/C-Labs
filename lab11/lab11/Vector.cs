using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Vector<T> : IComparable, IComparable<Vector<T>> where T : IComparable, new()
    {
        private T[] vector;

        public Vector()
        {
            this.vector = new T[1];
        }

        public Vector(T[] vec)
        {
            if (vec.Length <= 0)
                throw new Exception("Длина вектора меньше нуля");
            this.vector = new T[vec.Length];
            for(int i = 0; i < vec.Length; i++)
            {
                this.vector[i] = vec[i]; 
            }
        }

        public Vector(double size)
        {
            if (size <= 0)
                throw new Exception("Длина меньше нуля");
            this.vector = new T[(int)size];
        }

        public static Vector<T> operator +(Vector<T> vec1, Vector<T> vec2)
        {
            return Sum(vec1, vec2);
        }

        public static Vector<T> Sum(Vector<T> vec1, Vector<T> vec2)
        {
            if (vec1.vector.Length != vec2.vector.Length)
                throw new Exception("Разные размеры векторов");
            Vector<T> res = new Vector<T>(vec1.vector.Length);
            for(int i = 0; i < vec1.vector.Length; i++)
            {
                res.vector[i] = (dynamic)vec1.vector[i] + vec2.vector[i];
            }
            return res;
        }

        public static Vector<T> operator -(Vector<T> vec1, Vector<T> vec2)
        {
            return Sub(vec1, vec2);
        }
        public static Vector<T> Sub(Vector<T> vec1, Vector<T> vec2)
        {
            if (vec1.vector.Length != vec2.vector.Length)
                throw new Exception("Разные размеры векторов");
            Vector<T> res = new Vector<T>(vec1.vector.Length);
            for (int i = 0; i < vec1.vector.Length; i++)
            {
                res.vector[i] = (dynamic)vec1.vector[i] - vec2.vector[i];
            }
            return res;
        }

        public static Vector<T> operator *(Vector<T> vec1, T num)
        {
            return Mult(vec1, num);
        }
        public static Vector<T> Mult(Vector<T> vec1, T num)
        {
            Vector<T> res = new Vector<T>(vec1.vector.Length);
            for (int i = 0; i < vec1.vector.Length; i++)
            {
                res.vector[i] = (dynamic)vec1.vector[i] * num;
            }
            return res;
        }

        public static double Module(Vector<T> vec)
        {
            double res = 0.0;
            //Vector<T> res = new Vector<T>(vec.vector.Length);
            if (vec.vector[0] is Complex)
            {
                //Complex[] res = new Complex[1];
                for (int i = 0; i < vec.vector.Length; i++)
                {
                    res = res + Complex.Module((dynamic)vec.vector[i]) * Complex.Module((dynamic)vec.vector[i]);
                }
                
            }
            else
            {
                
                for (int i = 0; i < vec.vector.Length; i++)
                {
                    res = res + (dynamic)vec.vector[i] * vec.vector[i];
                }
                //res = Math.Sqrt((dynamic)res);
                //return res;
            }
            res = Math.Sqrt((dynamic)res);
            return res;

        }

        public static T Scalar(Vector<T> vec1, Vector<T> vec2)
        {
            if (vec1.vector.Length != vec2.vector.Length)
                throw new Exception("Разные размеры векторов");
            T res = new T();
            for (int i = 0; i < vec1.vector.Length; i++)
            {
                res = res + (dynamic)vec1.vector[i] * vec2.vector[i];
            }
            return res;
        }

        //public static Vector<T>[] Ortho(Vector<T>[] vec)
        //{

        //    for(int i = 0; i < vec.Length; i++)
        //    {

        //    }
        //    return 
        //}

        private static T[] ZeroArr(Vector<T> vec)
        {
            return Enumerable.Repeat(new T(), vec.vector.Length).ToArray();
        }

        public static Vector<T>[] Ortogonalization(Vector<T>[] vec)
        {
            var b = new Vector<T>[vec.Length];
            b[0] = vec[0];
            for (int i = 1; i < vec.Length; i++)
            {
                var zeroArr = ZeroArr(vec[i]);
                var tmpVector = new Vector<T>(zeroArr);
                var sumVector = new Vector<T>(zeroArr);
                for (int j = 0; j < i; j++)
                {
                    T k = (dynamic)(Scalar(vec[i], b[j])) / (Scalar(b[j], b[j]));
                    sumVector -= b[j] * k;
                }
                b[i] = Sum(vec[i], sumVector);
                sumVector = tmpVector;
            }
            return b;
        }

        public void Print()
        {
            foreach(T num in this.vector)
            {
                Console.Write(num.ToString() + " ");
            }
            Console.WriteLine();
            return;
        }


        public static implicit operator T[] (Vector<T> A) => (T[])A.vector.Clone();

        public static implicit operator Vector<T>(T[] Arr) => new Vector<T>(Arr);

        public int CompareTo(Vector<T> vec)
        {
            return Module(this).CompareTo(Module(vec));
        }

        int IComparable.CompareTo(object obj)
        {

            if (!(obj is Vector<T>))
            {
                throw new ArgumentException("Это не вектор");
            }

            var res = obj as Vector<T>;
            return CompareTo(res);
        }
    }
}
