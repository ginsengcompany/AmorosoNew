using System;
using System.Collections.Generic;
using Xamarin.Forms;

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

    public class Answers
    {
        public string Materia { get; set; }
        public string Sottocategoria { get; set; }
        public string id_domanda { get; set; }
        public string Codice { get; set; }
        public string Domanda { get; set; }
        public List<Quesiti> Quesiti { get; set; }
        public string Risposta { get; set; }
        public string tipo { get; set; }
        public string link { get; set; }
        public string urlVideo { get; set; }
    }
    public class Quesiti
    {
        public string quesito { get; set; }
        public string lettera { get; set; }
        public Color colore { get; set; } = Color.Black;
        public FontAttributes attribute { get; set; } = FontAttributes.None;
        public string visible { get; set; } = "true";
    }

    public class Quiz : Answers
    {
        public string risposta_esatta { get; set; }
        public string tempo_risposta { get; set; }
        public string risposta_utente { get; set; }
    }
    public class invioQuiz
    {
        public string username { get; set; }
        public string data_sessione { get; set; }
        public string ora_sessione { get; set; }
        public string nome_set { get; set; }
        public int numeroDomande { get; set; }
        public string tempoTotale { get; set; }
        public string punteggio { get; set; }
        public int risposteGiuste { get; set; } = 0;
        public int risposteSbagliate { get; set; } = 0;
        public int risposteNonDate { get; set; } = 0;
        public List<Quiz> quiz { get; set; }
    }
}
