using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class PianiFormativi
    {
        public string pianoFormativo { get; set; }
        public List<Set> set { get; set; }
    }
    public class Set
    {
        public string nome_set { get; set; }
        public string Descrizione { get; set; }
    }
}
