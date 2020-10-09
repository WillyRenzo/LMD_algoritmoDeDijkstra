using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_de_Dijkstra
{
    class Node
    {
        public string name { get; set; }
        public int? orderOfLabelling { get; set; }
        public int workingValue { get; set; }

        public Node(string _name)
        {
            name = _name;
            orderOfLabelling = null;
            workingValue = int.MaxValue;
        }

        public void Reset()
        {
            orderOfLabelling = null;
            workingValue = int.MaxValue;
        }
    }
}
