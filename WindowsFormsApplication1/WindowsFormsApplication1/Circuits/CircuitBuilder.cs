using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator
{
    public class CircuitBuilder
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private Dictionary<string, Node> _linkMap
        {
            get;
            set;
        }

        public Dictionary<string, Node> LinkMap
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
        }

        public virtual IEnumerable<Node> Node
        {
            get;
            set;
        }

        public virtual void Build(String fileName)
        {
            _nodeMap = new Dictionary<string, Node>();
            _linkMap = new Dictionary<string, Node>();
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
                                _linkMap.Add(parts[0], null);
                            }
                            else
                            {
                               Node node = _NodeFactory.MakeNode(parts[1]);
                                _nodeMap.Add(parts[0], node);

                            }
                            Console.WriteLine("[" + parts[0] + "," + parts[1] + "]");
                            StringList.Add("[" + parts[0] + "," + parts[1] + "]");
                        }

                    }

                }

            }
            Console.WriteLine("Done");
        }

    }
}
