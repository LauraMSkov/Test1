using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Node <T>
    {
        public T Data { get; set; }
        public List<Edge<T>> Edges = new List<Edge<T>>();

        public bool Visited { get; set; } = false;

        public Node<T> Parent { get; set; }
        public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>();

        public Node(T data)
        {
            this.Data = data;
        }

        public void AddEdge(Node<T> other)
        {
            Edges.Add(new Edge<T>(this, other));
        }
    }

}
