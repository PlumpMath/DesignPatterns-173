using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WFSimulator.Nodes;

namespace WFSimulator.Handlers
{
    public class CheckNodeVisitor : IVisitor
    {
        Node _visitedNode;

        List<Node> NextList
        {
            get { return _visitedNode.NextList; }
        }
        List<Node> PreviousList
        {
            get { return _visitedNode.PreviousList; }
        }

        public void Visit(Node node)
        {
            _visitedNode = node;
        }

        public bool CanAddNext(Node node)
        {
            if (this != node)
            {
                bool nextList = CheckNext(node);
                bool prevList = CheckPrevious(node);
                if (nextList && prevList)
                {
                    return true;
                }
            }
            return false;

        }

        public bool CanAddPrevious(Node node)
        {
            if (this != node)
            {
                bool nextList = CheckNext(node);
                bool prevList = CheckPrevious(node);
                if (nextList && prevList)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckNext(Node node)
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
                        CheckNodeVisitor visitor = new CheckNodeVisitor();
                        n.Accept(visitor);
                        hasError = visitor.CheckNext(node);
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

        private bool CheckPrevious(Node node)
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
                        CheckNodeVisitor visitor = new CheckNodeVisitor();
                        n.Accept(visitor);
                        hasError = visitor.CheckPrevious(node);
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
    }
}
