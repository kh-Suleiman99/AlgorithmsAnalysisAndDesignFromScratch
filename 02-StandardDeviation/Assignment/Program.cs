namespace correlationCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            double sx=0, sy=0, sxy=0, numo, deno, ssqx=0, ssqy=0, sqrx, sqry, r;
            double[] x, y;
            Console.Write("n= ");
            n = Convert.ToInt32(Console.ReadLine());
            x = new double[n];
            y = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"x[{i + 1}]= ");
                x[i] = Convert.ToDouble(Console.ReadLine());
                sx += x[i];
                ssqx += Math.Pow(x[i], 2);
                Console.Write($"y[{i + 1}]= ");
                y[i] = Convert.ToDouble(Console.ReadLine());
                sy += y[i];
                ssqy += Math.Pow(y[i], 2);
                sxy += (x[i] * y[i]);
            }
            sqrx = Math.Sqrt(n * ssqx - Math.Pow(sx, 2));
            sqry = Math.Sqrt(n * ssqy - Math.Pow(sy, 2));
            numo = n * sxy - sx * sy;
            deno = sqrx * sqry;
            r = numo / deno;
            Console.WriteLine($"r = {r}");
        }
    }
}