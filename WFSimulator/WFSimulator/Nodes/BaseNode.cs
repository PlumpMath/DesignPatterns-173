using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSimulator.Nodes
{
    public class BaseNode : Node
    {
        public BaseNode()
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

        public bool CheckNext(Node node)
        {
            if (NextList.Count > 0)
            {
                if (NextList.Contains(node))
                {
                    return false;
                }
                else
                {
                    bool hasError = true;
                    foreach (Node n in NextList)
                    {
                        hasError = n.CheckNext(node);
                        if (!hasError)
                            break;
                    }
                    return hasError;
                }
            }
            else
            {
                return true;
            }
        }

        public bool CheckPrevious(Node node)
        {
            if (PreviousList.Count > 0)
            {
                if (PreviousList.Contains(node))
                {
                    return false;
                }
                else
                {
                    bool hasError = true;
                    foreach (Node n in PreviousList)
                    {
                        hasError = n.CheckPrevious(node);
                        if (!hasError)
                            break;
                    }
                    return hasError;
                }
            }
            else
            {
                return true;
            }
        }

        public bool AddNext(Node node)
        {
            if (this != node)
            {
                bool nextList = CheckNext(node);
                bool prevList = CheckPrevious(node);
                if (nextList && prevList)
                {
                    NextList.Add(node);
                    return true;
                }
            }
            return false;
            
        }

        public bool AddPrevious(Node node)
        {
            if (this != node)
            {
                bool nextList = CheckNext(node);
                bool prevList = CheckPrevious(node);
                if (nextList && prevList)
                {
                    PreviousList.Add(node);
                    return true;
                }
            }
            return false;
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Recieve(byte input)
        {
            BitList.Add(input);
            Send();
        }
    }
}
