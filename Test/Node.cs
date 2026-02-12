using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Node <T>
    {   
        //Properties for Node klassen
        public T Data { get; private set; }
        public List<Edge<T>> Edges = new List<Edge<T>>();

        public Node<T> Parent { get; set; }

        public Node(T data)
        {
            Data = data;
            Parent = null;
        }

        /// <summary>
        /// Tilføjer kanter
        /// </summary>
        /// <param name="other"></param>
        public void AddEdge(Node<T> other)
        {
            Edges.Add(new Edge<T>(this, other));
        }
    }

}
