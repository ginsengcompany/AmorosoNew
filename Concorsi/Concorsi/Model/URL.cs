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
        public const string sitoAK12 =
            "http://www.ak12srl.it";

        public const string paginaFacebook =
            "https://www.facebook.com/centro.militari/?fref=ts";

        public const string urlLocation =
                "https://www.google.it/maps/place/Viale+Italia,+53,+81020+San+Nicola+La+Strada+CE/@41.0507431,14.3264049,17z/data=!3m1!4b1!4m5!3m4!1s0x133a551ccb708adb:0xb134a991e304809a!8m2!3d41.0507431!4d14.3285936";

        public const string urlBase =
            "https://amorosoconcorsi.ak12srl.it/services/";

        public const string domandeNew =
          "http://192.168.125.97/servizioApp/domandeNew.php";
          //"https://amorosoconcorsi.ak12srl.it/services/servizioapp/domandeNew";

        public const string login =
            //"https://amorosoconcorsi.ak12srl.it/services/servizioapp/login";
            "http://192.168.125.97/amorosoNew/servizioapp/login";
        public const string Simulazione =
            "http://192.168.125.97/amorosoNew/servizioapp/simulazione";

        public const string logout =
            //"https://amorosoconcorsi.ak12srl.it/services/servizioapp/logout";
            "http://192.168.125.97/amorosoNew/servizioapp/logout";

        public const string domconcorsorandomNew =
            // "http://192.168.125.97/servizioApp/domandeconcorsorandomNew.php";
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/domconcorsorandomNew";

        public const string domconcorsosequenzaNew =
           // "http://192.168.125.97/servizioApp/domandeconcorsosequenzaNew.php";
           "https://amorosoconcorsi.ak12srl.it/services/servizioapp/domconcorsosequenzaNew";

        public const string sessione =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/sessione";

        public const string sessionePerTuttiConcorsi =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/sessionepertutticoncorsi";

        public const string pianoformativo =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/pianoformativo";

        public const string setdomande =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/setdomande";

        public const string concorsi =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/concorsi";

        public const string materieconcorso =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/materieconcorso";

        public const string statisticheURL = "http://192.168.125.97/amorosoNew/servizioapp/statistiche";
        // "https://amorosoconcorsi.ak12srl.it/services/statistiche/homes.html?username=";

        public const string cronologia = "http://192.168.125.97/amorosoNew/servizioapp/cronologia";
        // "https://amorosoconcorsi.ak12srl.it/services/servizioapp/cronologia";

        public const string commenti =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/commenti";

        public const string materie =
            "http://192.168.125.97/amorosoNew/servizioapp/materie";

        public const string domconcorsorandomtotaliNew =
            // "http://192.168.125.97/servizioApp/domandeconcorsorandomtotaliNew.php";
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/domconcorsorandomtotaliNew";

        public const string invioTempi =
            "http://192.168.125.97/amorosoNew/servizioapp/salvaTempo";

        public const string listaMaterieVideo =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/listaMaterieVideo";
        public const string ListaLezioniVideo =
            "https://amorosoconcorsi.ak12srl.it/services/servizioapp/listaLezioniVideo";

        public const string Apprendimento = "http://192.168.125.97/amorosoNew/servizioapp/apprendimento";
        public const string DomandeApprendimento = "http://192.168.125.97/amorosoNew/servizioapp/domande";
        public const string salvataggioStatistiche = "http://192.168.125.97/amorosoNew/servizioapp/salvaSessione";
        public const string speedQuiz = "http://192.168.125.97/amorosoNew/servizioapp/datiSpeedQuiz";
        public const string pacchetti = "http://192.168.125.97/amorosoNew/servizioapp/domandePacchetti";


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