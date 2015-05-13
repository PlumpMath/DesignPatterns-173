using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit
{
    public abstract interface Node
    {
        List<Node> NextList { get; set; }

        List<Node> PreviousList { get; set; }

        List<Byte> BitList { get; set; }

        public void AddNext(Node node);

        public void AddPrevious(Node node);

        public void Send();

        public void Recieve(byte input);
    }
}
