using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeFactory nodeFactory = NodeFactory.Instance;
            Node node = nodeFactory.MakeNode("INPUT");
            node.Speak();
        }
    }
}
