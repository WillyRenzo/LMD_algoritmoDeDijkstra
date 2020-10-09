using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_de_Dijkstra
{
    class Path
    {
        public Node nodeFrom { get; set; }
        public Node nodeTo { get; set; }

        public int pathWeight { get; set; }

        public string fromNode
        {
            get
            {
                return nodeFrom.name;
            }
        }
        public string toNode
        {
            get
            {
                return nodeTo.name;
            }
        }

        public Path(Node _nodeFrom, Node _nodeTo, int _pathWeight)
        {
            nodeFrom = _nodeFrom;
            nodeTo = _nodeTo;
            pathWeight = _pathWeight;
        }

        public Node[] GetPath()
        {
            return new Node[] { nodeFrom, nodeTo };
        }
    }
}
