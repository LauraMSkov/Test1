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

        public void AddNode(T node)
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
        }

        public static Node<T> DFS<T>(Node<T> start, Node<T> goal)
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

                foreach (Edge<T> e in edge.To.Edges)
                {
                    if (!e.To.Visited)
                    {
                        edges.Push(e);
                    }
                }
            }

            return null;
        }

      
    }
 
}
