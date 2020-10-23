using System;

namespace PodMassiv
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = new[] { 1, 2, 3 };
            int[] arrayTwo = new[] { 1, 2, 3, 4 };
            int[,] arrayThree = new[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arrayFour = new[,] { { 1, 2, 3 }, { 4, 4, 6 }, { 3, 0, 3 } };

            Console.WriteLine(CheckForNesting(arrayTwo, arrayOne));
            Console.WriteLine(CheckForNesting(arrayThree, arrayOne));
            Console.WriteLine(CheckForNesting(arrayFour, arrayThree));
        }

        static bool CheckForNesting (int[] array, int[] subarray)
        {
            int countLength = 0;
            bool firstStep = true;

            for (int nomber = 0; nomber < array.Length; nomber++)
            {
                for (int numeral = 0; numeral < subarray.Length; numeral++)
                {
                    if (array[nomber + numeral] == subarray[numeral])
                    {
                        countLength++;
                        firstStep = false;
                    }
                    else
                    {
                        if (firstStep)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (countLength == subarray.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool CheckForNesting (int[,] array, int[] subarray)
        {
            return CheckForNesting(TranslateTo1D(array), subarray);
        }

        static bool CheckForNesting(int[,] array, int[,] subarray)
        {
            return CheckForNesting(TranslateTo1D(array), TranslateTo1D(subarray));
        }

        static int[] TranslateTo1D(int[,] twodimensional)
        {
            int[] array1D = new int[twodimensional.Length];

            int i = 0;

            foreach (int amalgadon in twodimensional)
            {
                array1D[i++] = amalgadon;
            }

            return array1D;
        }
    }
}
