using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class SquareDigitChain : IProblem
    {
        public long Solve()
        {
            HashSet<long> list89 = new HashSet<long> { 89 };
            HashSet<long> list1 = new HashSet<long> { 1 };
            long roof = 10_000_000;
            for (long i =1; i< roof; i++)
            {
                long cur = i;
                while (!list89.Contains(cur) && !list1.Contains(cur))
                {
                    cur = SumOfSquaredDigits(cur);
                }
                if (list89.Contains(cur))
                {
                    list89.Add(i);

                }
                else
                {
                    list1.Add(i);
                }
            }

            return list89.Count;
        }
        private long SumOfSquaredDigits(long n)
        {
            return (long)n.ToString().Sum(c => Math.Pow(long.Parse(c.ToString()),2));
        }
    }
}
