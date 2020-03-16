using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    class Methods
    {
        public static string NewSystem(int num, decimal frac, int syst)
        {
            List<char> intList = new List<char>();
           
            while ((num / syst) != 0)
            {
                if (num % syst > 9)
                    intList.Add((char)(num % syst + 'A' - 10));
                else
                    intList.Add((char)(num % syst + '0'));
                num /= syst;
            }

            if (num % syst > 9)
                intList.Add((char)(num % syst + 'A' - 10));
            else
                intList.Add((char)(num % syst + '0'));

            intList.Reverse();
            var res = String.Empty;
            res = String.Concat(intList);
            res += ',';
            res += fracSys(frac, syst);
            return res;
        }

        public static string fracSys(decimal frac, int syst)
        {
            var residueList = new List<decimal>();
            var res = String.Empty;
            var i = 0;
            while (frac >= (decimal)0.01 && i <= 10)
            {
                if(residueList.Contains(frac))
                {
                    var tmp = res.Substring(residueList.IndexOf(frac));
                    res = res.Substring(0, residueList.IndexOf(frac));
                    res += "(" + tmp + ")";
                    break;
                }
                i++;
                residueList.Add(frac);
                
                frac *= syst;
                if (Math.Truncate(frac) <= 9)
                    res += (char)(Math.Truncate(frac) + '0');
                else if (Math.Truncate(frac) >= 10)
                    res += (char)(Math.Truncate(frac) + 'A' - 10);
                frac -= Math.Truncate(frac);
            }
            return res;
        }
    }
}
