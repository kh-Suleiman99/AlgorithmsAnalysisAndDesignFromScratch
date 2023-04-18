namespace ActivitySelection
{
    internal class Program
    {
        static List<int> ActivitySelectionByGreedyStrategy(List<int> start, List<int> end)
        {
            List<int> result= new() { 0 };
            int j=0;
            for(int i = 1; i< start.Count; i++)
            {
                if (start[i] >= end[j])
                {
                    result.Add(i);
                    j = i;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> start = new() { 9, 10, 11, 12, 13, 15 };
            List<int> end = new() { 11, 11, 12, 14, 15, 16 };
            Console.WriteLine(String.Join(", ", ActivitySelectionByGreedyStrategy(start, end)));
            
        }
    }
}