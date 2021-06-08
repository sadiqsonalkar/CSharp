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
            int a, b = 0;
            Console.WriteLine("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= a;i ++ )
                if (a % i == 0)
                    b = b + 1;
            if(b==2)
                Console.WriteLine("Prime Number {0}", a);
            else
                Console.WriteLine("Not a Prime number {0}", a);
            Console.Read();
        }
    }
}

