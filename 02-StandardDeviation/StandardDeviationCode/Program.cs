namespace StandardDeviationCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sd, a = 0, ave = 0, b;
            int n;
            double[] x;
            Console.Write("n= ");
            n = Convert.ToInt32(Console.ReadLine());
            x = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"x[{i}]= ");
                double.TryParse(Console.ReadLine(), out x[i]);
                ave += x[i];
            }
            ave /= n;
            for (int i = 0; i < n; i++)
            {
                a += Math.Pow(x[i] - ave, 2);
            }
            b = a / n;
            sd = Math.Sqrt(b);
            Console.WriteLine($"sd={sd}");
        }
    }
}