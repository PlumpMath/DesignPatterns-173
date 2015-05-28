using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator
{
    public class CircuitStreamReader : StreamReader
    {
        private List<String> _lines;
        private String _file;

        public CircuitStreamReader(String fileName)
            : base(fileName)
        {
            _file = fileName;
            ExtractLines();

        }

        public void ExtractLines()
        {
            _lines = new List<String>(File.ReadAllLines(_file));

        }

        public int CountLines()
        {
            return _lines.Count;
        }
        public string GetLine(int index)
        {
            return _lines.ElementAt(index);
        }


    }
}
