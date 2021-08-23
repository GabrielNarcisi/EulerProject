using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace EulerProject
{
    class CyclicalFigurateNumbers : IProblem
    {

        public long Solve()
        {
            Random rng = new Random();

            IEnumerable<int> squareOf4Digit = new HashSet<int>(Enumerable.Range(10, 150)).Select(n => n * n).Where(n => n>1_000 && n<10_000);
            IEnumerable<int> triangleOf4Digit = new HashSet<int>(Enumerable.Range(10, 150)).Select(n =>  n * (n + 1)/2).Where(n => n > 1_000 && n < 10_000);
            IEnumerable<int> pentagoneOf4Digit = new HashSet<int>(Enumerable.Range(10, 150)).Select(n => n *(3* n - 1)/2).Where(n => n > 1_000 && n < 10_000);
            IEnumerable<int> hexagonal4Digit = new HashSet<int>(Enumerable.Range(10, 100)).Select(n => n * (2*n-1)).Where(n => n > 1_000 && n < 10_000); 
            IEnumerable<int> heptagone4Digit = new HashSet<int>(Enumerable.Range(10, 100)).Select(n => n * (5 * n - 3) / 2).Where(n => n > 1_000 && n < 10_000); 
            IEnumerable<int> octagonal4Digit = new HashSet<int>(Enumerable.Range(10, 100)).Select(n => n *(3* n -2)).Where(n => n > 1_000 && n < 10_000); 

            List<IEnumerable<int>> listOfSet = new List<IEnumerable<int>>() { squareOf4Digit, triangleOf4Digit, hexagonal4Digit, heptagone4Digit, pentagoneOf4Digit, octagonal4Digit };

            IEnumerable<IEnumerable<int>> w;
            do
            {
                listOfSet = Shuffle(listOfSet, rng);
                w = Walk(listOfSet, 0, new List<IEnumerable<int>>() { listOfSet.First() }, new List<int>());
                w = w.Where(set => PartOfCycle(set.First(), set.Last()));
            } while (!w.Any());

           return w.First().Sum();
        }
        /**
         * true if n1 = 1024 and n2 = 2415
         */
        private IEnumerable<IEnumerable<int>> Walk(List<IEnumerable<int>> listOfSet, int start, List<IEnumerable<int>> listOfSetTemp, IEnumerable<int> partialSolution)
        {
            IEnumerable<IEnumerable<int>> solution = new List<List<int>>();
            foreach (int a in listOfSetTemp.Last())
            {
                if (listOfSet.Count > start+1 && listOfSet[start+1].Any(n => PartOfCycle(n, a)))
                {
                    listOfSetTemp.Add(listOfSet[start + 1].Where(n => PartOfCycle(n, a)));
                    solution = solution.Concat(Walk(listOfSet, start + 1, listOfSetTemp, partialSolution.Append(a)));
                }else if(listOfSet.Count == start + 1)
                {
                    solution = solution.Append(partialSolution.Append(a));
                }
            }
            return solution;    
        }
        private bool PartOfCycle(int n1, int n2)
        {
            return n1.ToString().Substring(0, 2).Equals(n2.ToString().Substring(2, 2));
        }

        private List<T> Shuffle<T>(List<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

    }
}
