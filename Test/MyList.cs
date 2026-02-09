using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class MyList<T>
    {

        public static void AddToList(int a, List<T> b)
        {
            b.Add((T)Convert.ChangeType(a, typeof(T)));
        }

        public static int FindInList(int a, List<int> b)
        {
            return b[a];
        }

        public static int ListLength(List<T> a)
        {
            return a.Count;
        }

        public static List<int> QuickSort(List<int> a, ref int comparisonCount)
        {
            if (a.Count <= 1)
            {
                return a;
            }

            int pivot = a[0];

            List<int> before = new List<int>();
            List<int> after = new List<int>();

            for (int i = 1; i < a.Count; i++)
            {
                comparisonCount++;

                if (a[i] < pivot)
                {
                    before.Add(a[i]);
                }
                else
                {
                    after.Add(a[i]);
                }
            }

            List<int> result = new List<int>();
            result.AddRange(QuickSort(before, ref comparisonCount));
            result.Add(pivot);
            result.AddRange(QuickSort(after, ref comparisonCount));
            return result;
        }

        public static void InsertSort(List<int> b, ref int comparisonCount)
        {
            for (int i = 1; i < b.Count; i++)
            {
                int val = b[i];
                int pointer = i;

                //Kode gøre  længere så man sikre sig at tælle sammenligningen korrekt med Count
                while (pointer > 0)
                {
                    comparisonCount++;
                    if (b[pointer - 1] > val)
                    {
                        b[pointer] = b[pointer - 1];
                        pointer--;
                    }
                    else
                    {
                        break;
                    }
                }

                b[pointer] = val;
            }
        }
    }
}
