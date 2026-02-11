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

            //Tilføjer node til graf
            graph.AddNode("Entrance");
            graph.AddNode("Carousel");
            graph.AddNode("Mini Train");
            graph.AddNode("Ice Cream");
            graph.AddNode("Roller Coaster");
            graph.AddNode("Haunted House");
            graph.AddNode("Water Ride");
            graph.AddNode("Pirate Ship");
            graph.AddNode("Climbing Tower");
            graph.AddNode("Volcano Ride");

            //Kreere edges
            graph.AddEdge("Entrance", "Carousel");
            graph.AddEdge("Entrance", "Mini Train");
            graph.AddEdge("Entrance", "Ice Cream");
            graph.AddEdge("Carousel", "Roller Coaster");
            graph.AddEdge("Carousel", "Haunted House");
            graph.AddEdge("Mini Train", "Water Ride");
            graph.AddEdge("Ice Cream", "Pirate Ship");
            graph.AddEdge("Roller Coaster", "Climbing Tower");
            graph.AddEdge("Climbing Tower", "Volcano Ride");

            Node<string> startNode = graph.GetNode("Entrance");
            Node<string> goalNode = graph.GetNode("Water Ride");
            Node<string> goalNode1 = graph.GetNode("Volcano Ride");

            //Vi kalder nu vores DFS, vej fra Entrance til Water Ride
            Node<string> resultDFS = Graph<string>.DFS(startNode, goalNode);
            Console.WriteLine("\nDFS vej fra Entrance til Water Ride");
            Graph<string>.PrintPath(resultDFS);

            Node<string> resultDFS1 = Graph<string>.DFS(startNode, goalNode1);
            Console.WriteLine("\nDFS vej fra Entrance til Volcano Ride");
            Graph<string>.PrintPath(resultDFS1);

            //BFS
            //Node<string> resultBFS = Graph<string>.BFS(startNode, goalNode);
            //Console.WriteLine("BFS vej fra Entrance til Water Ride");
            //Graph<string>.PrintPath(resultBFS);

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
