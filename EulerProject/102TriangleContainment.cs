using System;
using System.Collections.Generic;
using System.Text;

namespace EulerProject
{
    class TriangleContainment : IProblem
    {
        public long Solve()
        {
            List<Point> triangle = new List<Point>()
            {
                new Point(-340,495),
                new Point(-153,-910),
                new Point(835,-947)
            };
            List<Point> triangle2 = new List<Point>()
            {
                new Point(-175,41),
                new Point(-421,-714),
                new Point(574,-645)
            };
            foreach (Point pt in triangle)
            {
                Console.WriteLine((double)pt.y / pt.x);
            }
            foreach (Point pt in triangle2)
            {
                Console.WriteLine((double)pt.y / pt.x);
            }
            Console.WriteLine(IsOpposite(triangle[0], triangle[1]));
            Console.WriteLine(IsOpposite(triangle[0], triangle[2]));


            return 0;
        }

        private bool IsOpposite(Point pt1, Point pt2)
        {
            return Math.Sign(pt1.x) != Math.Sign(pt2.x) && Math.Sign(pt1.y) != Math.Sign(pt2.y);
        }
    }
}
