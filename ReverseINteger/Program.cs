using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReverseINteger
{
    internal class Program
    {
        static void Main(string[] args)
        {///1534236469
            Console.WriteLine(Reverse(1534236469));
            Console.ReadLine();
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-integer/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /*public static int Reverse(int x)
        {
            string number, reversedNumber = null;
            int isNegative = 1;

            if (x >= 0)
                number = x.ToString();
            else
            {
                number = (-x).ToString();
                isNegative = -1;
            }

            for (int j = number.Length - 1; j >= 0; j--)
            {
                reversedNumber += number[j];
            }

            int reversedX;
            if (Int32.TryParse(reversedNumber, out reversedX)) 
                return reversedX * isNegative;
            return 0;
        }*/

        public static int Reverse(int x)
        {
            long reversedNumber = 0;
            int isNegative = 1;
           
            if (x < 0)
                isNegative = -1;
            x *= isNegative;

            while(x > 0)
            {
                int digit = x % 10;
                x = (x - digit) / 10;
                reversedNumber *= 10;
                reversedNumber += digit;
            }

            if (Int32.MinValue <= reversedNumber && Int32.MaxValue >= reversedNumber)
                return (int)reversedNumber * isNegative;
            return 0;
        }
    }
}
