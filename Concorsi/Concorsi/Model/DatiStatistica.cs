using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class DatiStatistica
    { 
        public int domandeTotali { get; set; }
        public string tempoTotale { get; set; }
        public int domandeEsatte { get; set; }
        public int domandeErrate { get; set; }
        public int domandeNonRisposte { get; set; }
    }
}
