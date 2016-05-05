using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp
{
    class MergeSort
    {
        public static void Sort(int[] arr)
        {
            int[] aux = new int[arr.Length];
            Sort(arr, aux, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int[] aux, int lo, int hi)
        {
            if (hi == lo)
            {
                return;
            }

            int mid = lo + (hi - lo)/2;

            Sort(arr, aux, lo, mid); //sort left sub array
            Sort(arr, aux, mid + 1, hi); //sort right sub array

            Merge(arr, aux, lo, mid, hi);
        }

        public static void Merge(int[] arr, int[] aux, int lo, int mid, int hi)
        {
            for (int idx = lo; idx <= hi; idx++)
            {
                aux[idx] = arr[idx];
                arr[idx] = -1;
            }

            int i = lo, j = mid + 1;
            for (int idx = lo; idx <= hi; idx++)
            {
                if (i > mid)
                {
                    arr[idx] = aux[j++]; // left side drained, take from right
                }
                else if (j > hi)
                {
                    arr[idx] = aux[i++]; // right side drained, take from left
                }
                else if (aux[j] < aux[i])
                {
                    arr[idx] = aux[j++]; // right smaller than left, take from right
                }
                else
                {
                    arr[idx] = aux[i++]; // left smaller than right, take from left
                }

            }
        }
    }

    [TestFixture]
    public class MergeTest
    {
        [Test]
        public void When_LenghtIsTwoAndMerged_Then_Sorted()
        {
            int[] arr = new int[] {6,5};
            int[] expectedArr = arr.OrderBy(a => a).ToArray();

            MergeSort.Merge(arr, new int[arr.Length], 0, 0, arr.Length - 1);

            CollectionAssert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void When_LenghtIsThreeAndMerged_Then_Sorted()
        {
            int[] arr = new int[] { 5, 6, 4 };
            int[] expectedArr = arr.OrderBy(a => a).ToArray();

            MergeSort.Merge(arr, new int[arr.Length], 0, 1, arr.Length - 1);

            CollectionAssert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void When_SubArraysAreSortedAndMerged_Then_FinalArrayIsSorted()
        {
            int[] arr = new int[] { 1, 7, 15, 78, 3, 14, 15, 99 };
            int[] expectedArr = arr.OrderBy(a => a).ToArray();

            MergeSort.Merge(arr, new int[arr.Length], 0, 3, arr.Length - 1);

            CollectionAssert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void When_ArrayIsNotSortedAndSortIsCalled_Then_Sorted()
        {
            int[] actual = {5, 3, 2, 1};
            int[] expected = actual.OrderBy(a => a).ToArray();

            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void When_LargeArrayIsNotSortedAndSortIsCalled_Then_Sorted()
        {
            Random random = new Random((int) DateTime.Now.Ticks);
            int size = 1000;
            int[] actual = new int[size];
            for (int i = 0; i < size; i++)
            {
                actual[i] = random.Next(10000);
            }
            int[] expected = actual.OrderBy(a => a).ToArray();
            
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ArrayIsAlreadySortedAndSortIsCalled_Then_SortIsMaintained()
        {
            int[] actual = Enumerable.Range(1, 1000).ToArray();
            int[] expected = actual.OrderBy(a => a).ToArray();

            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
