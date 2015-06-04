using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitSimulator
{
    public sealed class NodeFactory
    {
        private static NodeFactory _nodeFactory = null;
        private static readonly object padlock = new object();

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

        public Node MakeNode(String node)
        {
            Node result = null;
            byte bit = 0;
            try
            {
                if (node == "INPUT_HIGH")
                {
                    node = "INPUT";
                    bit = 1;
                }
                if (node == "INPUT_LOW")
                {
                    node = "INPUT";
                    bit = 0;
                }
                Assembly assembly = Assembly.Load("CircuitSimulator");
                Type t = assembly.GetType("CircuitSimulator." + node.ToString());
                //Type type = Type.GetType("CircuitSimulator." + node.ToString());
                ConstructorInfo ctorInfo = t.GetConstructor(new[] { typeof(Node) });
                result = ctorInfo.Invoke(new Object[] { result }) as Node;
                if (node == "INPUT")
                {
                    result.BitList.Add(bit);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Class Not Found");
            }

            return result;
        }
    }
}
