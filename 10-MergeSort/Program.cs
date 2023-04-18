namespace MergeSortCode
{
    internal class Program
    {
        static void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end) return;
            int mid= (start+end)/2;
            MergeSort(arr, start, mid);
            MergeSort(arr, mid+1, end);
            Merge(arr,start, mid, end);
        }
        static void Merge(int[] arr,int start, int mid, int end)
        {
            int i, j, k;
            int left_length = mid - start + 1;
            int right_length = end - mid;
            int[] left_arr = new int[left_length];
            int[] right_arr = new int[right_length];
            for(i= 0;i< left_length; i++)
            {
                left_arr[i]= arr[start+i];
            }
            for (j = 0; j < right_length; j++)
            {
                right_arr[j] = arr[mid + 1 + j];
            }
            i = 0;
            j = 0;
            k = start;
            while(i< left_length && j<right_length) 
            {
                if (left_arr[i] < right_arr[j])
                {
                    arr[k] = left_arr[i];
                    i++;
                }
                else 
                {
                    arr[k] = right_arr[j];
                    j++;
                }
                k++;
            }
            while(i < left_length)
            {
                arr[k] = left_arr[i];
                i++;
                k++;
            }
            while(j < right_length)
            {
                arr[k] = right_arr[j];
                j++;
                k++;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 6,1,4,2,10,20,15 };
            Console.WriteLine(string.Join(", ",arr));
            MergeSort(arr, 2, arr.Length-1);
            Console.WriteLine(string.Join(", ", arr));

        }
    }
}