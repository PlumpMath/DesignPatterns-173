using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class OR : BaseNode
    {
        public OR() : base() { }

        public override void Send()
        {
            if (BitList.Count == PreviousList.Count)
            {

                int answer = BitList[0] + BitList[1];
                if (answer == 2)
                    answer = 1;

                foreach (Node next in NextList)
                {
                    next.Recieve(answer);
                }
                BitList.Clear();
            }
        }
    }
}
