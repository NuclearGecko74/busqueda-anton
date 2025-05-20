using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busqueda_anton.src.DataStructures
{
    internal class Node
    {
        public string key;
        public int value;
        public Node next;

        public Node(string key, int value)
        {
            this.key = key;
            this.value = value;
            next = null;
        }
    }
}
