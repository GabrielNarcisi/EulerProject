using System;
using System.Collections.Generic;
using System.Text;

namespace EulerProject
{
    class OrderedFractions : IProblem
    {
        readonly private double TARGET = 3d / 7;
        readonly private long MAX = 1_000_000;
        public long Solve()
        {
            double denUp = 1;
            int i = 1;
            double minNom = -1;
            double minGap = 10;
            while (denUp < MAX)
            {
                while ((double)i / denUp > TARGET && denUp < MAX)
                {
                    denUp++;
                }
                if(minGap > (TARGET - (i / denUp)) && TARGET > (i / denUp))
                {
                    minGap = TARGET - (i / denUp);
                    minNom = i;
                }
                i++;
            }
            return (long)minNom;
        }
    }
}
