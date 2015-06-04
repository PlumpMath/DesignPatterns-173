using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSimulator.Handlers;

namespace WFSimulator.Circuits
{
    public class CircuitController
    {
        private NodeMediator _NodeMediator;

        private CircuitBuilder _CircuitBuilder;
        public CircuitBuilder CircuitBuilder
        {
            get
            {
                return _CircuitBuilder;
            }
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
