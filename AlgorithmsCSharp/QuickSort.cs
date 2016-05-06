using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmsCSharp
{

    /// <summary>
    /// Basic quick sort. The choice of partition item is not very sophisticated, so the runtime can vary
    /// </summary>
    public class QuickSort
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int partitionIdx = Partition(arr, lo, hi);
                Sort(arr, lo, partitionIdx - 1);
                Sort(arr, partitionIdx + 1, hi);
            }
        }

        public static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[lo];
            int leftMark = lo + 1;
            int rightMark = hi;
            while (true)
            {
                while (leftMark <= rightMark && arr[leftMark] <= pivot)
                {
                    leftMark++;
                }

                while (rightMark >= leftMark && arr[rightMark] >= pivot)
                {
                    rightMark--;
                }

                if (rightMark < leftMark)
                {
                    break;
                }

                Swap(arr, leftMark, rightMark);
            }

            int partitionIdx = rightMark;
            Swap(arr, lo, partitionIdx);
            return partitionIdx;
        }

        private static void Swap(int[] arr, int idx1, int idx2)
        {
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }
    }

    [TestFixture]
    public class QuickSortTestFixture
    {
        [Test]
        public void When_LargeArrayIsNotSortedAndSortIsCalled_Then_Sorted()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 5; i++)
            {
                int size = 1000;
                int[] actual = new int[size];
                for (int j = 0; j < size; j++)
                {
                    actual[j] = random.Next(10000);
                }

                int[] expected = actual.OrderBy(a => a).ToArray();

                QuickSort.Sort(actual);

                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
