using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    struct Point
    {
        public int x;
        public int y;
        public static readonly Point ORIGIN = new Point(0,0);
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int LenghtSquare(Point pt)
        {
            return (int)(Math.Pow(x - pt.x, 2) + Math.Pow(y - pt.y, 2));
        }
        public bool IsRectangleWithOrigin(Point pt) 
        {
            List<int> length = new List<int>(3)
            {
                LenghtSquare(pt),
                LenghtSquare(ORIGIN),
                pt.LenghtSquare(ORIGIN),
            };
            length.Sort();
            return length[0] + length[1] == length[2];
        }
        public override bool Equals(Object obj)
        {
            return obj is Point point && point.x == x && point.y == y;
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
    class RightTriangles : IProblem
    {
        public long Solve()
        {
            List<Point> listPoint = new List<Point>();
            List<Point> pointPassed = new List<Point>();
            int size = 50;
            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    listPoint.Add(new Point(i, j));
                }
            }
            int result = 0;
            foreach (Point point1 in listPoint.Where(p => !p.Equals(Point.ORIGIN)))
            {
                pointPassed.Add(point1);
                foreach (Point point2 in listPoint.Where(p => !p.Equals(Point.ORIGIN) && !pointPassed.Contains(p)))
                {
                    if (point1.IsRectangleWithOrigin(point2))
                        result++;
                    Console.WriteLine($"Triangle (0,0) {point1} {point2} Rectangle : {point1.IsRectangleWithOrigin(point2)}");
                }
            }

            return result;
        }
    }
}
