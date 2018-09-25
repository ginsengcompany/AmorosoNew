using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class URL
    {

        /**
         * Link ai servizi esposti lato piattaforma
         * */
        public string sitoAk12 { get; set; }
        public string paginaFacebook { get; set; }
        public string urlLocation { get; set; }
        public string urlBase { get; set; }
        public string login { get; set; }
        public string logout { get; set; }
        public string statistiche { get; set; }
        public string cronologia { get; set; }
        public string materie { get; set; }
        public string apprendimento { get; set; }
        public string domande { get; set; }
        public string salvaSessione { get; set; }
        public string datiSpeedQuiz { get; set; }
        public string salvaTempo { get; set; }
        public string domandePacchetti { get; set; }
        public string simulazione { get; set; }
        public string commenti { get; set; }

        /**
         * Costanti di servizio
         * */
        public static char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        /**
         * Costanti per il limite di domande ammesse per eseguire il test 
         * sulle domande contenute sull'intera banca dati amministratore
         * */
        public const int numeroMassimoDomandeAmmesso = 150;
        public const int numeroMassimoDomandeDelTestSuInteroDB = 100;

        public const string eseguiTestSuInteroDb = "Esercitazione su tutti i Concorsi";
    }
}