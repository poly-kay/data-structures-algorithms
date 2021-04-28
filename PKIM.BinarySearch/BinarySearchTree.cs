using System;

namespace PKIM.BinarySearch
{
    public class BinarySearchTree
    {
        public Node Root;
        public BinarySearchTree() { }
        private void Traverse(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.Data + " ");

            Traverse(node.Left);
            Traverse(node.Right);
        }

        public void Traverse() => Traverse(Root);

        public void Insert(int data)
        {
            if (Root == null)
                Root = new Node(data);
            else
            {
                Node current = Root;
                Node temp;

                while (current != null)
                {
                    temp = current;

                    if (data < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                            temp.Left = new Node(data);
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                            temp.Right = new Node(data);
                    }
                }
            }
        }

        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node() { }
            public Node(int data) { Data = data; }
        }
    }
}
