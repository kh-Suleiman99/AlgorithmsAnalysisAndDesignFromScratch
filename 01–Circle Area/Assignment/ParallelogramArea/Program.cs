namespace ParallelogramArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Parallelogram Area is {ParallelogramArea(10, 5)}");
        }

        static float ParallelogramArea(float b,float h)
        {
            float a = b * h;
            return a;
        }
    }
}