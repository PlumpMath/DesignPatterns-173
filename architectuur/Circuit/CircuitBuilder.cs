using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit
{
    public class CircuitBuilder
    {
        private object _nodeMap
        {
            get;
            set;
        }

        private object _nodeList
        {
            get;
            set;
        }

        private NodeMediator _NodeMediator
        {
            get;
            set;
        }
        private NodeFactory _NodeFactory
        {
            get;
            set;
        }

        public CircuitBuilder(NodeMediator mediator, NodeFactory factory)
        {
            _NodeMediator = mediator;
            _NodeFactory = factory;
        }

        public virtual IEnumerable<Node> Node
        {
            get;
            set;
        }

        public virtual void Build()
        {
            CircuitStreamReader sReader = new CircuitStreamReader();
        }
    }
}
