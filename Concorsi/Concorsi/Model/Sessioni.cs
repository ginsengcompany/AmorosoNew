using System.Collections.Generic;

namespace Concorsi.Model
{
  

    public class Domande
    {
        public string domanda { get; set; }
        public string risposta { get; set; }
        public string risposta_utente { get; set; }
        public string esito { get; set; }
    }

    public class Sessione
    {
        public string idSessione { get; set; }
        public string oraSessione { get; set; }
        public string idConcorso { get; set; }
        public string corpoConcorso { get; set; }
        public string codiceConcorso { get; set; }
        public string nomeSet { get; set; }
        public List<Domande> domande { get; set; }
    }

    public class Sessioni
    {
        public string dataSessione { get; set; }
        public List<Sessione> sessioni { get; set; }
    }
}
