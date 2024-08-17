using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dovat
{
    public class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
    }

    public class KnapsackProblem
    {
        public static int SolveKnapsack(Item[] items, int capacity)
        {
            int n = items.Length;
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (items[i - 1].Weight <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - items[i - 1].Weight] + items[i - 1].Value);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, capacity];
        }

    class Program
    {
        static void Main(string[] args)
        {
            Item[] items = {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
                };

            int capacity = 50;
            int maxValue = SolveKnapsack(items, capacity);

            Console.WriteLine("Maximum value:=" + maxValue);

         }
        }
    }
}
