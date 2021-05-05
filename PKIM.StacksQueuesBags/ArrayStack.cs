namespace PKIM.StacksQueuesBags
{
    public class ArrayStack<T>
    {
        public T[] stack { get; set; }
        public int N { get; set; }

        public ArrayStack()
        {
            stack = new T[1];
        }

        public void Push(T item)
        {
            if (stack.Length == N)
                Resize(2 * stack.Length);

            stack[N++] = item;
        }

        public void Pop()
        {
            stack[--N] = default(T);
            if (N > 0 && N == stack.Length / 4)
                Resize(N / 2);
        }

        public void Resize(int capacity)
        {
            var temp = new T[capacity];
            for (int i = 0; i < N; i++)
            {
                temp[i] = stack[i];
            }

            stack = temp;
        }
    }
}
