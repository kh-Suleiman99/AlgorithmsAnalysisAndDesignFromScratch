namespace BinarySearch
{
    internal class Program
    {
        static int BinarySerch(int[] arr,int key)
        {
            int low = 0;
            int high = arr.Length-1;
            int mid = 0;
            while (low <= high)
            {
                mid = (high + low) / 2;
                if (arr[mid] == key)
                {
                    return mid;
                }
                else 
                { 
                    if (key > arr[mid])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int index= BinarySerch(arr, 2);
            Console.WriteLine($"The target in arr[{index}]");
        }
    }
}