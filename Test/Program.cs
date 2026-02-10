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
            Node<string> entrance = new Node<string>("Entrance");
            Node<string> miniTrain = new Node<string>("Mini Train");
            Node<string> waterRide = new Node<string>("Water Ride");

            //Tilføjer node til graf
            graph.Nodes.Add(entrance);
            graph.Nodes.Add(miniTrain);
            graph.Nodes.Add(waterRide);

            graph.Edges.Add(new Edge<string>(entrance, miniTrain));
            graph.Edges.Add(new Edge<string>(miniTrain, waterRide));

            //Vi laver først variabler som holder noderne vil leder efter
            Node<string> startNode = null;

            //Vi finder nu start noden gennem et foreach loop
            foreach (Node<string> node in graph.Nodes)
            {
                if (node.Data == "Entrance")
                {
                    startNode = node;
                    break;
                }
            }

            //Vi finder nu slut noden gennem et foreach loop
            Node<string> goalNode = null;
            foreach (Node<string> node in graph.Nodes)
            {
                if (node.Data == "Water Ride")
                {
                    goalNode = node;
                    break;
                }
            }

            //Vi kalder nu vores DFS
            Node<string> result = Graph<string>.DFS<string>(startNode, goalNode, graph.Edges);

            Console.WriteLine("DFS vej fra Entrance til Water Ride");
            Graph<string>.PrintPath(result);



        }

    }

}
