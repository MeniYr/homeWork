using System;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] arr = { 1, 5, -2, 10, 15, 6, 7, 0 };

            // before
            foreach (int num in arr)
                Console.Write(num + " ");
           
            sort(arr, arr.Length);

            // after
            Console.WriteLine("\n \n after: \n");
            foreach(int num in arr)
                Console.Write(num + " ");
            Console.WriteLine("");
        }

        static void sort(int [] arr, int size)
        {
            int [] temp1 = new int [arr.Length/2];
            int [] temp2 = new int [arr.Length / 2 + arr.Length % 2]; // case that array length is'nt even.
            int i;

            if (size == 1)
                return;

            for (i = 0; i < arr.Length / 2; i++)
                temp1[i] = arr[i];
            for (int j = 0; i < arr.Length; i++, j++)
                temp2[j] = arr[i];

            sort(temp1, arr.Length / 2);
            sort(temp2, arr.Length / 2 + arr.Length % 2);

            merge(temp1, arr.Length / 2, temp2, arr.Length / 2 + arr.Length % 2, arr, arr.Length);

        }

        static void merge(int[] temp1, int size1, int[] temp2, int size2, int [] origin, int size_origin)
        {
            int temp1_counter, temp2_counter, fullArray_counter;
            temp1_counter = temp2_counter = fullArray_counter = 0;

            while (fullArray_counter < size_origin)
            {
                if (temp1_counter < size1 && temp2_counter < size2)
                {
                    if (temp1[temp1_counter] < temp2[temp2_counter])
                        origin[fullArray_counter++] = temp1[temp1_counter++];
                    else
                        origin[fullArray_counter++] = temp2[temp2_counter++];
                }

                else if (temp1_counter >= size1)
                    origin[fullArray_counter++] = temp2[temp2_counter++];

                else
                    origin[fullArray_counter++] = temp1[temp1_counter++];
            }
        }
    }
}
