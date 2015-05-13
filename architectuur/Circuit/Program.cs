using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeMediator mediator = new NodeMediator();
            NodeFactory factory = NodeFactory.Instance;
            CircuitBuilder builder = new CircuitBuilder(mediator, factory);
            CircuitController ctrl = new CircuitController(mediator,builder);
        }
    }
}
