using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concorsi.Service
{
    public class Header
    {
        public string header;
        public string value;

        public Header() { }

        public Header(string header, string value)
        {
            this.header = header;
            this.value = value;
        }
    }
}
