using System;
using System.Collections.Generic;
using System.Numerics;

namespace EulerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            long response = new OddPeriodsSquareRoots().Solve();
            Console.WriteLine("\nThe result is :");
            Console.WriteLine(response);
        }

    }
}


