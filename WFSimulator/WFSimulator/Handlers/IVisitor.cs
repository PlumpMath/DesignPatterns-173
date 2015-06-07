using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFSimulator.Nodes;

namespace WFSimulator.Handlers
{
    public interface IVisitor
    {
        void Visit(Node node);
    }
}
