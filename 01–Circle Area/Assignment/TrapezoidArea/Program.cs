namespace TrapezoidArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The trapezoid area is {TrapezoidArea(32, 30, 18)}");
            Console.WriteLine($"The trapezoid area is {TrapezoidArea(21, 31, 5)}");
        }

        static float TrapezoidArea(float a, float b, float h)
        {
            float area = 0.5f * (a + b) * h;
            return area;
        }
    }
}