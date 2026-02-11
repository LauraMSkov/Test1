using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
    [assembly: InternalsVisibleTo("UnitTestTest")]
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sortedList = LoadJson(1);
            List<int> reverseSortedList = LoadJson(2);
            List<int> notSortedList = LoadJson(3);

            MyList<int> myListSorted = new MyList<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                myListSorted.Add(sortedList[i]);
            }
            MyList<int> myListReverseSorted = new MyList<int>();
            for (int i = 0; i < reverseSortedList.Count; i++)
            {
                myListReverseSorted.Add(reverseSortedList[i]);
            }
            MyList<int> myListNotSorted = new MyList<int>();
            for (int i = 0; i < notSortedList.Count; i++)
            {
                myListNotSorted.Add(notSortedList[i]);
            }

            int comparisonCount = 0;
            myListNotSorted.InsertSort(Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort: " + comparisonCount);

            int comparisonQuick = 0;
            myListNotSorted.QuickSort(Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort: " + comparisonQuick);
            Console.WriteLine("Sorted list: " + string.Join(", ", sorted));

            WriteJson(sorted, 1);

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
                startPath = Path.Combine(startPath, @"JSONfiles\sorted.json");
            }
            else if (a == 2)
            {
                startPath = Path.Combine(startPath, @"JSONfiles\reverseSorted.json");
            }
            else if (a == 3)
            {
                startPath = Path.Combine(startPath, @"JSONfiles\notSorted.json");
            }

            string JsonString = File.ReadAllText(startPath);
            var Jsondata = JsonSerializer.Deserialize<NumbersData>(JsonString);
            int[] nums = (Jsondata != null && Jsondata.Values != null) ? Jsondata.Values : Array.Empty<int>();
            List<int> values = new List<int>(nums);
            return values;
        }

        public static void WriteJson(List<int> values, int a)
        {
            string basePath = AppContext.BaseDirectory;
            string fileName;
            if (a == 1)
            {
                fileName = "postSorted.json";
            }
            else if (a == 2)
            {
                fileName = "postReverseSorted.json";
            }
            else if (a == 3)
            {
                fileName = "postNotSorted.json";
            }
            else
            {
                throw new ArgumentException("Invalid value for 'a'");
            }

            string fullPath = Path.Combine(basePath, "JSONfiles", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string jsonString = JsonSerializer.Serialize(
                new { Values = values },
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(fullPath, jsonString);
        }
        public class NumbersData
        {
            [JsonPropertyName("values")]
            public int[] Values { get; set; } = Array.Empty<int>();
        }
    }

}
