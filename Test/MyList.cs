using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("UnitTestTest")]

namespace Test
{
    internal class MyList<T>
    {
        T[] items;
        private int index = 0;
        public int Count{ get{ return index; } }
        public MyList(int cap = 4) 
        {
            this.items = new T[cap];
        }
        public void Add(T item)
        {
            if (index+1 > items.Length)
            {
                Resize();
                items[index] = item;
                index++;
            }
        }
        private void Resize()
        {
            T[] newArr = new T[items.Length * 2];
            Array.Copy(items, newArr, items.Length);
            items = newArr;
        }

        public T this[int i]{ get { return items[i]; } set { items[i] = value; } }

        public void QuickSort(IComparer<T> comparer, ref int comparisonQuick)
        {
            QuickSort(this, comparer, ref comparisonQuick);
        }
        private MyList<T> QuickSort(MyList<T> a, IComparer<T> comparer, ref int comparisonQuick)
        {
            if (a.Count <= 1)
            {
                return a;
            }

            T pivot = a[0];

            MyList<T> before = new MyList<T>();
            MyList<T> after = new MyList<T>();

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

            MyList<T> result = new MyList<T>();
            MyList<T> sortedBefore = QuickSort(before, comparer, ref comparisonQuick);
            MyList<T> sortedAfter = QuickSort(after, comparer, ref comparisonQuick);
            for (int i = 0; i < sortedBefore.Count; i++)
            {
                result.Add(sortedBefore[i]);
            }
            result.Add(pivot);
            for (int i = 0; i < sortedAfter.Count; i++)
            {
                result.Add(sortedAfter[i]);
            }
            return result;
        }

        public void InsertSort(IComparer<T> comparer, ref int comparisonCount)
        {
            for (int i = 1; i < this.Count; i++)
            {
                T val = this[i];
                int pointer = i;

                //Kode gøre  længere så man sikre sig at tælle sammenligningen korrekt med Count
                while (pointer > 0)
                {
                    comparisonCount++;
                    if (comparer.Compare(this[pointer - 1], val) > 0)
                    {
                        this[pointer] = this[pointer - 1];
                        pointer--;
                    }
                    else
                    {
                        break;
                    }
                }

                this[pointer] = val;
            }
        }
    }
}
