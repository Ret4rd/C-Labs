using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{

    class Matrix<T> : ICloneable, IEnumerable, IComparable<Matrix<T>>, IComparable
    {
        private T[,] matrix;
        private int size;

        public Matrix()
        {
            this.size = 0;
            this.matrix = new T[size,size];
        }
        public Matrix(T[,] newMat)
        {
            if (newMat.GetUpperBound(0) + 1 != newMat.Length / (newMat.GetUpperBound(0) + 1))
                throw new MyException("Не квадратная матрица");
            this.size = newMat.Length / (int)Math.Sqrt(newMat.Length);
            this.matrix = newMat;
        }

        public Matrix(int newSize)
        {
            if(newSize <= 0 )
                throw new MyException("Задана неправильная размерность");
            this.size = newSize;
            this.matrix = new T[newSize, newSize];
        }

        //public static Matrix<T> operator -(Matrix<T> mat)
        //{
        //    for (int i = 0; i < mat.size; i++)
        //    {
        //        for (int j = 0; j < mat.size; j++)
        //        {
        //            mat.matrix[i, j] = -1 * mat.matrix[i, j];
        //        }
        //    }
        //    return mat;
        //}

        public static Matrix<T> operator -(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.size != mat2.size)
                throw new MyException("Разные размерности матриц");
            if (mat1.size == 0 || mat2.size == 0)
                throw new MyException("Матрица нулевого размера ");
            Matrix<T> res = new Matrix<T>(mat1.size);
            for (int i = 0; i < mat1.size; i++)
            {
                for (int j = 0; j < mat1.size; j++)
                {
                    res.matrix[i, j] = (dynamic)mat1.matrix[i, j] - mat2.matrix[i, j];
                }
            }
            return res;
        }

        public static Matrix<T> operator +(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.size != mat2.size && mat1.size != 0)
                throw new MyException("Разные размерности матриц");
            if (mat2.size == 0)
                throw new MyException("Матрица нулевого размера ");
            if (mat1 == 0)
                mat1 = new Matrix<T>(mat2.size);
            
            Matrix<T> res = new Matrix<T>(mat1.size);
            for(int i = 0; i < mat1.size; i++)
            {
                for(int j = 0; j < mat1.size; j++)
                {
                    res.matrix[i, j] = (dynamic)mat1.matrix[i, j] + mat2.matrix[i, j];
                }
            }
            return res;
        }

        public static Matrix<T> operator *(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.size != mat2.size)
                throw new MyException("Разные размерности матриц");
            if (mat1.size == 0 || mat2.size == 0)
                throw new MyException("Матрица нулевого размера ");
            Matrix<T> res = new Matrix<T>(mat1.size);
            for (int i = 0; i < mat1.size; i++)
            {
                for (int j = 0; j < mat1.size; j++)
                {
                    //res.matrix[i, j] = 0;
                    for (int e = 0; e < mat1.size; e++)
                        res.matrix[i, j] = (dynamic)mat1.matrix[i, e] * mat2.matrix[e, j] + res.matrix[i, j];
                }
            }
            return res;
        }

        public static Matrix<T> operator *(Matrix<T> mat, double num)
        {
            if (mat.size == 0)
                throw new MyException("Матрица нулевого размера ");
            Matrix<T> obj = new Matrix<T>(mat.size); ;
            for (int i = 0; i < mat.size; i++)
            {
                for (int j = 0; j < mat.size; j++)
                {
                    obj.matrix[i, j] = (dynamic)mat.matrix[i, j] * num;
                }
            }
            return obj;
        }

        public static Matrix<T> operator /(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.size != mat2.size)
                throw new MyException("Разные размерности матриц");
            if (mat1.size == 0 || mat2.size == 0)
                throw new MyException("Матрица нулевого размера ");
            Matrix<T> mat = new Matrix<T>(mat1.size);
            mat = (Matrix<T>)mat2.Clone();
            return (mat1 * mat.Reverse());
        }

        public  Matrix<T> Reverse()
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера ");
            if (this.size == 1)
            {
                Matrix<T> mat1 = new Matrix<T>(this.matrix);
                mat1.matrix[0, 0] = Math.Pow((dynamic)mat1.matrix[0, 0], -1);
                return mat1;
            }
                
            double a = -1;
            Matrix<T> res = new Matrix<T>(size);
            Matrix<T> mat = new Matrix<T>(size - 1);
            double det = Determ();
            if (det == (dynamic)0)
            {
                throw new MyException("Деление на ноль");
            }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    int col, str = 0;
                    for (int k = 0; k < size - 1; k++)
                    {
                        if (k == i)
                            str = 1;
                        col = 0;
                        for (int l = 0; l < size - 1; l++)
                        {
                            if (l == j)
                                col = 1;
                            mat.matrix[k, l] =  this.matrix[k + str, l + col];
                        }
                    }
                    if ((i + j) % 2 == 0)
                        a = 1;
                    else
                        a = -1;
                    res.matrix[i, j] = (dynamic)mat.Determ() * a;
                }
            res = res.Transport();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    res.matrix[i, j] = (dynamic)res.matrix[i, j] / det;
            return res;
        }

        public Matrix<T> Transport()
        {
            if(this.size == 0)
                throw new MyException("Матрица нулевого размера");
            Matrix<T> res = (Matrix<T>)this.Clone(); 
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    res.matrix[j, i] = this.matrix[i, j];
            return res;
        }

        //public static Matrix<T> operator =(Matrix<T> mat, double number)
        //{
        //    for (int i = 0; i < mat.size; i++)
        //    {
        //        for (int j = 0; j < mat.size; j++)
        //        {
        //            mat.matrix[i, j] = (dynamic)number;
        //        }
        //    }
        //    return mat;
        //}

        //public static bool operator ==(Matrix<T> mat1, Matrix<T> mat2)
        //{
        //    if (mat1.size != mat2.size)
        //        throw new MyException("Разные размерности матриц");
        //    for (int i = 0; i < mat1.size; i++)
        //    {
        //        for (int j = 0; j < mat1.size; j++)
        //        {
        //            if (mat1.matrix[i, j] != (dynamic)mat2.matrix[i, j])
        //                return false;
        //        }
        //    }
        //    return true;
        //}


        //public static bool operator !=(Matrix<T> mat1, Matrix<T> mat2)
        //{
        //    if (mat1.size != mat2.size)
        //        throw new MyException("Разные размерности матриц");
        //    if (mat1 == mat2)
        //        return false;
        //    else
        //        return true;
        //}

        public static bool operator ==(Matrix<T> mat, double number)
        {
            //if (mat.size == 0)
            //    throw new MyException("Матрица нулевого размера");
            for (int i = 0; i < mat.size; i++)
            {
                for (int j = 0; j < mat.size; j++)
                {
                    if (mat.matrix[i, j] != (dynamic)number)
                        return false;
                }
            }
                return true;
        }

        public static bool operator !=(Matrix<T> mat, double number)
        {
            if (mat == (dynamic)number)
                return false;
            else
                return true;
        }
        
        public double Determ()
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера ");
            Matrix<T> mat = (Matrix<T>)this.Clone();
            double det;
            T a;
            det = (dynamic)1;
            for (int i = 0; i + 1 < size; ++i)
            {
                if (mat.matrix[i, i] == (dynamic)0)
                {
                    for (int j = i; j < size; ++j)
                    {
                        if (mat.matrix[j, i] != (dynamic)0)
                        {
                            T[] temp = new T[size];
                            for(int k = 0; k < size; k++)
                            {
                                temp[k] = mat.matrix[k, i];
                                mat.matrix[k, i] = mat.matrix[k, j];
                                mat.matrix[k, j] = temp[k];
                            }
                            det = (dynamic)det * (-1);
                            break;
                        }
                        else if (j == size - 1)
                        {
                            det = (dynamic)0;
                            return det;
                        }
                    }
                }
                det = (dynamic)det * mat.matrix[i, i];
                for (int j = i + 1; j < size; ++j)
                {
                    a = (dynamic)mat.matrix[j, i] / mat.matrix[i, i];
                    for (int k = i; k < size; ++k)
                        mat.matrix[j, k] = mat.matrix[j, k] - ((dynamic)mat.matrix[i, k] * a);
                }
            }
            return (dynamic)det * mat.matrix[size - 1, size - 1];
        } 

        public void Random(int n)
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера");
            var rand = new Random();
            var num = new double[n,n];
            for(int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                num[i, j] = rand.Next(10);
            //Matrix<T> res = new Matrix<T>
            this.size = n;
            this.matrix = (dynamic)num;
        }
        public void Print()
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера");
            for (int i = 0; i < this.size; i++)
            {
                for(int j = 0; j < this.size; j++)
                    Console.Write(this.matrix[i,j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера");
            var str = String.Empty;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                    str += this.matrix[i, j] + " ";
                str += "\n";
            }
            return str;
        }

        public T[,] Get()
        {
            return matrix;
        }

        public object Clone()
        {
            if (this.size == 0)
                throw new MyException("Матрица нулевого размера");
            Matrix<T> res = new Matrix<T>(this.size);
            for (int i = 0; i < this.size; i++)
                for (int j = 0; j < this.size; j++)
                    res.matrix[i, j] = this.matrix[i, j]; 
            
            return new Matrix<T>
            {
               matrix = res.matrix,
                size = this.size
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var num in this.matrix)
                yield return num;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Matrix<T>))
                return 0;
            return CompareTo((Matrix<T>)obj);
            
        }

        public int CompareTo(Matrix<T> mat)
        {
            return this.Determ().CompareTo(mat.Determ());
        }

    }
}
