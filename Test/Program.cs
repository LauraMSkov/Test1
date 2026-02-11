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
            List<int> sortedList = LoadJson(1);
            List<int> reverseSortedList = LoadJson(2);
            List<int> notSortedList = LoadJson(3);

            int comparisonCount = 0;
            MyList<int>.InsertSort(notSortedList, Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort: " + comparisonCount);

            int comparisonQuick = 0;
            List<int> sorted = MyList<int>.QuickSort(notSortedList, Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort: " + comparisonQuick);
            Console.WriteLine("Sorted list: " + string.Join(", ", sorted));

            WriteJson(sorted, 1);

            Console.ReadKey();

            //Delopgave 2
            Console.WriteLine("Delopgave 2");
            Graph<string> graph = new Graph<string>();

            //Tilføjer node til graf
            graph.AddNode("Entrance");
            graph.AddNode("Mini Train");
            graph.AddNode("Water Ride");

            //Kreere edges
            graph.AddEdge("Entrance", "Mini Train");
            graph.AddEdge("Mini Train", "Water Ride");

            Node<string> startNode = graph.GetNode("Entrance");
            Node<string> goalNode = graph.GetNode("Water Ride");

            //Vi kalder nu vores DFS
            Node<string> result = Graph<string>.DFS(startNode, goalNode);
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

            string fullPath = Path.Combine(basePath, "JSON files", fileName);

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
