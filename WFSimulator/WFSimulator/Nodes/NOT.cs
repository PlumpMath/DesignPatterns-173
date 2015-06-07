using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class NOT: BaseNode
    {
        public NOT() : base() { }

        public override void Send()
        {
            if (BitList.Count == PreviousList.Count)
            {

                int answer = (BitList[0] == 1) ? 0 : 1;

                foreach (Node next in NextList)
                {
                    next.Recieve(answer);
                }
                BitList.Clear();
            }
        }

        public override void CheckNode()
        {
            if (PreviousList.Count != 1)
            {
                throw new Exception("NOT Node does not have a previous node connected");
            }

            if (NextList.Count != 1)
            {
                throw new Exception("NOT Node does not have a next item");
            }
        }
    }
}
