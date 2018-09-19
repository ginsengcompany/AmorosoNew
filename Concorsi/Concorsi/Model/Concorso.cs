using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class Concorso
    { 
       
            // denominazione per esteso del concorso (Es. Esercito Marina Aeronautica", Corpo json)
            public string Corpo { get; set; }
            // identificativo numerico del concorso (Es. 5, id_concorso json)
            public string id_concorso { get; set; }
            // codice alfanumerico del concorso (Es. VFP4, codice_concorso json) 
            public string codice_concorso { get; set; }
            // punteggio associato alla risposta esatta (rispostaesatta json)
            public string rispostaesatta { get; set; }
            // punteggio associato alla risposta errata (rispostaerrata json)
            public string rispostaerrata { get; set; }
            // numedo delle domande contenute in una prova di tipo quiz veloce (numerodomande json)
            public string numerodomande { get; set; }
            // numero totale delle domande contenute nell'intero concorso (domandemax json)
            public string domandemax { get; set; }
        

    }
}
