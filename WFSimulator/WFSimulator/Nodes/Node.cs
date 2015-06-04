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

        List<Byte> BitList { get; set; }

        bool AddNext(Node node);

        bool AddPrevious(Node node);

        void Send();

        void Recieve(byte input);

        bool CheckNext(Node node);

        bool CheckPrevious(Node node);
    }
}
