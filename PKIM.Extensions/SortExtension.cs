using System;

namespace PKIM.Extensions
{
    public static class SortExtension
    {
        /// <summary>
        /// Selection sort algorithm sorts array by repeatedly finding the minimum element (considering asecnding order) from unsorted part and placing it at the beginning. O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(this int[] arr)
        {
            int n = arr.Length - 1;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] <= arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        /// <summary>
        /// Bubble sort is the simplest alg that works by repeatedly swapping the adjacent elements if they are in wrong order. O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(this int[] arr)
        {
            var n = arr.Length - 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Recursive Bubble sort is the simplest alg that works by repeatedly swapping the adjacent elements if they are in wrong order. O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        public static void RecursiveBubbleSort(this int[] arr, int n)
        {
            if (n == 1)
                return;

            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }

            RecursiveBubbleSort(arr, n - 1);
        }

        /// <summary>
        /// Insertion sort is a simple sorting algorithm that works similar to the way you sort playing cards in your hands. The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at the correct position in the sorted part.
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var currIdxVal = arr[i];
                var j = i - 1;
                while (j >= 0)
                {
                    if (currIdxVal <= arr[j])
                    {
                        var temp = arr[j];
                        arr[j] = currIdxVal;
                        arr[j + 1] = temp;
                    }
                    else
                        break;

                    j--;
                }
            }
        }

        /// <summary>
        /// Good old MergeSort. D&C Alg. It divides the input array into two halves, calls itself for the two halves, and then merges the two sorted halves.
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(this int[] arr)
        {
            if (arr.Length > 0)
                MergeSort(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// Resursive function for Merge Sort alg.
        /// </summary>
        /// <param name="arr">Int Array</param>
        /// <param name="l">Left</param>
        /// <param name="r">Right</param>
        private static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int mid = l + (r - l) / 2;

                MergeSort(arr, l, mid);
                MergeSort(arr, mid + 1, r);

                Merge(arr, l, mid, r);
            }
        }

        /// <summary>
        /// Helper function to merge the partitioned arrays for Merge Sort Alg.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">Left</param>
        /// <param name="m">Middle</param>
        /// <param name="r">Right</param>
        private static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int left_partition_size = m - l + 1;
            int right_partition_size = r - m;

            int[] left_partition = new int[left_partition_size];
            int[] right_partition = new int[right_partition_size];

            for (i = 0; i < left_partition_size; i++)
                left_partition[i] = arr[l + i];
            for (j = 0; j < right_partition_size; j++)
                right_partition[j] = arr[m + j + 1];

            i = 0;
            j = 0;
            k = l;
            while (i < left_partition_size && j < right_partition_size)
            {
                if (left_partition[i] <= right_partition[j])
                {
                    arr[k] = left_partition[i];
                    i++;
                }
                else
                {
                    arr[k] = right_partition[j];
                    j++;
                }
                k++;
            }

            while (i < left_partition_size)
            {
                arr[k] = left_partition[i];
                i++;
                k++;
            }

            while (j < right_partition_size)
            {
                arr[k] = right_partition[j];
                j++;
                k++;
            }

        }

        /// <summary>
        /// Good old QuickSort. D&Q Alg. It divides the input array into two halves, calls itself for the two halves, and then merges the two sorted halves. Fastest known algorithm to sort values.
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(this int[] arr)
        {

        }

        // Prints the array
        public static void Print(this int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
