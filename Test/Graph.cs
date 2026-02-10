using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Graph<T>
    {
        public List<Node<T>> Nodes { get; private set; } = new List<Node<T>>();
        public List<Edge<T>> Edges { get; private set; } = new List<Edge<T>>();

        /*public void AddNode(T node)
        {
            Nodes.Add(new Node<T>(node));
        }

        public void AddEdge(T from, T to)
        {
            Node<T> fromNode = null;
            Node<T> toNode = null;

            //Finder from noden
            foreach (Node<T> node in Nodes)
            {
                //Man kn risikere at node.Data kan være null, og for at håndtere det sikret skrives kode på understående måde
                if (Equals(node.Data, from))
                {
                    fromNode = node;
                    break;
                }
            }

            //Finder to noden
            foreach(Node<T> node in Nodes)
            {
                if (Equals(node.Data, to))
                {
                    toNode = node;
                    break;
                }
            }

            if (fromNode !=null && toNode !=null)
            {
                fromNode.AddEdge(toNode);
                toNode.AddEdge(fromNode);
            }
            else
            {
                Console.WriteLine("Node ikke fundet");
            }
        }*/

        public static Node<T> DFS<T>(Node<T> start, Node<T> goal, List<Edge<T>> graphEdges)
        {
            if (start == null || goal == null)
            {
                return null;
            }
            
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(start);
            start.Visited = true;

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();

                if (current == goal)
                {
                    return current;
                }

                foreach (Edge<T> e in graphEdges)
                {
                    Node<T> neighbor = null;

                    if (e.From == current && !e.To.Visited)
                    {
                        neighbor = e.To;
                    }
                    else if (e.To == current && !e.From.Visited)
                    {
                        neighbor = e.From;
                    }
                    if (neighbor != null)
                    {
                        neighbor.Visited = true;
                        neighbor.Parent = current;
                        stack.Push(neighbor);
                    }
                }
            }

            return null;
        }

        public static void PrintPath(Node<T> goalNode)
        {
           
            List<T> path = new List<T>();
            Node<T> current = goalNode;

            while(current != null)
            {
                path.Add(current.Data);
                current = current.Parent;
            }

            if (goalNode == null)
            {
                Console.WriteLine("Path ikke fundet");
                return;
            }

            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(path[i]);
            }


        }
      
    }
 
}
