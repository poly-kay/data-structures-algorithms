using PKIM.LinkedList;

namespace PKIM.StacksQueuesBags
{
    public class LinkedListStack<T>
    {
        public LinkedList<T> LinkedList { get; set; }

        public LinkedListStack() => LinkedList = new LinkedList<T>();

        public void Push(T item)
        {
            LinkedList.push(item);
        }

        public void Pop()
        {
            LinkedList.pop();
        }
    }
}
