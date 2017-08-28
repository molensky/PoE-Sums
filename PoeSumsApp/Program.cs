using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PoeSumsApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputList = args.Select(int.Parse).ToArray();
            var poeSums = new PoeSums.PoeSums();
            poeSums.GetMatches(inputList);
            if (poeSums.BestMatch.Count < 1 || !poeSums.BestMatch[0].Any())
            {
                Console.WriteLine($"No matches found! Total: {poeSums.Total}");
            }
            else
            {
                Console.WriteLine("Best Match:");
                Console.WriteLine();
                foreach (var item in poeSums.BestMatch)
                {
                    item.ForEach(i => Console.Write($"{i} "));
                    Console.WriteLine();
                }
            }
            Console.Write("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
