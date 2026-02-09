using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
