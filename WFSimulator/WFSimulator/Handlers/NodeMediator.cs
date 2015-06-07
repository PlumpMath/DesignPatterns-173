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
        private CircuitManager _circuitManager;

        public void Register(CircuitManager circuitManager)
        {
            _circuitManager = circuitManager;
        }

        public void Send()
        {
            _circuitManager.Run();
        }
    }
}
