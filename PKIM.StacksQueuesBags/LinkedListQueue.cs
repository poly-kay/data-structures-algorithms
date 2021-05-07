namespace PKIM.StacksQueuesBags
{
    public class LinkedListQueue<T>
    {
        public class Node<TT>
        {
            public TT data { get; set; }
            public Node<TT> next { get; set; }

            public Node(TT data) { this.data = data; }
        }

        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public void Enqueue(T data)
        {
            var oldLast = Last;
            Last = new Node<T>(data);
            if (First == null)
                First = Last;
            else
                oldLast.next = Last;
        }

        public void Dequeue(T data)
        {
            First = First.next;
            if (First == null)
                Last = null;
        }

    }
}
