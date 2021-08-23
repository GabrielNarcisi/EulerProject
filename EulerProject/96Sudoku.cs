using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class Grid
    {
        public List<List<Case>> listNumbers;
        public Grid()
        {
            listNumbers = new List<List<Case>>(9);
            for(int i = 0; i < 9; i++)
            {
                listNumbers.Add(new List<Case>(9));
            }
        }
        public void AddLine(string line, int index)
        {
            foreach(char c in line)
            {
                listNumbers[index].Add(new Case(int.Parse((c.ToString()))));
            }
        }
        private int SearchPossibleValues()
        {
            int count = 0;
            int cur = 0;
            do
            {
                cur = 0;
                int i = 0;
                foreach (var line in listNumbers)
                {
                    int j = 0;
                    foreach (Case c in line)
                    {
                        if (!c.IsSet())
                        {
                            c.Reduce(line);
                            c.Reduce(GetColumn(j));
                            c.Reduce(GetBox(i, j));
                            if (c.possibleValue.Count == 1)
                            {
                                c.value = c.possibleValue[0];
                                cur++;
                            }
                        }
                        j++;
                    }
                    i++;
                }
                count += cur;
            } while (cur > 0);
            return count;
        }
        public int Reduce()
        {
            int count = SearchPossibleValues();
            for(int i =0; i<3; i++)
                for (int j = 0; j < 3; j++)
                    count += ReduceList(GetBox(i * 3, j * 3));

            foreach (var line in listNumbers)
                count += ReduceList(line);

            for (int i = 0; i < 9; i++)
                count += ReduceList(GetColumn(i));

            return count;

        }
        private int ReduceList(List<Case> list)
        {
            int count = 0;
            foreach (int p in Case.POSSIBILITIES)
            {
                if (list.Count(c => !c.IsSet() && c.possibleValue.Contains(p)) == 1)
                {
                    list.Find(c => !c.IsSet() && c.possibleValue.Contains(p)).value = p;
                    count++;
                    count += SearchPossibleValues();
                }
            }
            return count;
        }
        public List<Case> GetBox(int i, int j)
        {
            List<Case> result = new List<Case>();
            for (int ii = i - i % 3; ii < i - i % 3 + 3; ii++)
                for (int jj = j - j % 3; jj < j - j % 3 + 3; jj++)
                    result.Add(listNumbers[ii][jj]);
            return result;
        }
        public List<Case> GetColumn(int i)
        {
            List<Case> result = new List<Case>();
            foreach (var line in listNumbers)
            {
                result.Add(line[i]);
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach(var line in listNumbers)
            {
                int j = 0;
                foreach(var c in line)
                {
                    sb.Append(c.value + " ");
                    if(j%3 == 2)
                        sb.Append("|");
                    j++;
                }
                sb.Append("\n");
                if (i % 3 == 2)
                    sb.Append("___________\n");   
                i++;
            }
            return sb.ToString();
        }

        internal long GetResult()
        {
            return long.Parse("" + listNumbers[0][0].value + listNumbers[0][1].value + listNumbers[0][2].value);
        }
    }
    class Case
    {
        static readonly public int[] POSSIBILITIES = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> possibleValue;
        public int value;
        public Case(int value)
        {
            this.value = value;
            possibleValue = new List<int>();
            if (IsSet())
                possibleValue.Add(value);
            else
                possibleValue.AddRange(POSSIBILITIES.ToList());
        }
        public bool IsSet()
        {
            return value > 0 && value < 10;
        }
        public void Reduce(List<Case> list)
        {
            possibleValue.RemoveAll(n => list.Where(c => c.IsSet()).Select(c => c.value).Contains(n));
        }

        public override string ToString()
        {
            if (IsSet())
                return "Set: " + value;
            else
            {
                StringBuilder result = new StringBuilder("Possibilities: ");
                foreach(int n in possibleValue)
                {
                    result.Append(n);
                }
                return result.ToString();
            }
        }
    }
    class Sudoku : IProblem
    {
        public long Solve()
        {
            string sudoku = Properties.Resources.p096_sudoku_modif;
            string[] lines = sudoku.Split("\n");
            long result = 0;
            //for(int NGrid = 5; NGrid < 6; NGrid++)
            for (int NGrid = 0; NGrid < 50; NGrid++)
            {
                Grid grid = new Grid();
                for (int i = 1; i <= 9; i++)
                {
                    grid.AddLine(lines[i + NGrid*10],i-1);
                }
                //Console.WriteLine(grid);
                while (grid.Reduce() > 0)
                {
                    //Console.WriteLine("Grid :"+ NGrid + " : " + grid.listNumbers.Sum(line => line.Count(c => !c.IsSet())));
                }
                long cur = grid.GetResult();
                if (cur.ToString().Contains('0'))
                {
                    Console.WriteLine(NGrid);
                    Console.WriteLine(grid);
                }
                result += result;
            }
            return result;
        }
    }
}
