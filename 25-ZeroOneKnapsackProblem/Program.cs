using System.Collections.Generic;

namespace ZeroOneKnapsackProblem
{
    public class item
    {
        public string name;
        public int weight;
        public int profit;

        public item(string name, int weight, int profit)
        {
            this.name = name;
            this.weight = weight;
            this.profit = profit;
        }
        public override string ToString()
        {
            return $"name: {name}, weight: {weight}, profit: {profit}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            item[] items = new item[]
            {
                new item("#0", 0, 0),
                new item("#1", 1, 4),
                new item("#2", 3, 9),
                new item("#3", 5, 12),
                new item("#4", 4, 11),
            };
            int maxWeight = 8;
            int itemLength = items.Length;
            int[,] db = new int[itemLength, maxWeight+1];
            int i, j;
            for (i = 0; i < itemLength; i++)
            {
                for (j = 0; j <= maxWeight; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        db[i, j] = 0;
                    }
                    else if (j >= items[i].weight)
                    {
                        db[i, j] = Math.Max(db[i-1, j], items[i].profit + db[i-1, j- items[i].weight]);
                    }
                    else
                    {
                        db[i, j] = db[i-1, j];
                    }
                }
            }
            /*
             * 
            i = 1;
            foreach(var item in db)
            {
                Console.Write(item.ToString("00")+" ");
                if (i % 9 == 0)
                {
                    Console.WriteLine();
                }
                i++;
            }

            */

            int remain = j = maxWeight;
            i = items.Length-1;
            List<string> solution= new List<string>();
            while(remain>=0 && j > 0)
            {
                if (db[i,j] > db[i-1, j])
                {
                    solution.Add(items[i].name);
                    remain -= items[i].weight;
                    j = remain;
                    i--;
                }
                else
                {
                    i--;
                }

            }
            foreach(var str in solution)
            {
                Console.Write(str+" ");
            }
        }
    }
}