using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit
{
    public class CircuitController
    {
        private NodeMediator _NodeMediator
        {
            get;
            set;
        }

        private CircuitBuilder _CircuitBuilder
        {
            get;
            set;
        }

        public CircuitController(NodeMediator mediator, CircuitBuilder circuit)
        {
            _NodeMediator = mediator;
            _CircuitBuilder = circuit;
        }
        
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void CalculateDelay()
        {
            throw new System.NotImplementedException();
        }
    }
}
