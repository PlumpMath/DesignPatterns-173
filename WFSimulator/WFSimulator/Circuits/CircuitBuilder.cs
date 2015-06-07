using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSimulator.Handlers;
using WFSimulator.Nodes;

namespace WFSimulator.Circuits
{
    public class CircuitBuilder
    {
        private ObservableCollection<string> _StringList;
        public ObservableCollection<string> StringList
        {
            get
            {
                return _StringList;
            }
            set
            {
                _StringList = value;
            }
        }
        private Dictionary<string, Node> _nodeMap
        {
            get;
            set;
        }

        public Dictionary<string, Node> NodeMap
        {
            get
            {
                return _nodeMap;
            }
        }

        private CheckNodeVisitor Visitor
        {
            get;
            set;
        } 

        private Dictionary<string, string[]> _linkMap
        {
            get;
            set;
        }

        public Dictionary<string, string[]> LinkMap
        {
            get
            {
                return _linkMap;
            }
        }

        private object _nodeList
        {
            get;
            set;
        }

        private NodeMediator _NodeMediator
        {
            get;
            set;
        }
        private NodeFactory _NodeFactory
        {
            get;
            set;
        }

        public CircuitBuilder(NodeMediator mediator, NodeFactory factory)
        {
            _NodeMediator = mediator;
            _NodeFactory = factory;
            StringList = new ObservableCollection<string>();
            mediator.Register(this);
             Visitor = new CheckNodeVisitor();
        }

        public virtual IEnumerable<Node> Node
        {
            get;
            set;
        }

        public void Start()
        {
            foreach (Node node in NodeMap.Values)
            {
                node.Send();
            }
        }

#warning Improve this method
        public virtual void Build(String fileName)
        {
           
            _nodeMap = new Dictionary<string, Node>();
            _linkMap = new Dictionary<string, string[]>();
            StringList = new ObservableCollection<string>();
            CircuitStreamReader sReader = new CircuitStreamReader(fileName);
            for (int i = 0; i < sReader.CountLines(); i++)
            {
                String line = sReader.GetLine(i);
                if (line.IndexOf("#") < 0)
                {
                    if (line.Length > 0)
                    {
                        string[] parts = line.Split(':').Select(p => p.Trim().TrimEnd(';')).ToArray();
                        if (parts.Length == 2)
                        {
                            if (_nodeMap.ContainsKey(parts[0]))
                            {
                                string[] subParts = parts[1].Split(',').Select(p => p.Trim()).ToArray();
                                _linkMap.Add(parts[0], subParts);
                            }
                            else
                            {
                                Node node = _NodeFactory.MakeNode(parts[1]);
                                node.Name = parts[0];
                                _nodeMap.Add(parts[0], node);

                            }
                            StringList.Add("[" + parts[0] + "," + parts[1] + "]");
                        }

                    }

                }

            }
            StringList.Add("");
            StringList.Add("");
            if (LinkNodes(_nodeMap, _linkMap))
            {
                int x = 0;
                try
                {
                    foreach (Node node in NodeMap.Values)
                    {
                        node.CheckNode();
                    }
                }
                catch(Exception e)
                {
                    StringList.Add(e.Message);
                    x++;
                }
                if (x == 0)
                {
                    StringList.Add("Link Created");
                    Run();
                }
                
            }
            else
            {
                StringList.Add("Link Error Please check te file");
            }

        }

        public virtual void Run(){
            foreach (Node node in NodeMap.Values)
            {
                node.Send();
            }
        }

        public virtual bool LinkNodes(Dictionary<string, Node> nodeMap ,Dictionary<string, string[]> linkMap)
        {
            foreach (string link in linkMap.Keys)
            {
                if (nodeMap.ContainsKey(link))
                {
                    Node node = nodeMap[link];
                    foreach (string linkedlink in linkMap[link])
                    {
                        if (nodeMap.ContainsKey(linkedlink))
                        {
                            Node linkNode = nodeMap[linkedlink];
                            node.Accept(Visitor);
                            bool canNext = Visitor.CanAddNext(linkNode);
                            if (canNext)
                            {
                                node.AddNext(linkNode);
                            }
                            linkNode.Accept(Visitor);
                            bool canPrev = Visitor.CanAddPrevious(node);
                            if (canPrev)
                            {
                                linkNode.AddPrevious(node);
                            }
                            if (!canNext || !canPrev)
                            {
                                return false;
                            }
                        }
                        else
                            return false;
                    }
                }
                else
                    return false;
                
            }
            return true;
        }
    }
}
