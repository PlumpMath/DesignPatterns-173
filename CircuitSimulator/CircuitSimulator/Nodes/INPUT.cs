using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator
{
    public class INPUT : Node
    {

        public INPUT()
        {
            NextList = new List<Node>();
            PreviousList = new List<Node>();
            BitList = new List<byte>();
        }
        public List<Node> NextList
        {
            get;
            set;
        }

        public List<Node> PreviousList
        {
            get;
            set;
        }

        public List<byte> BitList
        {
            get;
            set;
        }

        public void AddNext(Node node)
        {
            NextList.Add(node);
        }

        public void AddPrevious(Node node)
        {
            PreviousList.Add(node);
        }

        public void Send()
        {
            if (BitList.Count == NextList.Count)
            {
                foreach(Node node in NextList){
                    node.Recieve(1);
                }
            }
        }

        public void Recieve(byte input)
        {
            BitList.Add(input);
        }
    }
}
