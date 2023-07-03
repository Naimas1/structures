using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structures
{
    struct DecimalNumber
    {
        private int decimalValue;

        public DecimalNumber(int value)
        {
            decimalValue = value;
        }

        public string ToBinary()
        {
            return Convert.ToString(decimalValue, 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(decimalValue, 8);
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(decimalValue, 16);
        }

        public override string ToString()
        {
            return decimalValue.ToString();
        }
    }

    class Programas
    {
        static void Main()
        {
            DecimalNumber decimalNumber = new DecimalNumber(42);

            Console.WriteLine("Decimal Number: " + decimalNumber);
            Console.WriteLine("Binary: " + decimalNumber.ToBinary());
            Console.WriteLine("Octal: " + decimalNumber.ToOctal());
            Console.WriteLine("Hexadecimal: " + decimalNumber.ToHexadecimal());
        }
    }
}
