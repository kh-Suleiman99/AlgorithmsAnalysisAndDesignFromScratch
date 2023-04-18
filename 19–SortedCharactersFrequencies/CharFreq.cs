using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Net;

namespace SortedCharactersFrequencies
{
    public class CharFreq
    {
        public void AsciiFreq(string message)
        {
            int[] freq = new int[127];
            for(int i = 0; i < message.Length; i++)
            {
                freq[(int)message[i]]++;
            }
            for(int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    Console.WriteLine((char)i + ": " + freq[i]);
                }
            }
        }
        
        public void AnyCharFreq(string message)
        {
            Hashtable freq = new Hashtable();

            foreach(char c in message)
            {
                if (freq[c] == null)
                {
                    freq[c] = 1;
                }
                else
                {
                    freq[c] = (int)freq[c]! + 1;
                }
            }
            foreach (char c in freq.Keys)
            {
                Console.WriteLine(c+": " + freq[c]);
            }
            Console.WriteLine("\nAfter Sorting");
            SortHash(freq);
        }

        public void SortHash(Hashtable hash)
        {
            int[,] array = new int[hash.Count,2];
            int i = 0;
            foreach(char c in hash.Keys)
            {
                array[i,0] = (int) c;
                array[i,1] = (int) hash[c]!;
                i++;
            }
            Sort(array, 0, hash.Count-1);

            for(i=0; i < hash.Count; i++) 
            { 
                Console.WriteLine((char)array[i,0] + ": " + array[i,1]);
            }
        }

        public void Sort(int[,] array,int start,int end)
        {
            if (start >= end) return;
            int midpoint = (start + end) / 2;
            Sort(array, start, midpoint);
            Sort(array, midpoint + 1, end);
            Merge(array, start, midpoint, end);
        }
        public void Merge(int[,] array, int start, int midpoint, int end)
        {
            int i, j, k;
            int left_length = midpoint - start + 1;
            int right_length = end - midpoint;
            int[,] left_array = new int[left_length,2]; 
            int[,] right_array = new int[right_length,2]; 
            for(i = 0; i<left_length; i++)
            {
                left_array[i, 0] = array[start + i, 0];
                left_array[i, 1] = array[start + i, 1];
            }
            for(j = 0; j<right_length; j++)
            {
                right_array[j, 0] = array[midpoint + j + 1, 0];
                right_array[j, 1] = array[midpoint + j + 1, 1];
            }
            i = 0;
            j = 0;
            k = start;
            while (i<left_length && j<right_length)
            {
                if (left_array[i,1] <= right_array[j, 1])
                {
                    array[k, 0] = left_array[i, 0];
                    array[k, 1] = left_array[i, 1];
                    i++;
                }
                else
                {
                    array[k, 0] = right_array[j, 0];
                    array[k, 1] = right_array[j, 1];
                    j++;
                }
                k++;
            }
            while(i < left_length)
            {
                array[k, 0] = left_array[i, 0];
                array[k, 1] = left_array[i, 1];
                i++;
                k++;
            }
            while (j < right_length)
            {
                array[k, 0] = right_array[j, 0];
                array[k, 1] = right_array[j, 1];
                j++;
                k++;
            }

        }
        
    }
}
