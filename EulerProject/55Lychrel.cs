using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace EulerProject
{
    class Lychrel : IProblem
    {
        public long Solve()
        {
            long result = 0;
            for (int i = 0; i <= 10000; i++)
            {
                if (IsLychrel(i))
                    result++;
            }
            return result;
        }
        private static bool IsLychrel(int n)
        {
            BigInteger cur = n;
            for (int i = 0; i < 50; i++)
            {
                cur += Reverse(cur);
                if (IsPalindrome(cur))
                    return false;
            }
            return true;
        }
        private static BigInteger Reverse(BigInteger n)
        {
            string result = "";
            string str = n.ToString();
            foreach (char c in str)
            {
                result = c + result;
            }
            return BigInteger.Parse(result);
        }
        private static bool IsPalindrome(BigInteger n) => IsPalindrome(n.ToString());
        private static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }
    }
}
