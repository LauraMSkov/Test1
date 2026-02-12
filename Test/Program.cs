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
            //Delopgave 1

            //Lister af vores json filer
            List<int> sortedList = LoadJson(1);
            List<int> reverseSortedList = LoadJson(2);
            List<int> notSortedList = LoadJson(3);

            //Opretter MyLists og giver dem indholdet af de forrige Lists
            MyList<int> myListSortedInsert = new MyList<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                myListSortedInsert.Add(sortedList[i]);
            }
            MyList<int> myListReverseSortedInsert = new MyList<int>();
            for (int i = 0; i < reverseSortedList.Count; i++)
            {
                myListReverseSortedInsert.Add(reverseSortedList[i]);
            }
            MyList<int> myListNotSortedInsert = new MyList<int>();
            for (int i = 0; i < notSortedList.Count; i++)
            {
                myListNotSortedInsert.Add(notSortedList[i]);
            }

            //Kører InsertSort på MyList og udskriver antal sammenligninger
            int comparisonCount = 0;
            myListSortedInsert.InsertSort(Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort på en sorterede Liste: " + comparisonCount);

            comparisonCount = 0;
            myListReverseSortedInsert.InsertSort(Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort på en omvendtsorteret liste: " + comparisonCount);

            comparisonCount = 0;
            myListNotSortedInsert.InsertSort(Comparer<int>.Default, ref comparisonCount);
            Console.WriteLine("Sammenligninger for InsertSort på en random sorterede liste: " + comparisonCount);

            //Laver nye MyLists til QuickSort
            MyList<int> myListSortedQuick = new MyList<int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                myListSortedQuick.Add(sortedList[i]);
            }
            MyList<int> myListReverseSortedQuick = new MyList<int>();
            for (int i = 0; i < reverseSortedList.Count; i++)
            {
                myListReverseSortedQuick.Add(reverseSortedList[i]);
            }
            MyList<int> myListNotSortedQuick = new MyList<int>();
            for (int i = 0; i < notSortedList.Count; i++)
            {
                myListNotSortedQuick.Add(notSortedList[i]);
            }

            //Kører Quicksort på MyListerne og udskriver antal sammenligninger
            int comparisonQuick = 0;
            myListSortedInsert.QuickSort(Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort på en sorterede liste: " + comparisonQuick);

            comparisonQuick = 0;
            myListReverseSortedInsert.QuickSort(Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort på en omvendt sorterede liste: " + comparisonQuick);

            comparisonQuick = 0;
            myListNotSortedInsert.QuickSort(Comparer<int>.Default, ref comparisonQuick);
            Console.WriteLine("Sammenligninger for QuickSort på en random sorterede liste: " + comparisonQuick);

            //Console.WriteLine("Sorted list: " + string.Join(", ", sorted));

            //WriteJson(sorted, 1);

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

            //Sætter variablerne af hvor roden er og noden man skal finde hen til
            Node<string> startNode = graph.GetNode("Entrance");
            Node<string> goalNode = graph.GetNode("Water Ride");
            Node<string> goalNode1 = graph.GetNode("Volcano Ride");

            //Vi kalder nu vores DFS, vej fra Entrance til Water Ride
            Node<string> resultDFS = Graph<string>.DFS(startNode, goalNode);
            Console.WriteLine("\nDFS vej fra Entrance til Water Ride");
            Graph<string>.PrintPath(resultDFS);

            //DFS, vej fra Entrance til Volcano Ride
            Node<string> resultDFS1 = Graph<string>.DFS(startNode, goalNode1);
            Console.WriteLine("\nDFS vej fra Entrance til Volcano Ride");
            Graph<string>.PrintPath(resultDFS1);

            //BFS, vej fra Entrance til Water Ride
            Node<string> resultBFS = Graph<string>.BFS(startNode, goalNode);
            Console.WriteLine("BFS vej fra Entrance til Water Ride");
            Graph<string>.PrintPath(resultBFS);

            //BFS, vej fra Entrance til Water Ride
            Node<string> resultBFS1 = Graph<string>.BFS(startNode, goalNode1);
            Console.WriteLine("BFS vej fra Entrance til Volcano Ride");
            Graph<string>.PrintPath(resultBFS1);

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
