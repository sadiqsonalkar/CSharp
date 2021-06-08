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
            int a, b = 1;
            Console.WriteLine("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= a; i++)
                b = b * i;
            Console.WriteLine("Factorial of {0}", a);
            Console.WriteLine("{0}", b);
            Console.Read();
        }
    }
}
