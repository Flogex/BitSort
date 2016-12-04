using System;
using System.Collections;
using System.Text;

namespace Flogex.SortingAllgorithms.BitSortTools
{
    class BitArrayConverter
    {
        public static int[] ConvertToIntArray (BitArray arr)
        {
            int[] valuesAsInt = new int[arr.Length / 8];
            for (int index = 0; index < valuesAsInt.Length; index++)
            {
                for (int bit = 0; bit <= 7; bit++)
                {
                    valuesAsInt[index] += arr[bit + (index * 8)] ? (int) Math.Pow(2, bit) : 0;
                }
            }
            return valuesAsInt;
        }

        public static string[] ConvertToStringArray (BitArray arr)
        {
            string[] binaryNumbers = new string[arr.Length / 8];
            StringBuilder stringBuilder = new StringBuilder(8, 8);
            for (int number = 0; number < binaryNumbers.Length; number++)
            {
                for (int bit = 7; bit >= 0; bit--)
                {
                    stringBuilder.Append(arr[bit + (number * 8)] ? "1" : "0");
                }
                binaryNumbers[number] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
            return binaryNumbers;
        }
    }
}
