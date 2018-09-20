using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class Materie
    {
        public string materia { get; set; }
        public string domandemateriamax { get; set; }
    }

    public class Concorso
    {
        public string id_concorso { get; set; }
        public string Corpo { get; set; }
        public string numerodomande { get; set; }
        public string rispostaesatta { get; set; }
        public string rispostaerrata { get; set; }
        public string domandemax { get; set; }
        public string codice_concorso { get; set; }
        public List<Materie> materie { get; set; }
    }
}
