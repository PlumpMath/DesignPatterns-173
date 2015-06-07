using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class INPUT_LOW : INPUT
    {
        public INPUT_LOW()
            : base()
        {
            BitList.Add(0);
        }        
    }
}
