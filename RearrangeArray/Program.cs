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
            var rearrangedRainbow = RearrangeArray1(rainbow, "green");

            // Algorithm two has bug and not working.
            //RearrangeArray2(rainbow, "green");

            var rearrangedRainbow2 = RearrangeArray3(rainbow, "green");
        }

        #region Algorithm One
        // creates a new array.
        // should work quickly, but at the expense of memory consumption
        // does not change the existing array
        // difficult to maintain
        private static string[] RearrangeArray1(string[] array, string newBegining)
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
        // Not working because has bug =(
        private static void RearrangeArray2(string[] array, string newBegining)
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

            RearrangePartly(array, 0, indexOf, array.Length);
        }

        private static void RearrangePartly(string[] array, int startIndex, int headLength, int endIndex)
        {
            var subarrayLength = endIndex - startIndex;
            var tailLength = subarrayLength - headLength;

            if (headLength == tailLength)
            {
                // simple case, two same in length part, just swap
                SwapSameInLength(array, startIndex, headLength);
            }
            else if (headLength < tailLength)
            {
                SwapSameInLength(array, startIndex, headLength);
                RearrangePartly(array, headLength, headLength, endIndex);
            }
            else
            {
                var newStartIndex = startIndex + headLength - tailLength - 1;
                SwapSameInLength(array, newStartIndex, endIndex - newStartIndex);
                RearrangePartly(array, startIndex, headLength - tailLength, newStartIndex);
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
        private static string[] RearrangeArray3(string[] array, string newBegining)
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
