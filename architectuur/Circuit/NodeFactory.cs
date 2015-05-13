using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit
{
    public sealed class NodeFactory
    {
        private static NodeFactory _nodeFactory = null;
        private static readonly object padlock = new object();

        NodeFactory() { }
        public static NodeFactory Instance
        {
            get{
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
    }
}
