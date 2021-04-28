using System;
using static PKIM.DynamicConnectivity.UnionFind;

namespace PKIM.DynamicConnectivity
{
    public class Percolation
    {
        /// <summary>
        /// Length of Array Dimension
        /// </summary>
        private int N { get; set; }

        /// <summary>
        /// 1D array to capture opened/blocked sites
        /// </summary>
        private bool[] SiteStatusMap { get; set; }

        /// <summary>
        /// Quick Union algorithm
        /// </summary>
        private WeightedQuickUnion Wqu { get; set; }

        /// <summary>
        /// Virtual indice for any top opened indices
        /// A bit confusing, its easy to think this as an additional indice that is reserved to capture the root sites of the top row.
        /// REMEMBER the "Transitive" site connection
        /// </summary>
        private int VirtualTop { get; set; }

        /// <summary>
        /// Virtual indice for any bottom opened indices
        /// A bit confusing, its easy to think this as an additional indice that is reserved to capture the root sites of the bottom row.
        /// REMEMBER the "Transitive" site connection
        /// </summary>
        private int VirtualBottom { get; set; }

        /// <summary>
        /// Count of all open sites.
        /// </summary>
        public int OpenedSites { get; set; }

        public Percolation(int n)
        {
            N = n;
            SiteStatusMap = new bool[n * n];
            Wqu = new WeightedQuickUnion(n * n + 2);    // Add two to reserve two root sites for both top and bottom.
            VirtualTop = N * N;
            VirtualBottom = N * N + 1;
        }

        public void Open(int row, int col)
        {
            int idx = GetFlattenedIndex(row, col, true);
            if (!SiteStatusMap[idx])
            {
                SiteStatusMap[idx] = true;
                OpenedSites++;      // Increment number of opened sites.
                var adjacentSites = GetAdjacentOpenSites(row, col); // 0 - Left, 1 - Right, 2 - Up, 3 - Down;

                if (row == 0)
                    Wqu.Union(idx, VirtualTop);
                else if (row == N - 1)
                    Wqu.Union(idx, VirtualBottom);

                if (adjacentSites[0] != -1 && !Wqu.Connected(idx, adjacentSites[0]))
                    Wqu.Union(idx, adjacentSites[0]);
                if (adjacentSites[1] != -1 && !Wqu.Connected(idx, adjacentSites[1]))
                    Wqu.Union(idx, adjacentSites[1]);
                if (adjacentSites[2] != -1 && !Wqu.Connected(idx, adjacentSites[2]))
                    Wqu.Union(idx, adjacentSites[2]);
                if (adjacentSites[3] != -1 && !Wqu.Connected(idx, adjacentSites[3]))
                    Wqu.Union(idx, adjacentSites[3]);
            }
        }

        public bool IsOpen(int row, int col)
        {
            var idx = GetFlattenedIndex(row, col, true);
            return SiteStatusMap[idx];
        }

        /// <summary>
        /// A site is considered full when it can be connected to an open site that is ultimately connected to any site in the top row through adjacency.
        /// Returns False if row & column is out of bounds.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsFull(int row, int col)
        {
            var idx = GetFlattenedIndex(row, col, true);
            return Wqu.Connected(idx, VirtualTop);
        }

        public bool Percolates()
        {
            return Wqu.Connected(VirtualTop, VirtualBottom);
        }

        private int[] GetAdjacentOpenSites(int row, int col)
        {
            int left = GetFlattenedIndex(row, col - 1);
            int right = GetFlattenedIndex(row, col + 1);
            int up = GetFlattenedIndex(row - 1, col);
            int down = GetFlattenedIndex(row + 1, col);

            if (left != -1)
                left = SiteStatusMap[left] ? left : -1;
            if (right != -1)
                right = SiteStatusMap[right] ? right : -1;
            if (up != -1)
                up = SiteStatusMap[up] ? up : -1;
            if (down != -1)
                down = SiteStatusMap[down] ? down : -1;

            return new int[] { left, right, up, down };
        }

        private int GetFlattenedIndex(int row, int col, bool throwException = false)
        {
            if (!IsValid(row, col))
            {
                return throwException ? throw new IndexOutOfRangeException() : -1;
            }
                
            return (row * N) + col;
        }

        private bool IsValid(int row, int col)
        {
            if (row < 0 || row >= N || col < 0 || col >= N)
                return false;

            return true;
        }
    }
}
