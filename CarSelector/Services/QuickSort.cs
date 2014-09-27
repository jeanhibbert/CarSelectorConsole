
namespace CarSelector.Services
{
    using CarSelector.Model;

    public class QuickSort<T> where T : ICompletionTime
    {
        T[] input;

        public QuickSort(T[] values)
        {
            input = new T[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                input[i] = values[i];
            }

        }

        public T[] Output
        {
            get
            {
                return input;
            }
        }
        public void Sort()
        {
            Sorting(0, input.Length - 1);
        }
        public int getPivotPoint(int begPoint, int endPoint)
        {
            int pivot = begPoint;
            int m = begPoint + 1;
            int n = endPoint;
            while ((m < endPoint) &&
                   (input[pivot].CompletionTime >= input[m].CompletionTime))
            {
                m++;
            }

            while ((n > begPoint) &&
                   (input[pivot].CompletionTime <= input[n].CompletionTime))
            {
                n--;
            }
            while (m < n)
            {
                T temp = input[m];
                input[m] = input[n];
                input[n] = temp;

                while ((m < endPoint) &&
                       (input[pivot].CompletionTime >= input[m].CompletionTime))
                {
                    m++;
                }

                while ((n > begPoint) &&
                       (input[pivot].CompletionTime <= input[n].CompletionTime))
                {
                    n--;
                }

            }
            if (pivot != n)
            {
                T temp2 = input[n];
                input[n] = input[pivot];
                input[pivot] = temp2;

            }
            return n;

        }
        public void Sorting(int beg, int end)
        {
            if (end == beg)
            {
                return;
            }
            else
            {
                int pivot = getPivotPoint(beg, end);
                if (pivot > beg)
                    Sorting(beg, pivot - 1);
                if (pivot < end)
                    Sorting(pivot + 1, end);
            }
        }
    }
}
