using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSimulator.Handlers;

namespace WFSimulator.Nodes
{
    public class BaseNode : Node
    {
        public BaseNode()
        {
            NextList = new List<Node>();
            PreviousList = new List<Node>();
            BitList = new List<int>();
        }

        public List<Node> NextList
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<Node> PreviousList
        {
            get;
            set;
        }

        public List<int> BitList
        {
            get;
            set;
        }

        public bool AddNext(Node node)
        {
            if (this != node)
            {
                NextList.Add(node);
                    return true;
            }
            return false;
            
        }

        public bool AddPrevious(Node node)
        {
            if (this != node)
            {
                PreviousList.Add(node);
                    return true;
            }
            return false;
        }

        public virtual void Send()
        {
            throw new NotImplementedException();
        }

        public virtual void CheckNode()
        {
            if (PreviousList.Count != 2)
            {
                throw new Exception(this.Name+" Node does not have two previous nodes connected");
            }

            if (NextList.Count == 0)
            {
                throw new Exception(this.Name+" Node does not have a next item");
            }
        }

        public virtual void Recieve(int input)
        {
            BitList.Add(input);
            Send();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
