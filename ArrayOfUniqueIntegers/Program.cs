using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfUniqueIntegers
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // Debugging
            var array = PrimitiveAlgorithm(100000);
        }

        private static Random _random = new Random();

        public static int[] PrimitiveAlgorithm(int numberOfIntegers = 100000)
        {
            var array = new int[numberOfIntegers];
            for (int i = 0; i < numberOfIntegers; i++)
            {
                array[i] = i + 1;
            }

            var swapValue = 0;
            var swapIndex = 0;
            for (int i = 0; i < numberOfIntegers; i++)
            {
                swapIndex = _random.Next(1, numberOfIntegers);

                swapValue = array[i];
                array[i] = array[swapIndex];
                array[swapIndex] = swapValue;
            }

            return array;
        }
    }
}
