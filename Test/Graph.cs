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
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

        public void AddNode(T node)
        {
            Nodes.Add(new Node<T>(node));
        }

        public void AddDirectedEdge(T from, T to)
        {
            Node<T> fromNode = Nodes.Find(x => x.Data.Equals(from));
            Node<T> toNode = Nodes.Find(x => x.Data.Equals(to));
            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode);
            }
            else
            {
                Console.WriteLine("Node ikke fundet");
            }
        }

        public void AddEdge(T from, T to)
        {
            Node<T> fromNode = Nodes.Find(x => x.Data.Equals(from));
            Node<T> toNode = Nodes.Find(x => x.Data.Equals(to));

            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode);
                toNode.AddEdge(fromNode);
            }
            else
            {
                Console.WriteLine("Node ikke fundet");
            }

        }

        private static Node<T> DFS<T>(Node<T> start, Node<T> goal)
        {
            Stack<Edge<T>> edges = new Stack<Edge<T>>();
            edges.Push(new Edge<T>(start, start));

            while (edges.Count > 0)
            {
                Edge<T> edge = edges.Pop();

                if (!edge.To.Visited)
                {
                    edge.To.Visited = true;
                    edge.To.Parent = edge.From;
                }
                if (edge.To == goal)
                {
                    return edge.To;
                }
            }

            return null;
        }

      
    }
 
}
