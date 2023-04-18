using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HuffmanCoding
{
    public class HeapNode
    {
        public char data;
        public int freq;
        public HeapNode left;
        public HeapNode right;
        public HeapNode(char data, int freq)
        {
            this.data = data;
            this.freq = freq;
            this.left = this.right = null!;
        }
    }
    public class Huffman
    {
        char internalChar = (char)0;
        public Hashtable codes = new Hashtable();
        private PriorityQueue<HeapNode, int> _minHeap = new PriorityQueue<HeapNode, int>();
        public Huffman(string message)
        {
            
            Hashtable freqhash= new Hashtable();
            int i;
            for(i=0;i<message.Length;i++)
            {
                if (freqhash[message[i]] == null)
                {
                    freqhash[message[i]] = 1;
                }
                else
                {
                    freqhash[message[i]] = (int)freqhash[message[i]]! + 1;
                }
            }
            foreach(char k in freqhash.Keys)
            {
                HeapNode newNode = new HeapNode(k,(int)freqhash[k]!);
                _minHeap.Enqueue(newNode, (int)freqhash[k]!);
            }
            HeapNode left, right , top;
            int newFreq;
            while(_minHeap.Count != 1) 
            {
                left = _minHeap.Dequeue();
                right = _minHeap.Dequeue();
                newFreq = left.freq + right.freq;
                top = new HeapNode(internalChar, newFreq);
                top.left = left;
                top.right = right;
                _minHeap.Enqueue(top, newFreq);
            }
            generateCodes(_minHeap.Peek(), "");

        }
        private void generateCodes(HeapNode node, string str)
        {
            if(node == null) return;
            if(node.data != internalChar)
            {
                codes[node.data] = str;
            }
            generateCodes(node.left, str + "0");
            generateCodes(node.right, str + "1");
        }
    }
}
