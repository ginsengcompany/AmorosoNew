using System.Collections.Generic;

namespace Concorsi.Model
{
    public class Sessioni
    {
        public string idSessione { get; set; }
        public string idConcorso { get; set; }
        public string corpoConcorso { get; set; }
        public string codiceConcorso { get; set; }
        public string oraSessione { get; set; }
        public string nomeSet { get; set; }
        public List<RisultatoDomande> domande { get; set; }
    }
}
