using System.Collections.Generic;
using System.Linq;
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
    }
}
