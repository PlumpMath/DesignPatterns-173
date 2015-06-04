using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test
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
                Assembly assembly = Assembly.Load("test");
                Type t = assembly.GetType("test." + node);
                result = (Node)Activator.CreateInstance(t);
            }
            catch (Exception)
            {
                Console.WriteLine("Class not Found");
            }

            return result;

        }
    }
}
