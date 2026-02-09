using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program<T>
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int comparisonCount = 0;
            MyList<T>.InsertSort(list, ref comparisonCount);
            Console.WriteLine("Sammenligninger: " + comparisonCount);

            int comparisonQuick = 0;
            List<int> sorted = MyList<T>.QuickSort(list, ref comparisonQuick);
            Console.WriteLine("Sammenligninger: " + comparisonQuick);

            Graph<string> graph = new Graph<string>();
        }
    }
}
