using Microsoft.VisualStudio.TestTools.UnitTesting;
using PKIM.BinarySearch;
using PKIM.Extensions;
using System;
using System.Diagnostics;
using System.Linq;

namespace Test
{
    [TestClass]
    public class BinarySearchTest
    {
        private readonly int TEST_CASES = 100;
        private readonly int NUM_RECORDS = 1000;
        private readonly int RANGE_START = 0;
        private readonly int RANGE_END = 10000;

        [TestMethod]
        public void IndexOfTestWithBubbleSort()
        {
            var arr_2d = NumberGeneratorExtension.GenerateArray(NUM_RECORDS, TEST_CASES, null, new Tuple<int, int>(RANGE_START, RANGE_END)) as int[][];

            var binarySearch = new BinarySearch();

            System.Random random = new System.Random();
            Stopwatch sw = new Stopwatch();


            var avg_sort = 0.000;
            var avg_bs = 0.000;
            for (var i = 0; i < arr_2d.Length; i++)
            {
                sw.Start();
                arr_2d[i].BubbleSort();
                sw.Stop();

                var temp_sort_alg_elapsed = sw.Elapsed.TotalMilliseconds;

                avg_sort += temp_sort_alg_elapsed;

                var caseVal = random.Next(RANGE_START, NUM_RECORDS - 1);

                sw.Start();
                var output = binarySearch.IndexOf(arr_2d[i], arr_2d[i][caseVal]);
                sw.Stop();

                avg_bs += sw.Elapsed.TotalMilliseconds;

                //Console.WriteLine($"Test Case {i+1} -   x: {arr_2d[i][caseVal]}    Expected Output: {caseVal}     Test Output: {output}         Sort Alg: BubbleSort (Duration:{temp_sort_alg_elapsed}ms)");
                Assert.AreEqual(output, caseVal);
            }
            Console.WriteLine($"Avg Sort Time Elapsed: {avg_sort / arr_2d.Length}       Avg Binary Search Sort Time Elapsed: {avg_bs / arr_2d.Length}");


            Assert.IsNotNull(-1);
        }

        [TestMethod]
        public void IndexOfTestWithInsertionSort()
        {
            var arr_2d = NumberGeneratorExtension.GenerateArray(NUM_RECORDS, TEST_CASES, null, new Tuple<int, int>(RANGE_START, RANGE_END)) as int[][];

            var binarySearch = new BinarySearch();

            System.Random random = new System.Random();
            Stopwatch sw = new Stopwatch();


            var avg_sort = 0.000;
            var avg_bs = 0.000;
            for (var i = 0; i < arr_2d.Length; i++)
            {
                sw.Start();
                arr_2d[i].InsertionSort();
                sw.Stop();

                var temp_sort_alg_elapsed = sw.Elapsed.TotalMilliseconds;

                avg_sort += temp_sort_alg_elapsed;

                var caseVal = random.Next(RANGE_START, NUM_RECORDS - 1);

                sw.Start();
                var output = binarySearch.IndexOf(arr_2d[i], arr_2d[i][caseVal]);
                sw.Stop();

                avg_bs += sw.Elapsed.TotalMilliseconds;

                //Console.WriteLine($"Test Case {i + 1} -   x: {arr_2d[i][caseVal]}    Expected Output: {caseVal}     Test Output: {output}         Sort Alg: InsertionSort (Duration:{temp_sort_alg_elapsed}ms)");
                Assert.AreEqual(output, caseVal);
            }
            Console.WriteLine($"Avg Sort Time Elapsed: {avg_sort / arr_2d.Length}       Avg Binary Search Sort Time Elapsed: {avg_bs / arr_2d.Length}");


            Assert.IsNotNull(-1);
        }

