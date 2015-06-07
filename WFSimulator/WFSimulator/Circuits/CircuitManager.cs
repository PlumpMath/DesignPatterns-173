using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSimulator.Nodes;

namespace WFSimulator.Circuits
{
    public class CircuitManager
    {
        private CircuitBuilder _CircuitBuilder;
        private bool canRun;

        public CircuitManager(CircuitBuilder circuit){
            _CircuitBuilder = circuit;
            canRun = false;
        }

        public void BuildCircuit(string fileName)
        {
            _CircuitBuilder.Build(fileName);
            canRun = _CircuitBuilder.checkCircuit();
        }

        public ObservableCollection<string> getOutput()
        {
            return _CircuitBuilder.StringList;
        }

        public void Run()
        {
            if (canRun)
            {
                foreach (Node node in _CircuitBuilder.NodeMap.Values)
                {
                    node.Send();
                }
            }
            else
            {
                MessageBox.Show("No Corrent Circuit Loaded Yet.");
            }
        }

    }
}
