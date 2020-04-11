using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Polynom<T> : ICloneable, IEnumerable, IComparable where T : IComparable, new()
    {
        private SortedDictionary<double, T> polynom;

        public Polynom()
        {
            this.polynom = new SortedDictionary<double, T>();
        }
        public Polynom(T coef, double power)
        {
            this.polynom = new SortedDictionary<double, T>();
            if (coef != (dynamic)0)
                this.polynom.Add(power, coef);
        }
        public Polynom(T[] newPoly)
        {
            this.polynom = new SortedDictionary<double, T>();
            double deg = 0;
            foreach (T num in newPoly)
            {
                if (num != (dynamic)0)
                {
                    T c = (dynamic)0;
                    if (this.polynom.TryGetValue(deg, out c))
                    {
                        this.polynom.Remove(deg);
                        this.polynom.Add(deg, (dynamic)c + num);
                    }
                    else
                        this.polynom.Add(deg, num);
                    deg++;
                }

            }
        }

        public void Add(T coef, double power)
        {
            if (coef != (dynamic)0)
            {
                T num;
                if (this.polynom.TryGetValue(power, out num))
                {
                    this.polynom.Remove(power);
                    this.polynom.Add(power, (dynamic)coef + num);
                }

                else
                    this.polynom.Add(power, coef);
            }
        }

        //public void SetCoef(T coef, double key)
        //{
        //    //T num = new T();
        //    this.polynom[key] = coef;

        //}

        //public void SetPower(T coef, double key)
        //{
        //    //T num = new T();
        //    this.polynom[key] = coef;

        //}

        public static Polynom<T> operator +(Polynom<T> pol1, Polynom<T> pol2)
        {
            Polynom<T> obj = new Polynom<T>();
            Polynom<T> first = (Polynom<T>)pol1.Clone(), second = (Polynom<T>)pol2.Clone();
            foreach (KeyValuePair<double, T> item1 in pol1.polynom)
            {
                foreach (KeyValuePair<double, T> item2 in pol2.polynom)
                {
                    if (item1.Key == item2.Key)
                    {
                        if ((dynamic)item1.Value + item2.Value != 0)
                            obj.Add((dynamic)item1.Value + item2.Value, item1.Key);
                        first.polynom.Remove(item1.Key);
                        second.polynom.Remove(item2.Key);
                    }
                }
            }
            foreach (KeyValuePair<double, T> item in second.polynom)
            {
                //if (*jt != 0)
                obj.Add(item.Value, item.Key);
            }
            foreach (KeyValuePair<double, T> item in first.polynom)
            {
                //if (*it != 0)
                obj.Add(item.Value, item.Key);
            }
            return obj;
        }

        public static Polynom<T> operator -(Polynom<T> pol1, Polynom<T> pol2)
        {
            Polynom<T> obj = new Polynom<T>();
            Polynom<T> first = (Polynom<T>)pol1.Clone(), second = (Polynom<T>)pol2.Clone();
            foreach (KeyValuePair<double, T> item1 in pol1.polynom)
            {
                foreach (KeyValuePair<double, T> item2 in pol2.polynom)
                {
                    if (item1.Key == item2.Key)
                    {
                        if ((dynamic)item1.Value - item2.Value != 0)
                            obj.Add((dynamic)item1.Value - item2.Value, item1.Key);
                        first.polynom.Remove(item1.Key);
                        second.polynom.Remove(item2.Key);
                    }
                }
            }
            foreach (KeyValuePair<double, T> item in second.polynom)
            {
                //if (*jt != 0)
                obj.Add((dynamic)item.Value * (-1), item.Key);
            }
            foreach (KeyValuePair<double, T> item in first.polynom)
            {
                //if (*it != 0)
                obj.Add(item.Value, item.Key);
            }
            return obj;
        }

        public static Polynom<T> operator *(Polynom<T> pol1, Polynom<T> pol2)
        {
            Polynom<T> obj = new Polynom<T>();
            foreach (KeyValuePair<double, T> item1 in pol1.polynom)
            {
                foreach (KeyValuePair<double, T> item2 in pol2.polynom)
                {
                    obj.Add((dynamic)item1.Value * item2.Value, item1.Key + item2.Key);
                }

            }
            return obj;
        }

        public static Polynom<T> operator /(Polynom<T> pol1, Polynom<T> pol2)
        {
            Polynom<T> obj = new Polynom<T>(), tmpFirst = (Polynom<T>)pol1.Clone();
            var step = 0;
            while ((tmpFirst.polynom.Last().Key >= pol2.polynom.Last().Key))
            {
                T num = (dynamic)tmpFirst.polynom.Last().Value / pol2.polynom.Last().Value;
                double deg = (dynamic)tmpFirst.polynom.Last().Key - pol2.polynom.Last().Key;
                obj.Add(num, deg);
                Polynom<T> tmpP = (Polynom<T>)pol2.Clone();
                foreach (KeyValuePair<double, T> item in pol2.polynom.Reverse())
                {
                    tmpP.polynom.Remove(item.Key);
                    tmpP.Add((dynamic)item.Value * num, deg + item.Key);
                    
                }
                tmpFirst = tmpFirst - tmpP;
                
                if (tmpFirst.polynom.Count == 0 || pol2.polynom.Count == 0 || step == 10000)
                    break;
                step++;
            }
            return obj;
        }

        //public static Polynom<T> operator ==(Polynom<T> pol1, Polynom<T> pol2)
        //{
        //    //foreach (KeyValuePair<double, T> item1 in pol1.polynom)
        //    //{
        //    //    foreach (KeyValuePair<double, T> item2 in pol2.polynom)
        //    //    {
        //    //        if()
        //    //    }

        //    //}
        //}

        public static Polynom<T> operator ^(Polynom<T> pol1, double deg)
        {
            Polynom<T> Pol = (Polynom<T>)pol1.Clone(), res = (Polynom<T>)pol1.Clone();
            if(deg == 0)
            {
                res = pol1 / pol1;
                return res;
            }
            for (int i = 1; i < Math.Abs(deg); i++)
                res = res * Pol;
            return res;
        }

        public T Point(double num)
        {
            T result = new T();
            foreach (KeyValuePair<double, T> item in this.polynom)
                result = result  + (dynamic)item.Value * Math.Pow(num, item.Key);
            return result;
        }

        public Polynom<T> Super(Polynom<T> pol)
        {
            Polynom<T> obj = new Polynom<T>();
            foreach (KeyValuePair<double, T> item1 in this.polynom)
            {
                double tmpPow = item1.Key;
                Polynom<T> tmpRes = pol ^ tmpPow;
                T c = item1.Value;
                foreach (KeyValuePair<double, T> item2 in tmpRes.polynom)
                {
                   //(*jt).set_coef(c * item2.Value);
                    obj.Add((dynamic)c * item2.Value, item2.Key);
                }
            }
            return obj;
        }

        public void Print()
        {
            foreach(KeyValuePair<double, T> item in this.polynom)
            {
                if(item.Value != (dynamic)0)
                    Console.Write("+" + item.Value.ToString() + "x^" + item.Key);
            }
            Console.WriteLine();
        }
        public object Clone()
        {
            Polynom<T> res = new Polynom<T>(); 
            foreach(KeyValuePair<double, T> item in this.polynom)
            {
                res.Add(item.Value, item.Key);
            }
            return new Polynom<T>
            {
                polynom = res.polynom
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var coef in this.polynom.Values)
            {
                yield return coef;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Polynom<T> pol)
        {
            return this.polynom.Keys.Max().CompareTo(pol.polynom.Keys.Max());
        }

        int IComparable.CompareTo(object obj)
        {
            if(!(obj is Polynom<T>))
                return 0;
            return CompareTo((Polynom<T>)obj);
        }
    }
}
