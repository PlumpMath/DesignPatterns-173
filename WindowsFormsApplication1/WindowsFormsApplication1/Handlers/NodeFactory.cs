using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                Type type = Type.GetType("CircuitSimulator." + node.ToString());
                ConstructorInfo ctorInfo = type.GetConstructor(new[] { typeof(Node) });
                result = ctorInfo.Invoke(new Object[] { result }) as Node;
            }
            catch (Exception)
            {
                throw new Exception("Class Not Found");
            }

            return result;
        }
    }
}
