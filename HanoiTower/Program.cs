using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HanoiTower("source", "destination", "extra", 4);
            Console.WriteLine(counter);
            Console.ReadKey();
        }
        static int counter = 0;
        public static void HanoiTower(string source, string destination, string extra, int n)
        {
            counter++;
            if (n <= 0) return;
            HanoiTower(source, extra, destination, n - 1);
            Console.WriteLine(counter);
            Console.WriteLine($"Moving from {source} to {destination} the amount: {n}");
            HanoiTower(extra, destination, source, n - 1);
        }
    }
}
