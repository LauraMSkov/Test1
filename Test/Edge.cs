using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Edge<T>
    {
        //Properties for klassen Edge
        public Node<T> From { get; private set; }
        public Node<T> To { get; private set; }

        public Edge(Node<T> from, Node<T> to)
        {
            From = from;
            To = to;
        }
    }
}
