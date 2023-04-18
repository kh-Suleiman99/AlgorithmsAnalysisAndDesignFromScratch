namespace SegregatePositiveAndNegative
{
    internal class Program
    {
        static void Segregate(int[] array, int start, int end)
        {
            if (start >= end) return;

            int mid = (start + end) / 2;
            Segregate(array, start, mid);
            Segregate(array, mid+1, end);
            MergeSegregate(array, start, mid, end);
        }
        static void MergeSegregate(int[] array, int start, int midPoint, int end)
        {
            int i, j, k;
            int left_length = midPoint - start + 1;
            int right_length = end - midPoint;
            int[] left_array = new int[left_length];
            int[] right_array = new int[right_length];
            for (i = 0; i < left_length; i++)
            {
                left_array[i] = array[start + i];
            }
            for (j = 0; j < right_length; j++)
            {
                right_array[j] = array[midPoint + 1 + j];
            }
            i = j = 0;
            k = start;
            while (i < left_length && left_array[i] < 0)
            {
                array[k] = left_array[i];
                i++;
                k++;
            }
            while (j < right_length && right_array[j] < 0)
            {
                array[k] = right_array[j];
                j++;
                k++;
            }
            while (i < left_length)
            {
                array[k] = left_array[i];
                i++;
                k++;
            }
            while (j < right_length)
            {
                array[k] = right_array[j];
                j++;
                k++;
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 5,-1,2,-10,3,-6,-22,7};
            Console.WriteLine(string.Join(", ", array));
            Segregate(array, 0, array.Length-1);
            Console.WriteLine(string.Join(", ", array));
        }
    }
}