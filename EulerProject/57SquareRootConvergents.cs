using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace EulerProject
{
    class SquareRootConvergents : IProblem
    {
        public long Solve()
        {
            BigInteger num = 3;
            BigInteger den = 2;
            long result = 0;
            for(int i = 0; i < 1_000; i++)
            {
                num += 2 * den;
                den = num - den;
                if (den.ToString().Length < num.ToString().Length)
                    result++;
            }
            return result;
        }

    }
}
