using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSimulator.Nodes
{
    public class PROBE : BaseNode
    {
        public PROBE() : base() { }
        public override void Send()
        {
            if (BitList.Count == PreviousList.Count)
            {

                MessageBox.Show(Name+": " + BitList[0]);
                BitList.Clear();
            }
        }

        public override void CheckNode()
        {
            if (PreviousList.Count > 1)
            {
                throw new Exception("Probe has too many previous nodes");
            }

            if (NextList.Count > 0)
            {
                throw new Exception("Probe has a next node connected to it");
            }
        }
    }
}
