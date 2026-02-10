using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int comparisonCount = 0;
            MyList<int>.InsertSort(list, Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort: " + comparisonCount);

            int comparisonQuick = 0;
            List<int> sorted = MyList<int>.QuickSort(list, Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort: " + comparisonQuick);

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
            graph.AddEdge("Carousel", "Mini Train");
            graph.AddEdge("Carousel", "Ice Cream");
            graph.AddEdge("Carousel", "Roller Coaster");
            graph.AddEdge("Carousel", "Haunted House");

            //Tilføjer kanter fra Haunted House
            graph.AddEdge("Haunted House", "Mini Train");

            //Tilføjer kanter fra Roller Coaster
            graph.AddEdge("Roller Coaster", "Mini Train");
            graph.AddEdge("Roller Coaster", "Climbing Tower");

            //Tilføjer Kanter fra Climbing Tower
            graph.AddEdge("Climbing Tower", "Volcano Ride");

            //Tilføjer kanter fra Mini Train
            graph.AddEdge("Mini Train", "Water Ride");

            //Tilføjer kanter fra Ice Cream
            graph.AddEdge("Ice Cream", "Pirate Ship");

            Node<string> n = Graph<string>.DFS<string>(graph.Nodes.Find(x => x.Data == "Entrance"), graph.Nodes.Find(x => x.Data == "Volcano Ride"));
            List<Node<string>> path = TrackPath<string>(n, graph.Nodes.Find(x => x.Data == "Entrance"));
            Console.WriteLine("DFS vej fra Entrance til Volcano Ride");
            foreach (Node<string> pathNode in path)
            {
                Console.WriteLine(pathNode.Data);
            }

            
        }

        private static List<Node<T>> TrackPath<T>(Node<T> node, Node<T> start)
        {
            List<Node<T>> path = new List<Node<T>>();

            while (!node.Equals(start))
            {
                path.Add(node);
                node = node.Parent;
            }

            path.Add(start);
            path.Reverse();
            return path;
        }
    }




}
