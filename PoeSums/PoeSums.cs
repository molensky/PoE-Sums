using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PoeSums.Combinatorics;


namespace PoeSums
{
    public class PoeSums
    {
        private const int MaxSingleScore = 20;
        private const int BestTotal = 40;
        public List<List<int>> BestMatch { get; } = new List<List<int>>();
        public int Total { get; private set; }
        
        public void GetMatches(int[] inputValues)
        {
            if (!inputValues.Any())
            {
                BestMatch.Add(new List<int>());
                return;
            }

            var numberOfTwenties = inputValues.Count(i => i == MaxSingleScore);
            if (numberOfTwenties > 0)
            {
                BestMatch.AddRange(Enumerable.Repeat( new[] {MaxSingleScore}.ToList(), numberOfTwenties));
                Total += numberOfTwenties * MaxSingleScore;
            }

            var strippedInputList = new List<int>(from i in inputValues where i > 0 && i < MaxSingleScore select i);
            var strippedSum = strippedInputList.Sum();
            Total += strippedSum;
            bool NoTwentiesAndStrippedSumBelowThreshold(int x) => numberOfTwenties < 1 && (!strippedInputList.Any() || strippedSum < x);

            if (NoTwentiesAndStrippedSumBelowThreshold(BestTotal))
            {
                BestMatch.Add(new List<int>());
               return;
            }

            if (strippedInputList.Any() && strippedSum == BestTotal)
            {
                BestMatch.Add(strippedInputList);
                return;
            }

            // var inputCounts = GetItemCount(strippedInputList);

            var minSum = FindMinFortyCombo(strippedInputList);
            while (minSum.Any())
            {
                BestMatch.Add(minSum);
                foreach (var i in minSum)
                {
                    strippedInputList.Remove(i);
                }
                minSum = FindMinFortyCombo(strippedInputList);
            }

            /*
            var possibleSums = CreateComboLists(strippedInputList, BestTotal);
            while (possibleSums.Any())
            {
                var minSum = (from s in possibleSums select s.Count).Min();
                var minSumList = (from s in possibleSums where s.Count == minSum select s).First();
                var minSumItemCount = GetItemCount(minSumList);
                
                BestMatch.Add(minSumList);
                possibleSums.Remove(minSumList);
                foreach (var item in minSumList.Distinct())
                {
                    inputCounts[item] -= minSumItemCount[item];
                }

                var deleteList = new List<int>();
                for (var i = 0; i < possibleSums.Count; i++)
                {
                    var tempInputCounts = inputCounts.ToDictionary(entry => entry.Key, entry => entry.Value);
                    var repeatedSum = 0;
                    foreach (var j in possibleSums[i])
                    {
                        if (tempInputCounts[j] > 0)
                        {
                            tempInputCounts[j] -= 1;
                        } 
                        else 
                        {
                            repeatedSum += j;
                        }
                    }
                    if (repeatedSum > 0)
                        deleteList.Add(i);
                }
                
                foreach (var i in deleteList.OrderByDescending(j => j))
                {
                    possibleSums.RemoveAt(i);
                }
            }
            */
            
            
        }

        public List<int> FindMinFortyCombo(List<int> inputList)
        {
            var retVal = new List<int>();
            for (var i = 3; i <= inputList.Count(); i++)
            {
                var combos = new Combinations<int>(inputList.ToArray(), i);
                if (combos.Any(l => l.Sum() == BestTotal))
                {
                    retVal = (List<int>) combos.First(l => l.Sum() == BestTotal);
                    break;
                }
            }
            return retVal;
        }

        /*
        public Dictionary<int, int> GetItemCount(List<int> l)
        {
            return l.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }
        */

        /*
        public List<List<int>> CreateComboLists(List<int> inputList, int desiredSum)
        {
            var retVal = new List<List<int>>();
            var temp = new List<int>();
            var count = Math.Pow(2, inputList.Count);
            for (var i = 1; i <= count - 1; i++)
            {
                var str = Convert.ToString(i, 2).PadLeft(inputList.Count, '0');
                if (str.Count(f => f == '1') < 3) continue;
                for (var j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        temp.Add(inputList[j]);
                    }
                }
                if (temp.Sum() == BestTotal)
                {
                    retVal.Add(temp);
                    temp = new List<int>();
                }
                else
                {
                    temp.Clear();
                }
            }
            return retVal;
        }
        */
    }
}
