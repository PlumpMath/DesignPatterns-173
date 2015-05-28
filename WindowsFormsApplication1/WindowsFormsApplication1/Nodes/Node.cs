using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator
{
    public interface Node
    {
        List<Node> NextList { get; set; }

        List<Node> PreviousList { get; set; }

        List<Byte> BitList { get; set; }

        void AddNext(Node node);

        void AddPrevious(Node node);

        void Send();

        void Recieve(byte input);
    }
}
