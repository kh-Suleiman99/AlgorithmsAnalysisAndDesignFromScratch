namespace FractionalKnapsackProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 4, 9, 12, 11, 6, 5 };
            int[] weights = { 1, 2, 10, 4, 3, 5 };

            int length = values.Length;
            Item[] items = new Item[length];
            int i;
            for (i = 0; i < length; i++)
            {
                items[i] = new Item($"#{i}" ,values[i], weights[i]); 
            }
            items = items.OrderByDescending(i => i.ratio).ToArray();
            foreach(Item item in items)
            {
                Console.WriteLine(item.ToString());
            }

            Knapsack bag = new Knapsack(12);
            i = 0;
            while (bag.currentCapacity < bag.maxCapacity)
            {
                bag.AddItem(items[i]);
                i++;
            }
            Console.WriteLine("in Knapsack");
            foreach (Item item in bag.items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("total weight is " + bag.maxCapacity);
            Console.WriteLine("total value is "+bag.totalValue);
        }
    }
}