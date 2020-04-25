using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public sealed class Event : EventArgs
    {
        private Complex num1;
        private Complex num2;

        public Event(Complex com1, Complex com2)
        {
            num1 = com1;
            num2 = com2;
        }

        public override string ToString()
        {
            return $"Деление на ноль {num1} / {num2}";
        }
    }
}
