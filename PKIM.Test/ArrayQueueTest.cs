using Microsoft.VisualStudio.TestTools.UnitTesting;
using PKIM.StacksQueuesBags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKIM.Test
{
    [TestClass]
    public class ArrayQueueTest
    {
        [TestMethod]
        public void Test()
        {
            ArrayQueue<int> aq = new();
            aq.Enqueue(1);
            aq.Enqueue(2);
            aq.Enqueue(3);
            aq.Enqueue(4);
            aq.Enqueue(5);
            aq.Enqueue(6);
            aq.Enqueue(7);
            aq.Enqueue(8);
            aq.Enqueue(9);
            aq.Enqueue(10);
            aq.Enqueue(11);
            aq.Enqueue(12);

            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();
            aq.Dequeue();

        }
    }
}
