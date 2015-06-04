using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitSimulator
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
