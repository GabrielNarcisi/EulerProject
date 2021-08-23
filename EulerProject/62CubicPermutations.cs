using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace EulerProject
{
    class CubicPermutations : IProblem
    {
        public long Solve()
        {
            var list = new Dictionary<long,BigInteger>();
            long i = 1;
            int count = 0;
            long result = 0;
            while(result == 0)
            {
                i++;
                BigInteger pow = BigInteger.Pow(i, 3);
                list = list.Where(pair => HasSameDigitCount(pair.Value, pow)).ToDictionary(pair => pair.Key, pair => pair.Value);
                var where = list.Where(pair => IsPermutation(pair.Value, pow));
                count = where.Count();
                if( count >= 4)
                    result = where.Min(pair => pair.Key);
                list.Add(i, pow);
            }
            return result;
        }
        private bool HasSameDigitCount(BigInteger x, BigInteger y)
        {
            return x.ToString().Length == y.ToString().Length;
        }
        private bool IsPermutation(BigInteger x, BigInteger y)
        {
            var dicX = x.ToString().GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
            var dicY = y.ToString().GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
            return dicX.All(pair => dicY.Contains(pair)) && dicY.All(pair => dicX.Contains(pair));
        }
    }
}
