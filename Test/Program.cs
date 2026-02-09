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

            //Tilføjer nodes
            graph.AddNode("Entrance");
            graph.AddNode("Carousel");
            graph.AddNode("Mini Train");
            graph.AddNode("Ice Cream");
            graph.AddNode("Roller Coaster");
            graph.AddNode("Haunted");
            graph.AddNode("Water Ride");
            graph.AddNode("Pirate Ship");
            graph.AddNode("Climbing Tower");
            graph.AddNode("Volcano Ride");

            //Tilføjer kanter fra Indgang
            graph.AddEdge("Entrance", "Carousel");
            graph.AddEdge("Entrance", "Mini Train");
            graph.AddEdge("Entrance", "Ice Cream");

            //Tilføjer kanter fra Carousel
            graph.AddEdge("Carousel", "Roller Coaster");
            graph.AddEdge("Carousel", "Haunted House");

            //Tilføjer kanter fra Roller Coaster
            graph.AddEdge("Roller Coaster", "Climbing Tower");

            //Tilføjer Kanter fra Climbing Tower
            graph.AddEdge("Climbing Tower", "Volcano Ride");
        }
    }
}
