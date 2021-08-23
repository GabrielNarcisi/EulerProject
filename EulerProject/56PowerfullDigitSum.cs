using System;
using System.Linq;
using System.Numerics;

namespace EulerProject
{
    internal class PowerfullDigitSum : IProblem
    {
        public long Solve()
            => (long)Enumerable.Range(2, 98).SelectMany(i => Enumerable.Range(2, 98), (a, b) => DigitSum(BigInteger.Pow(a, b))).Max();

        private static double DigitSum(BigInteger n)
            => n.ToString().Sum(c => double.Parse(c.ToString()));
    }
}