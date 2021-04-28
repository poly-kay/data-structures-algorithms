namespace PKIM.BinarySearch
{
    public class BinarySearch
    {
        public int IndexOf(int[] arr, int x)
        {
            if (arr.Length == 1)
                return arr[arr.Length - 1] == x ? arr.Length - 1 : -1;

            var start = 0;
            var end = arr.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (arr[middle] == x)
                    return middle;

                if (x < arr[middle])
                    end = middle - 1;
                else
                    start = middle + 1;
            }

            return -1;
        }
    }
}
