using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class INPUT : BaseNode
    {
        public INPUT()
            : base()
        {

        }

        public override void Send()
        {
            if (BitList.Count > PreviousList.Count)
            {
                foreach (Node next in NextList)
                {
                    next.Recieve(BitList[0]);
                }
                BitList.Clear();
            }
        }

        public override void CheckNode()
        {
            if (PreviousList.Count > 0)
            {
                throw new Exception("INPUT has a previous connected");
            }
        }
    }
}
