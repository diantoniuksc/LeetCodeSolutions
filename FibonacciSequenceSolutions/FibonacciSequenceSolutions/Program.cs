using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequenceSolutions
{
    /// <summary>
    /// Task: find the n-th element of the Fibonacci sequense: 0, 1, 1, 2, 3, 5...
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Int64 n = 50;

            DateTime date1 = DateTime.Now;
            /*Console.WriteLine(Fib(n).ToString());
            DateTime date2 = DateTime.Now;
            TimeSpan interval = date2 - date1;
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.TotalMilliseconds);

            Console.WriteLine();

            date1 = DateTime.Now;
            Console.WriteLine(FibWithHash(n).ToString());
            date2 = DateTime.Now;
            interval = date2 - date1;
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.TotalMilliseconds);
            //Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Nanoseconds Component:", interval.TotalNanoseconds);

            Console.WriteLine();*/

            date1 = DateTime.Now;
            Console.WriteLine(FibWithFor(n).ToString());
            DateTime date2 = DateTime.Now;
            TimeSpan interval = date2 - date1;
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.TotalMilliseconds);

            Console.ReadKey();
        }

        /// <summary>
        /// Fibonacci top-bottom without Hash.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// Fibonacci top-bottom with Hash.
        /// </summary>
        static Dictionary<int, int> map = new Dictionary<int, int>();
        static int FibWithHash(int n)
        {

            if (n == 0) return 0;
            if (n == 1) return 1;
            
            if (map.ContainsKey(n))
            {
                return map[n];
            }
            else
            {
                return map[n] = Fib(n - 1) + Fib(n - 2);
            }
        }

        /// <summary>
        ///  Fibonacci bottom-up without Hash.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static Int64 FibWithFor(Int64 n)
        {
            Int64[] fibArr = new Int64[n + 1];
            fibArr[0] = 0;
            fibArr[1] = 1;

            for(Int64 i = 2; i <= n; i++)
            {
                fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
            }
            return fibArr[n];
        }
    }
}
