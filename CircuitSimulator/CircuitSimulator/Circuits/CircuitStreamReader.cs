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
        {
            _lines = new List<String>();
            _file = fileName;
        }

        

    }
}
