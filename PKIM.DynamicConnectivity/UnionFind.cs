namespace PKIM.DynamicConnectivity
{
    public class UnionFind
    {
        /// <summary>
        /// O(N)
        /// Too expensive and trees can get too tall causing slow find operation (unbalanced tree)
        /// </summary>
        public class QuickUnion
        {
            public int[] id { get; set; }
            public QuickUnion(int n)
            {
                id = new int[n];
                for (int i = 0; i < n; i++)
                {
                    id[i] = i;
                }
            }

            public int Root(int i)
            {
                while (i != id[i])
                {
                    i = id[i];
                }

                return i;
            }

            public bool Connected(int p, int q) => Root(p) == Root(q);
            public void Union(int p, int q)
            {
                int i = Root(p);
                int j = Root(q);

                id[i] = j;
            }
        }

        public class WeightedQuickUnion
        {
            public int[] id { get; set; }
            public int[] size { get; set; }
            public WeightedQuickUnion(int n)
            {
                id = new int[n];
                size = new int[n];
                for (int i = 0; i < n; i++)
                {
                    id[i] = i;
                    size[i] = 1;
                }
            }

            public int Root(int i)
            {
                while (i != id[i])
                {
                    // Path compression. Setting the current node's parent to be the grandparent node to flatten.
                    id[i] = id[id[i]];
                    i = id[i];
                }

                return i;
            }

            public bool Connected(int p, int q) => Root(p) == Root(q);
            public void Union(int p, int q)
            {
                int i = Root(p);
                int j = Root(q);

                if (i == j) return;

                if (size[i] < size[j])
                {
                    id[i] = j;
                    size[j] += size[i];
                }
                else
                {
                    id[j] = i;
                    size[i] += size[j];
                }
            }
        }

    }
}
