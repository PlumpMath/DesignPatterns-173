using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class INPUT_HIGH : BaseNode
    {
        public INPUT_HIGH():base()
        {
            BitList.Add(1);
        }
        
        public void Send(){
        
        }
    }
}
