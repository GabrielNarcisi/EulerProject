using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class LargestExponential : IProblem
    {
        public long Solve()
        {
            List<double> BigList = Properties.Resources.p099_base_exp.Split("\n").Select(ToComparableValue).ToList();
            return BigList.IndexOf(BigList.Max()) + 1;
        }

        private double ToComparableValue(string str)
        {
            var splited = str.Split(",");
            if(splited.Length == 2)
                return Math.Log(double.Parse(splited[0])) * double.Parse(splited[1]);
            return 0;
        }
    }
}
