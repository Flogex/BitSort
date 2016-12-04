using System.Collections;

namespace Flogex.SortingAllgorithms
{
    class BitSort
    {
        ///!Please read documentation of BitArray Class: https://msdn.microsoft.com/en-us/library/system.collections.bitarray(v=vs.110).aspx
        public static BitArray Sort (BitArray unsortedArray, int position)
        {
            if (unsortedArray.Length == 0 || position < 0)
            {
                return unsortedArray;
            }
            BitArray numbersWithZeroBit = new BitArray(0);
            BitArray numbersWithOneBit = new BitArray(0);
            BitArray sortedArray = new BitArray(unsortedArray.Length);

            //Check bit of each number on current positon
            for (int i = position; i < unsortedArray.Length; i += 8)
            {
                //Add all bits of the number to one of the two arrays
                if (unsortedArray.Get(i))
                {
                    //Decrease to zero or a multiple of 8
                    int indexOfFirstBit = i - i % 8;
                    int oldArrayLength = numbersWithOneBit.Length;
                    numbersWithOneBit.Length += 8;
                    for (int indexOfBit = indexOfFirstBit; indexOfBit <= indexOfFirstBit + 7; indexOfBit++)
                    {
                        numbersWithOneBit[oldArrayLength + indexOfBit - indexOfFirstBit] = unsortedArray[indexOfBit];
                    }
                }
                else
                {
                    int indexOfFirstBit = i - i % 8;
                    int oldArrayLength = numbersWithZeroBit.Length;
                    numbersWithZeroBit.Length += 8;
                    for (int indexOfBit = indexOfFirstBit; indexOfBit <= indexOfFirstBit + 7; indexOfBit++)
                    {
                        numbersWithZeroBit[oldArrayLength + indexOfBit - indexOfFirstBit] = unsortedArray[indexOfBit];
                    }
                }
            }
            
            sortedArray = AddRange(Sort(numbersWithZeroBit, --position), Sort(numbersWithOneBit, position));
            return sortedArray;
        }

        private static BitArray AddRange (BitArray a, BitArray b)
        {
            int oldLength = a.Length;
            a.Length += b.Length;
            for (int i = oldLength; i < a.Length; i++)
            {
                a[i] = b[i - oldLength];
            }
            return a;
        }
    }
}
