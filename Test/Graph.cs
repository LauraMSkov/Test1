using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Graph<T>
    {

        public Dictionary<T, Node<T>> Nodes { get; private set; } = new Dictionary<T, Node<T>>();
        public List<Edge<T>> Edges { get; private set; } = new List<Edge<T>>();

        public void AddNode(T value)
        {
            if (!Nodes.ContainsKey(value))
            {
                Nodes[value] = new Node<T>(value);
            }
            
        }

        public void AddEdge(T from, T to)
        {
            DirEdge(from, to);
            DirEdge(to, from);
        }

        public void DirEdge(T from, T to)
        {
            if(Nodes.ContainsKey(from) && Nodes.ContainsKey(to))
            {
                Nodes[from].AddEdge(Nodes[to]);
            }
        }

        public Node<T> GetNode(T value)
        {
            if (Nodes.ContainsKey(value))
            {
                return Nodes[value];
            }
            else
            {
                return null;
            }
        }

        public static Node<T> DFS(Node<T> start, Node<T> goal)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();
            stack.Push(start);
            //start.Parent = start;

            while (stack.Count > 0)
            {
                //Stacken laver en liste over noderne
                Node<T> current = stack.Pop();
                if (visited.Contains(current))
                {
                    continue;
                }

                visited.Add(current);

                if (current == goal)
                {
                    Console.WriteLine($"\nVisited DFS");
                    foreach (Node<T> v in visited)
                    {
                        Console.WriteLine($"{v.Data}");
                    }
                    return current;
                }


                foreach (Edge<T> e in current.Edges)
                {
                    if (!visited.Contains(e.To))
                    {
                        stack.Push(e.To);
                        e.To.Parent = current;
                    }
                }
            }


            return null;

        }

        public static Node<T> BFS(Node<T> start, Node<T> goal)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();
            queue.Enqueue(start);
            //start.Parent = start;
            visited.Add(start);

            while (queue.Count > 0)
            {
                //Stacken laver en liste over noderne
                Node<T> current = queue.Dequeue();
                if (current == goal)
                {
                    Console.WriteLine($"\nVisited BFS");
                    foreach (Node<T> v in visited)
                    {
                        Console.WriteLine($"{v.Data}");
                    }
                    return current;
                }

                foreach (Edge<T> e in current.Edges)
                {
                    if (!visited.Contains(e.To))
                    {
                        visited.Add(e.To);
                        queue.Enqueue(e.To);
                        e.To.Parent = current;
                    }
                }
            }


            return null;
        }

        public static void PrintPath(Node<T> goalNode)
        {
           
            List<Node<T>> path = new List<Node<T>>();
            Node<T> current = goalNode;
            
            if (goalNode == null)
            {
                Console.WriteLine("Path ikke fundet");
                return;
            }

            while(current != null)
            {
                path.Add(current);
                current = current.Parent;
            }

            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(path[i].Data);
            }


        }
      
    }
 
}
