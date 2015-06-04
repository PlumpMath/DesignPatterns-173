using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSimulator.Circuits;
using WFSimulator.Nodes;

namespace WFSimulator.Handlers
{
    public class NodeMediator
    {
        private CircuitBuilder _circuitBuilder;

        public void Register(CircuitBuilder circuitBuilder)
        {
            _circuitBuilder = circuitBuilder;
        }

        public void Send()
        {
            _circuitBuilder.Start();
        }
    }
}
