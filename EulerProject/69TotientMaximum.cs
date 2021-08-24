using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class TotientMaximum : IProblem
    {
        public long Solve()
        {
            long result = 6;
            double max = 3;
            var listPrime = GetListPrime(100);
            int indexPrime = 1;
            int i = 2;
            while(i < 1_000_000)
            {
                int count = RelativePrimeCount(i);
                Console.WriteLine($"phi({i}) = {count}  => phi({i})/{i} = {(double)i/count}");
                if(((double)i / count) > max)
                {
                    max = (double)i / count;
                    result = i;
                }
                i *= listPrime.ElementAt(indexPrime);
                indexPrime++;
            }
            return result;
        }
        private int RelativePrimeCount (int n)
        {
            return Enumerable.Range(1, n).Count(i => !IsCoprime(n,i));
        }

        private bool IsCoprime(int x, int y)
        {
            if (y == 1)
                return false;
            if (y == x)
                return true;
            if (y > x)
                return IsCoprime(y, x);
            return x % y == 0 || Enumerable.Range(2,(int)Math.Sqrt(y)).Any(i => x % i == 0 && y % i == 0);
        }

        public static IEnumerable<int> GetListPrime(int n)
        {
            return Enumerable.Range(2, n - 1).Where(IsPrime);
        }
        private static bool IsPrime(int n)
        {
            if (n == 1 || n == 0)   
                return false;
            if (n == 2)
                return true;
            return !Enumerable.Range(2, (int)Math.Sqrt(n)).Any(i => n % i == 0);
        }
    }
}
