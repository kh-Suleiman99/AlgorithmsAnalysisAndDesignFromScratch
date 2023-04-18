namespace StagecoachProblem
{
    public class state
    {
        public char from;
        public char to;
        public int cost;

        public state(char from, char to, int cost)
        {
            this.from = from;
            this.to = to;
            this.cost = cost;
        }
        public override string ToString()
        {
            return $"from: {from}, to: {to}, cost: {cost}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] lables = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            int[,] data = {
            {0, 2, 4, 3, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 7, 4, 6, 0, 0, 0},
            {0, 0, 0, 0, 3, 2, 4, 0, 0, 0},
            {0, 0, 0, 0, 4, 1, 5, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 4, 0},
            {0, 0, 0, 0, 0, 0, 0, 6, 3, 0},
            {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

            int n = data.GetLength(0);
            int newCost;
            int i, j;
            state[] states = new state[n];
            states[n - 1] = new state(' ', ' ', 0);
            for (i = n-2; i>=0; i--)
            {
                states[i] = new state(lables[i], ' ', Int32.MaxValue);
                for (j = i + 1; j < n; j++)
                {
                    if (data[i, j] == 0) continue;

                    newCost = data[i, j] + states[j].cost;
                    if(newCost < states[i].cost)
                    {
                        states[i].to = lables[j];
                        states[i].cost = newCost;
                    }
                }
            }

            string path = "A";
            i = j = 0;
            while (i < states.Length)
            {
                if (states[i].from == path[j])
                {
                    path += states[i].to;
                    j++;
                }
                i++;
            }

            foreach (state state in states)
            {
                Console.WriteLine(state);
            }
            Console.WriteLine("\nminimum cost = " + states[0].cost);
            Console.WriteLine("minimum path = "+ path);
        }
    }
}