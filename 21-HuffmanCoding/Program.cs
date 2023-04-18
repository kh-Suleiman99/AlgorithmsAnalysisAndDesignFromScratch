namespace HuffmanCoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String mes = "internet";
            Huffman huffman = new Huffman(mes);
            foreach(var k in huffman.codes.Keys) 
            {
                Console.WriteLine(k +": " + huffman.codes[k]);
            }
        }
    }
}