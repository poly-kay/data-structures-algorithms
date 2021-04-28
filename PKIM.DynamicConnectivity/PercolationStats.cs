using PKIM.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKIM.DynamicConnectivity
{
    public class PercolationStats
    {
        private double[] PercolationThreshold;
        public PercolationStats(int n, int trials)
        {
            PercolationThreshold = new double[trials];
            for (int i = 0; i < trials; i++)
            {
                var percolation = new Percolation(n);
                while (!percolation.Percolates())
                {
                    int row = StdRandom.Uniform(0, n);
                    int col = StdRandom.Uniform(0, n);
                    percolation.Open(row, col);
                }

                PercolationThreshold[i] = (percolation.OpenedSites*1.00) / (n * n);
            }
        }
    }
}
