
namespace PKIM.StacksQueuesBags
{
    public class ArrayQueue<T>
    {
        public T[] Queue { get; set; }
        public int Head { get; set; }   // First item
        public int Tail { get; set; }   // Last item
        public int N { get; set; }  // Number of data

        public ArrayQueue()
        {
            Queue = new T[1];   // Initialize array with size 1.
        }

        public void Enqueue(T data)
        {
            // Check if array is full and resize by twice the current size.
            if (Queue.Length == N)
                Resize(Queue.Length * 2);

            Queue[Tail] = data;
            // Below commented code is only necessary when array is not resized.
            //Tail = (Tail + 1) % Queue.Length;
            Tail++; // Increment tail since data is added.
            N++;    // Increment data size.
        }

        public void Dequeue()
        {
            if (N == 0)
                return;

            if (N > 0 && N == Queue.Length / 4)
                Resize(Queue.Length / 2);

            Queue[Head] = default(T);
            // Below commented code is only necessary when array is not resized.
            //Head = (Head + 1) % Queue.Length;
            Head++;
            N--;
        }

        public void Resize(int lim)
        {
            var temp = new T[lim];
            for (int i = 0; i < N; i++)
                temp[i] = Queue[(i + Head) % Queue.Length];

            Queue = temp; // Set newly sized array to queue
            Head = 0;   // reset head
            Tail = N;   // set tail to the last added item.
        }
    }
}
