using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EulerProject
{
    class CountingSummations : IProblem
    {
        public long Solve()
        {

            var list = new Dictionary<int, Dictionary<int,int>>()
            {
                { 1, new Dictionary<int,int>()
                    {
                    {1,1 }
                    }
                }
            };
            for (int i = 2; i <= 100; i++)
            {
                list.Add(i, new Dictionary<int, int>());
                foreach (var listofNum in list)
                {
                    if (listofNum.Key != i)
                    {
                        if(listofNum.Value.ContainsKey(i - listofNum.Key))
                            list[i].Add(i - listofNum.Key, listofNum.Value[i - listofNum.Key]);
                        else
                            list[i].Add(i - listofNum.Key, listofNum.Value[listofNum.Key]);
                    }
                       
                }
                list[i][i] = 1;
                list[i] = ConcatenateList(list[i]);
            }

            return list[100][100] -1;
        }

        private Dictionary<int, int> ConcatenateList(Dictionary<int, int> dictionary)
        {
            var result = new Dictionary<int, int>().OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair =>pair.Value);
            var orderredDictionary = dictionary.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            int value = 0;
            foreach(var pair in orderredDictionary)
            {
                value += pair.Value;
                result.Add(pair.Key, value);
            }
            return result;

        }
    }
}
