using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RearrangeArray
{
    static class Program
    {
        static void Main(string[] args)
        {
            var rainbow = new string[] { "red", "orange", "yellow", "green", "blue", "indigo", "purple" };

            RearrangeArrayByShuffle(rainbow, "green");
        }

        #region Algorithm One
        // creates a new array.
        // should work quickly, but at the expense of memory consumption
        // does not change the existing array
        // difficult to maintain
        public static string[] RearrangeArrayWithСreatingNew(string[] array, string newBegining)
        {
            var indexOf = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (newBegining.Equals(array[i]))
                {
                    indexOf = i;
                    break;
                }
            }

            if (indexOf < 1)
            {
                // warning or exception, but for simplicity we return same array
                return array;
            }

            var rearrangedArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i <= indexOf)
                {
                    // begining from end
                    rearrangedArray[i] = array[i + indexOf];
                }
                else
                {
                    // end from begining
                    rearrangedArray[i] = array[i - indexOf - 1];
                }
            }
            return rearrangedArray;
        }
        #endregion

        #region Algorithm Two
        // Pros:
        // Work in same array.
        // Should work fast enough, without unnecessary memory consumption
        // Cons:
        // Difficult to undestand and maintain
        // On very large arrays, a StackOverflowException is possible due to recursion
        public static void RearrangeArrayByShuffle(string[] array, string newBegining)
        {
            var indexOf = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (newBegining.Equals(array[i]))
                {
                    indexOf = i;
                    break;
                }
            }

            if (indexOf < 1)
            {
                // warning or exception, but for simplicity we just exit
                return;
            }

            var headLength = indexOf;
            var tailLength = array.Length - headLength;
            RearrangeSubArray(array, 0, headLength, tailLength);
        }

        private static void RearrangeSubArray(string[] array, int startIndex, int headLength, int tailLength)
        {
            if (headLength == tailLength)
            {
                // simple case, two same in length part, just swap
                SwapSameInLength(array, startIndex, headLength);
            }
            else if (headLength < tailLength)
            {
                // more difficult case, swap partly, by less part
                SwapSameInLength(array, startIndex, headLength);

                // then rearrange new sub array
                var newStartIndex = startIndex + headLength;
                var newTailLength = tailLength - headLength;
                RearrangeSubArray(array, newStartIndex, headLength, newTailLength);
            }
            else
            {
                // more difficult case, swap partly, by less part
                var swapStartIndex = startIndex + headLength - tailLength;
                SwapSameInLength(array, swapStartIndex, tailLength);

                // then rearrange new sub array
                var newHeadLegth = headLength - tailLength;
                RearrangeSubArray(array, startIndex, newHeadLegth, tailLength);
            }
        }

        private static void SwapSameInLength(string[] array, int startIndex, int indexShift)
        {
            var swapValue = string.Empty;
            for (int i = startIndex; i < startIndex + indexShift; i++)
            {
                swapValue = array[i];
                array[i] = array[i + indexShift];
                array[i + indexShift] = swapValue;
            }
        }
        #endregion

        #region Algorithm Three
        // creates a new array.
        // spelled quickly
        // suitable for small collections
        // does not change the existing array
        public static string[] RearrangeArrayUsingLinq(string[] array, string newBegining)
        {
            var indexOf = array.ToList().IndexOf(newBegining);
            if (indexOf < 1)
            {
                // warning or exception, but for simplicity we return same array
                return array;
            }

            var head = array.Take(indexOf);
            var tail = array.Skip(indexOf);
            return tail.Union(head).ToArray();
        }
        #endregion
    }
}
