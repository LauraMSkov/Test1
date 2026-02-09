using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class MyList<T>
    {

        public static void AddToList(T a, List<T> b)
        {
            b.Add((T)Convert.ChangeType(a, typeof(T)));
        }

        public static T FindInList(int a, List<T> b)
        {
            return b[a];
        }

        public static int ListLength(List<T> a)
        {
            return a.Count;
        }

        public static List<T> QuickSort(List<T> a, IComparer<T> comparer, ref int comparisonQuick)
        {
            if (a.Count <= 1)
            {
                return a;
            }

            T pivot = a[0];

            List<T> before = new List<T>();
            List<T> after = new List<T>();

            for (int i = 1; i < a.Count; i++)
            {
                comparisonQuick++;

                if (comparer.Compare(a[i], pivot) < 0)
                {
                    before.Add(a[i]);
                }
                else
                {
                    after.Add(a[i]);
                }
            }

            List<T> result = new List<T>();
            result.AddRange(QuickSort(before, comparer, ref comparisonQuick));
            result.Add(pivot);
            result.AddRange(QuickSort(after, comparer, ref comparisonQuick));
            return result;
        }

        public static void InsertSort(List<T> b, ref int comparisonCount)
        {
            for (int i = 1; i < b.Count; i++)
            {
                T val = b[i];
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
