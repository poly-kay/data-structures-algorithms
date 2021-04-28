using System;
using System.Collections.Generic;

namespace PKIM.Extensions
{
    public static class NumberGeneratorExtension
    {
        private static readonly Random random = new Random();
        public static object GenerateArray(int x, int? y, int? z, Tuple<int, int> range)
        {
            object arr;
            if (y.HasValue && !z.HasValue)
            {
                arr = new int[y.Value][];
                for (var i = 0; i < ((int[][])arr).Length; i++)
                {
                    var keys = new HashSet<int>();
                    ((int[][])arr)[i] = new int[x];
                    for (var j = 0; j < ((int[][])arr)[i].Length; j++)
                    {
                        var rand = 0;

                        while (!keys.Add(rand) && keys.Count <= 1000)
                        {
                            rand = random.Next(range.Item1, range.Item2);
                        }

                        ((int[][])arr)[i][j] = rand;

                    }
                }
            }
            else if (y.HasValue && z.HasValue)
            {
                arr = new int[z.Value][][];

                for (var i = 0; i < ((int[][][])arr).Length; i++)
                {
                    ((int[][][])arr)[i] = new int[y.Value][];
                    for (var j = 0; j < ((int[][][])arr)[i].Length; j++)
                    {
                        ((int[][][])arr)[i][j] = new int[x];
                        for (int k = 0; k < ((int[][][])arr)[i][j].Length; k++)
                        {
                            ((int[][][])arr)[i][j][k] = random.Next(range.Item1, range.Item2);
                        }
                    }
                }

            }
            else
            {
                arr = new int[x];
                for (var i = 0; i < ((int[])arr).Length; i++)
                {
                    ((int[])arr)[i] = random.Next(range.Item1, range.Item2);
                }
            }

            return arr;
        }
    }
}
