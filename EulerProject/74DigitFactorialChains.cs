using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class DigitFactorialChains : IProblem
    {
        public long Solve()
        {
            var list = new List<long>();
            long result = 0;
            for(int i = 0; i <1_000_000; i++)
            {
                long count = 0;
                long n = i;
                while (!list.Contains(n))
                {
                    list.Add(n);
                    n = SumOfFactionalDigit(n);
                    count++;
                }
                Console.WriteLine($"{i} has {count} repetition");
                if (count >= 60)
                    result++;
                list.Clear();
              
            }
            return result;
        }

        private long SumOfFactionalDigit(long n)
        {
            return n.ToString().Sum(c => Factoriel(long.Parse(c.ToString())));
        }

        private long Factoriel(long n) => n < 2 ? 1 : Factoriel(n - 1) * n;
    }
}
