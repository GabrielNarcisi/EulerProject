using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class PrimePowerTriple : IProblem
    {
        public long Solve()
        {
            long max = 50_000_000;
            var listPrime = TotientMaximum.GetListPrime((int)Math.Sqrt(max));
            var listPrimeSquared = listPrime.Select(n => n * n).Where(n => n < max);
            var listPrimeCubed = listPrime.Where(n => n < Math.Pow(max, (1.0 / 3.0))).Select(n => n * n * n).Where(n => n < max && n > 0);
            var listPrimeFourth = listPrime.Where(n => n < Math.Pow(max, (1.0 / 4.0))).Select(n => n * n * n * n).Where(n => n < max && n > 0);
            var all = listPrimeFourth.SelectMany(n => listPrimeCubed.Select(m => n + m)).Where(n => n < max && n > 0).Distinct();
            all = all.SelectMany(n => listPrimeSquared.Select(m => m + n)).Where(n => n < max && n > 0).Distinct();
            return all.Count();
        }
    }
}
