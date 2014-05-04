using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiktionary
{
    class Definition
    {
        public List<string> definitions = new List<string>();
        int defs = 0;

        public Definition()
        {
        }

        public void Add(string s)
        {
            definitions.Add(s);
        }

        public string Get()
        {
            return string.Join("\n", definitions.ToArray());
        }
    }
}
