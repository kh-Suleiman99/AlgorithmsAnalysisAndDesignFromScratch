namespace InsertionSortCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 9, 2, 7, 1 };
            Console.WriteLine("UnSorted array:    [{0}]", string.Join(", ", x));
            InsertionSort(x);
            Console.WriteLine("Sorted   array:    [{0}]", string.Join(", ", x));
        }

        static void InsertionSort(int[] x)
        {
            int key = 0,j=0;
            for(int i = 1; i < x.Length; i++)
            {
                key = x[i];
                for(j = i - 1; j >= 0; j--)
                {
                    if (key < x[j])
                        x[j + 1] = x[j];
                    else 
                        break;
                }
                x[j+1] = key;
            }
        }
    }
}