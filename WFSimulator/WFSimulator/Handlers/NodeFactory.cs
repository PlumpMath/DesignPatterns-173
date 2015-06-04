using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSimulator.Nodes;

namespace WFSimulator.Handlers
{
    public sealed class NodeFactory
    {
        private static NodeFactory _nodeFactory = null;
        private static readonly object padlock = new object();
        private static NodeMediator _nodeMediator = null;

        NodeFactory() { }
        public static NodeFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_nodeFactory == null)
                    {
                        _nodeFactory = new NodeFactory();
                    }
                    return _nodeFactory;
                }
            }
        }

        public void setMediator(NodeMediator mediator)
        {
            _nodeMediator = mediator;
        }

        public Node MakeNode(String node)
        {
            Node result = null;
            try
            {
                Assembly assembly = Assembly.Load("WFSimulator");
                Type t = assembly.GetType("WFSimulator.Nodes." + node);
                result = (Node)Activator.CreateInstance(t);
            }
            catch (Exception)
            {
                MessageBox.Show("Class Not Found");
            }

            return result;
        }
    }
}