        [TestMethod]
        public void IndexOfTestWithSelectionSort()
        {
            var arr_2d = NumberGeneratorExtension.GenerateArray(NUM_RECORDS, TEST_CASES, null, new Tuple<int, int>(RANGE_START, RANGE_END)) as int[][];

            var binarySearch = new BinarySearch();

            System.Random random = new System.Random();
            Stopwatch sw = new Stopwatch();


            var avg_sort = 0.000;
            var avg_bs = 0.000;
            for (var i = 0; i < arr_2d.Length; i++)
            {
                sw.Start();
                arr_2d[i].SelectionSort();
                sw.Stop();

                var temp_sort_alg_elapsed = sw.Elapsed.TotalMilliseconds;

                avg_sort += temp_sort_alg_elapsed;

                var caseVal = random.Next(RANGE_START, NUM_RECORDS - 1);

                sw.Start();
                var output = binarySearch.IndexOf(arr_2d[i], arr_2d[i][caseVal]);
                sw.Stop();

                avg_bs += sw.Elapsed.TotalMilliseconds;

                //Console.WriteLine($"Test Case {i + 1} -   x: {arr_2d[i][caseVal]}    Expected Output: {caseVal}     Test Output: {output}         Sort Alg: SelectionSort (Duration:{temp_sort_alg_elapsed}ms)");
                Assert.AreEqual(output, caseVal);
            }
            Console.WriteLine($"Avg Sort Time Elapsed: {avg_sort / arr_2d.Length}       Avg Binary Search Sort Time Elapsed: {avg_bs / arr_2d.Length}");


            Assert.IsNotNull(-1);
        }

        [TestMethod]
        public void IndexOfTestWithRecursiveBubbleSort()
        {
            var arr_2d = NumberGeneratorExtension.GenerateArray(NUM_RECORDS, TEST_CASES, null, new Tuple<int, int>(RANGE_START, RANGE_END)) as int[][];

            var binarySearch = new BinarySearch();

            System.Random random = new System.Random();
            Stopwatch sw = new Stopwatch();


            var avg_sort = 0.000;
            var avg_bs = 0.000;
            for (var i = 0; i < arr_2d.Length; i++)
            {
                sw.Start();
                arr_2d[i].RecursiveBubbleSort(arr_2d[i].Length);
                sw.Stop();

                var temp_sort_alg_elapsed = sw.Elapsed.TotalMilliseconds;

                avg_sort += temp_sort_alg_elapsed;

                var caseVal = random.Next(RANGE_START, NUM_RECORDS - 1);

                sw.Start();
                var output = binarySearch.IndexOf(arr_2d[i], arr_2d[i][caseVal]);
                sw.Stop();

                avg_bs += sw.Elapsed.TotalMilliseconds;

                //Console.WriteLine($"Test Case {i + 1} -  x: {arr_2d[i][caseVal]}    Expected Output: {caseVal}     Test Output: {output}         Sort Alg: RecursiveBubbleSort (Duration:{temp_sort_alg_elapsed}ms)");
                Assert.AreEqual(output, caseVal);
            }
            Console.WriteLine($"Avg Sort Time Elapsed: {avg_sort / arr_2d.Length}       Avg Binary Search Sort Time Elapsed: {avg_bs / arr_2d.Length}");


            Assert.IsNotNull(-1);
        }

        [TestMethod]
        public void IndexOfTestWithMergeSort()
        {
            var arr_2d = NumberGeneratorExtension.GenerateArray(NUM_RECORDS, TEST_CASES, null, new Tuple<int, int>(RANGE_START, RANGE_END)) as int[][];

            var binarySearch = new BinarySearch();

            System.Random random = new System.Random();
            Stopwatch sw = new Stopwatch();


            var avg_sort = 0.000;
            var avg_bs = 0.000;
            for (var i = 0; i < arr_2d.Length; i++)
            {
                sw.Start();
                arr_2d[i].MergeSort();
                sw.Stop();

                var tt = arr_2d[i].Where(a => a == 0).Count();

                var temp_sort_alg_elapsed = sw.Elapsed.TotalMilliseconds;

                avg_sort += temp_sort_alg_elapsed;

                var caseVal = random.Next(RANGE_START, NUM_RECORDS - 1);

                sw.Start();
                var output = binarySearch.IndexOf(arr_2d[i], arr_2d[i][caseVal]);
                sw.Stop();

                avg_bs += sw.Elapsed.TotalMilliseconds;

                //Console.WriteLine($"Test Case {i + 1} -  x: {arr_2d[i][caseVal]}    Expected Output: {caseVal}     Test Output: {output}         Sort Alg: MergeSort (Duration:{temp_sort_alg_elapsed}ms)");
                Assert.AreEqual(output, caseVal);
            }
            Console.WriteLine($"Avg Sort Time Elapsed: {avg_sort / arr_2d.Length}       Avg Binary Search Sort Time Elapsed: {avg_bs / arr_2d.Length}");


            Assert.IsNotNull(-1);
        }
    }
}
