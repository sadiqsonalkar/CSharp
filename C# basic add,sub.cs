using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d;
            Console.WriteLine("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());
            c = a + b;
            Console.WriteLine("{0}+{1}={2}", a, b, c);
            d = a - b;
            Console.WriteLine("{0}-{1}={2}", a, b, d);
            Console.Read();
        }
    }
}
