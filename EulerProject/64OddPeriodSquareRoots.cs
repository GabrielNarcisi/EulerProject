using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class OddPeriodsSquareRoots : IProblem
    {
        public long Solve()
        {
            long solution = 0;
            for(int i = 181; i <= 181; i++)
            {
                if (!IsSquare(i))
                {
                    decimal Y = (decimal)Math.Sqrt(i);
                    decimal X = 1 / Y;
                    int rep = -1;
                    int A;
                    do
                    {
                        rep++;
                        Y = X - Math.Floor(X);
                        X = 1 / Y;
                        Console.WriteLine(X);
                        A = (int)Math.Floor(X);

                    }
                    while ( A * A < i);
                    Console.WriteLine(i + " => " + rep);
                    if(rep%2 == 1)
                    {
                        solution++;
                    }

                }
            }
            return solution;
        }

        private bool IsSquare(long n)
        {
            return Math.Sqrt(n) == Math.Floor(Math.Sqrt(n));
        }
    }
}
