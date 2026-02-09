using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Edge<T>
    {
        public Node<T> From { get; set; }
        public Node<T> To { get; set; }

        public Edge(Node<T> from, Node<T> to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
