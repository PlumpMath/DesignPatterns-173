using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSimulator.Handlers;

namespace WFSimulator.Circuits
{
    public class CircuitController
    {
        private NodeMediator _NodeMediator;

        private CircuitManager _CircuitManager;

        public CircuitController(NodeMediator mediator, CircuitManager manager)
        {
            _NodeMediator = mediator;
            _CircuitManager = manager;
        }

        public void Start()
        {
            _CircuitManager.Run();
        }

        public void BuildCircuit(string file)
        {
            _CircuitManager.BuildCircuit(file);
        }

        public ObservableCollection<string> getOutput()
        {
            return _CircuitManager.getOutput();
        }

        public void CalculateDelay()
        {
            throw new System.NotImplementedException();
        }
    }
}
