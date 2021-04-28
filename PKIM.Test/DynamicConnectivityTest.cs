using Microsoft.VisualStudio.TestTools.UnitTesting;
using PKIM.DynamicConnectivity;
using static PKIM.DynamicConnectivity.UnionFind;

namespace Test
{
    [TestClass]
    public class DynamicConnectivityTest
    {


        [TestMethod]
        public void IndexOfTestWithBubbleSort()
        {
            WeightedQuickUnion wqu = new WeightedQuickUnion(10);
            wqu.Union(1, 2);
            wqu.Union(1, 9);
            wqu.Union(0, 5);
            wqu.Union(5, 6);
            wqu.Union(3, 4);
            wqu.Union(7, 8);
            wqu.Union(8, 9);
            wqu.Union(7, 9);
            var root = wqu.Root(5);
            Assert.AreEqual(0, root);

            var root2 = wqu.Root(9);
            Assert.AreEqual(1, root2);
        }


        [TestMethod]
        public void PercolationTest()
        {
            var percolationStats = new PercolationStats(20, 10);
        }
    }
}
