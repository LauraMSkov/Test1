using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //List<int> notSortedList = LoadJson(3);
            //List<int> sortedList = LoadJson(1);
            List<int> sortedList = new List<int> {1, 2, 3 , 4, 5};
            Console.WriteLine("Original list: " + string.Join(", ", sortedList));


            int comparisonCount = 0;
            MyList<int>.InsertSort(sortedList, Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort: " + comparisonCount);

            int comparisonQuick = 0;
            List<int> sorted = MyList<int>.QuickSort(sortedList, Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort: " + comparisonQuick);
            Console.WriteLine("Sorted list: " + string.Join(", ", sorted));

            Console.ReadKey();

            //Delopgave 2
            Console.WriteLine("Delopgave 2");
            Graph<string> graph = new Graph<string>();

            //Tilføjer nodes
            Node<string> entrance = new Node<string>("Entrance");
            Node<string> miniTrain = new Node<string>("Mini Train");
            Node<string> waterRide = new Node<string>("Water Ride");

            //Tilføjer node til graf
            graph.Nodes.Add(entrance);
            graph.Nodes.Add(miniTrain);
            graph.Nodes.Add(waterRide);

            //Kreere edges
            graph.Edges.Add(new Edge<string>(entrance, miniTrain));
            graph.Edges.Add(new Edge<string>(miniTrain, waterRide));

            //Vi laver først variable som holder startnoden og finder den gennem et foreach loop
            Node<string> startNode = null;
            foreach (Node<string> node in graph.Nodes)
            {
                if (node.Data == "Entrance")
                {
                    startNode = node;
                    break;
                }
            }

            //Vi laver en variable som holder slutnoden og finder den gennem et foreach loop
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
        public static List<int> LoadJson(int a)
        {
            string startPath = AppContext.BaseDirectory; ;
            if (a == 1)
            {
                startPath = Path.Combine(startPath, @"JSON files\sorted.json");
            }
            else if (a == 2)
            {
                startPath = Path.Combine(startPath, @"JSON files\reverseSorted.json");
            }
            else if (a == 3)
            {
                startPath = Path.Combine(startPath, @"JSON files\notSorted.json");
            }

            string JsonString = File.ReadAllText(startPath);
            var Jsondata = JsonSerializer.Deserialize<NumbersData>(JsonString);
            int[] nums = (Jsondata != null && Jsondata.Values != null) ? Jsondata.Values : Array.Empty<int>();
            List<int> values = new List<int>(nums);
            return values;
        }

        public void WriteJson(int[] values, int a)
        {
            string startPath = AppContext.BaseDirectory; ;
            if (a == 1)
            {
                startPath = Path.Combine(startPath, @"JSON files\postSorted.json");
            }
            else if (a == 2)
            {
                startPath = Path.Combine(startPath, @"JSON files\postReverseSorted.json");
            }
            else if (a == 3)
            {
                startPath = Path.Combine(startPath, @"JSON files\postNotSorted.json");
            }
            File.WriteAllText(startPath, values.ToString());
        }
        public class NumbersData
        {
            [JsonPropertyName("values")]
            public int[] Values { get; set; } = Array.Empty<int>();
        }
    }

}
