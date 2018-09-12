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


        public DatiStatistica()
        {
            domandeTotali = 0;
            tempoTotale = "";
            domandeEsatte = 0;
            domandeErrate = 0;
            domandeNonRisposte = 0;
        }

        public DatiStatistica(DatiStatistica dati)
        {
            domandeTotali = dati.domandeTotali;
            tempoTotale = dati.tempoTotale;
            domandeEsatte = dati.domandeEsatte;
            domandeErrate = dati.domandeErrate;
            domandeNonRisposte = dati.domandeNonRisposte;
        }
    }

    public class BindingStatistica
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public BindingStatistica(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
