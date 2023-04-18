namespace CircleAreaCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("please enter the radius: ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Circle area is {CircleArea(r)}");
        }

        static double CircleArea(double r)
        {
            double a = Math.PI * (r * r);
            return a;
        }
    }
}