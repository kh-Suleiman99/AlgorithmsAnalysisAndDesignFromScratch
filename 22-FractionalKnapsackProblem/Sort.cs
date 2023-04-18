
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsackProblem
{
    public static class MergeSort
    {
        public static void Sort(Item[] items, int start, int end)
        {
            if (start >= end) return;
            int mid = (start + end) / 2;
            Sort(items, start, mid);
            Sort(items, mid + 1, end);
            Merge(items, start, mid, end);
        }
        private static void Merge(Item[] items, int start, int mid, int end)
        {
            int i, j, k;
            int leftLength = mid - start + 1;
            int rightLength = end - mid;
            Item[] leftArray = new Item[leftLength];
            Item[] rightArray = new Item[rightLength];
            for (i = 0; i < leftLength; i++)
            {
                leftArray[i] = items[i + start];
            }
            for (j = 0; j < rightLength; j++)
            {
                rightArray[j] = items[j + mid + 1];
            }
            i = 0;
            j = 0;
            k = start;
            while (i < leftLength && j < rightLength)
            {
                if (leftArray[i].ratio > rightArray[j].ratio)
                {
                    items[k] = leftArray[i];
                    i++;
                }
                else
                {
                    items[k] = rightArray[i];
                    j++;
                }
                k++;
            }
            while (i < leftLength)
            {
                items[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < rightLength)
            {
                items[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
