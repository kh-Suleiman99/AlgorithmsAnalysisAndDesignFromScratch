namespace LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string t1 = "KHALEDMOHAMED";
            string t2 = "DHALDM";
            t1 = " " + t1;
            t2 = " " + t2;
            int length1 = t1.Length;
            int length2 = t2.Length;
            int[,] arr = new int[length2, length1];
            int i, j;
            //TO CALC THE LCE VALUE
            for (i = 0; i < length2; i++)
            {
                for (j = 0; j < length1; j++)
                {
                    //FISRT ROW AND COL IS 0'S
                    if (i == 0 || j == 0)
                    {
                        arr[i, j] = 0;
                    }
                    //IF MATCH?
                    else if (t2[i] == t1[j])
                    {
                        //CELLVALUE = 1 + TOP-LEFT-CORNER-CELL
                        arr[i, j] = 1 + arr[i - 1, j - 1];
                    }
                    //IF NOT MATCH
                    else
                    {
                        //CELLVALUE = MAX(LEFT-CELL OR TOP-CELL)
                        arr[i, j] = Math.Max(arr[i, j - 1], arr[i - 1, j]);
                    }
                }
            }

            //TO Knows THE LCE STRING
            string lcs = "";
            //START FROM THE BOTTON RIGHT
            i = length2- 1;
            j = length1 - 1;
            while (i > 0 && j > 0)
            {
                //IF CELL VALUE > LEFT VALUE
                if (arr[i, j] > arr[i, j-1])
                {
                    //IF CELL VALUE == TOP VALUE
                    if (arr[i, j] == arr[i-1, j])
                    {
                        //CELL VALUE INHERTED FROM TOP CELL
                        //GO TO TOP CELL
                        i--;
                    }
                    else
                    {
                        //CELL VALUE CAME FROM MATCHED
                        lcs = t2[i] + lcs;
                        // GO TO TOP-LEFT-CORNER CELL 
                        i--;
                        j--;
                    }
                }
                else
                {
                    // GO TO LEFT CELL 
                    j--;
                }
            }
            Console.WriteLine(lcs);
            Console.WriteLine(arr[length2-1, length1-1]);
        }
    }
}