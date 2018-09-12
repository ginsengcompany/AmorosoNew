using System.Collections.Generic;
using System.Drawing;

namespace Concorsi.Model
{
    public class RisultatoDomande
    {
        public string domanda { get; set; }
        public string risposta { get; set; }
        public string risposta_utente { get; set; }
        public string esito { get; set; }

        public Color color { get; set; }
        public bool lbl_RispostaUtente { get; set; } = true;
    }

    public class Sessione
    {
        public string idSessione { get; set; }
        public string oraSessione { get; set; }
        public string idConcorso { get; set; }
        public string corpoConcorso { get; set; }
        public string codiceConcorso { get; set; }
        public string nomeSet { get; set; }
        public List<RisultatoDomande> domande { get; set; }
    }

    public class Cronologia
    {
        public string dataSessione { get; set; }
        public List<Sessione> sessioni { get; set; }
    }
}
