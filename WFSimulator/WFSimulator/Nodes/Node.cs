using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSimulator.Handlers;

namespace WFSimulator.Nodes
{
    public interface Node
    {
        List<Node> NextList { get; set; }

        List<Node> PreviousList { get; set; }

        List<int> BitList { get; set; }

        bool AddNext(Node node);

        bool AddPrevious(Node node);

        string Name { get; set; }

        void Send();

        void Recieve(int input);

        void CheckNode();

        void Accept(IVisitor vistor);
    }
}
