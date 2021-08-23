using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Resources;
using System.Linq;

namespace EulerProject
{
    sealed class Node
    {
        public int x;
        public int y;
        public int weight;

        public bool seen = false;

        public Node top;
        public Node bottom;
        public Node right;
        public Node left;

        public Node(int x, int y, int weight)
        {
            this.x = x;
            this.y = y;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"({x},{y}) = {weight}";
        }
    }
    class PathSum : IProblem
    {
        public long Solve()
        {
            List<List<int>> matrix = new List<List<int>>()
            {
                new List<int>(){131, 673, 234, 103, 18},
                new List<int>(){201,96,342,965,150},
                new List<int>(){630,803,746,422,111},
                new List<int>(){537,699,497,121,956},
                new List<int>(){805,732,524,37,331},
            };
            ShowMatrix(matrix);
            Console.WriteLine("\n");
            Console.WriteLine(GetPathMatrix(matrix));
            var file = Properties.Resources.p081_matrix;
            var BigMatrix = FileToMatrix(file);

            return GetPathMatrix(BigMatrix);
        }

        private void ShowMatrix(List<List<int>> matrix)
        {
            foreach (var line in matrix)
            {
                foreach (var cell in line)
                {
                    Console.Write(cell);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        private int GetPathMatrix(List<List<int>> matrix)
        {
            int count = matrix.Count;
            Node topLeft = new Node(0, 0, matrix[0][0]);
            Node curr = topLeft;
            List<Node> listNode = new List<Node>
            {
                curr
            };
            while (!listNode.Any(node => node.x == count -1 && node.y == count -1))
            {
                curr = listNode.Where(node => !node.seen).OrderBy(node => node.weight).First();
                curr.seen = true;
                if (curr.x < count - 1 && !listNode.Any(node => node.x == curr.x + 1 && node.y == curr.y))
                { 
                    curr.right = new Node(curr.x + 1, curr.y, curr.weight + matrix[curr.y][curr.x + 1]);
                    listNode.Add(curr.right);
                }
                if(curr.y < count - 1 && !listNode.Any(node => node.x == curr.x && node.y == curr.y+1))
                {
                    curr.bottom = new Node(curr.x, curr.y +1, curr.weight + matrix[curr.y +1][curr.x]);
                    listNode.Add(curr.bottom);
                }
                if(curr.y > 0 && !listNode.Any(node => node.x == curr.x && node.y == curr.y-1))
                {
                    curr.top = new Node(curr.x, curr.y -1, curr.weight + matrix[curr.y -1][curr.x]);
                    listNode.Add(curr.top);
                }
                if (curr.x > 0 && !listNode.Any(node => node.x == curr.x - 1 && node.y == curr.y))
                {
                    curr.left = new Node(curr.x - 1, curr.y, curr.weight + matrix[curr.y][curr.x - 1]);
                    listNode.Add(curr.left);
                }
            }

            return listNode.First(node => node.x == count - 1 && node.y == count - 1).weight;
        }
        private List<List<int>> FileToMatrix(String reader)
        {
            var result = new List<List<int>>();
            var splitedFile = reader.Trim().Split("\n");
            foreach(string line in splitedFile)
            {
                var resultLine = new List<int>();
                var splitedLine = line.Split(",");
                foreach(string cell in splitedLine)
                {
                    resultLine.Add(int.Parse(cell));
                }
                result.Add(resultLine);
            }
            return result;
        }
    }
}
