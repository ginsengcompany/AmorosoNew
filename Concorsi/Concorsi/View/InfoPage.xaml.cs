using Concorsi.Model;
using Concorsi.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPage : ContentPage
    {   //COSTRUTTORE
        /**
         * Inizializza la mappa che geolocalizzerà l'attività "Amoroso Concorsi" e anche 
         * l'utente che utilizza l'applicazione(Avendo opportunamente attivato il servizio di geolocalizzazione), 
         * e le label di informazioni.
         **/
        public InfoPage()
        {
            InitializeComponent();
            labelLuogo.FormattedText = "Viale Italia n° 53" + "\n" + "San Nicola La Strada (CE)";
            labelBenvenuto.FormattedText = GestioneUtente.Instance.getNomeDiBattesimo;
            LabelInformazioneLog.Text = " Sei connesso con il dispositivo " + GestioneUtente.Instance.getDevDescrizione;

            var tapGestureLuogo = new TapGestureRecognizer();
            tapGestureLuogo.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri(URL.urlLocation));
            };
            labelLuogo.GestureRecognizers.Add(tapGestureLuogo);

            var tapGestureWebSite = new TapGestureRecognizer();
            tapGestureWebSite.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri("https://www.amorosoconcorsi.com/"));
            };
            sitoWeb.GestureRecognizers.Add(tapGestureWebSite);

            /* La variabile tap gesture Phone ci permetterà di cliccare sul numero di telefono e chiamare il negozio in questione*/
            var tapGesturePhone = new TapGestureRecognizer();
            tapGesturePhone.Tapped += (s, e) => {
                Device.OpenUri(new Uri(String.Format("tel:{0}", "08231545081")));
            };
            numeroTelefonoFisso.GestureRecognizers.Add(tapGesturePhone);

            var tapGestureCellulare = new TapGestureRecognizer();
            tapGestureCellulare.Tapped += (s, e) => {
                Device.OpenUri(new Uri(String.Format("tel:{0}", "3925224680")));
            };
            numeroCellulareUno.GestureRecognizers.Add(tapGestureCellulare);

            var tapGestureCellulareDue = new TapGestureRecognizer();
            tapGestureCellulareDue.Tapped += (s, e) => {
                Device.OpenUri(new Uri(String.Format("tel:{0}", "3474856700")));
            };
            numeroCellulareDue.GestureRecognizers.Add(tapGestureCellulareDue);
            /* La variabile tap gesture Facebook ci permetterà di cliccare e navigare sulla pagina facebook del negozio in questione*/
            var tapGestureFacebook = new TapGestureRecognizer();
            tapGestureFacebook.Tapped += (s, e) => {
                Device.OpenUri(new Uri(URL.paginaFacebook));
            };

            facebook.GestureRecognizers.Add(tapGestureFacebook);
            /* La variabile tap gesture mail ci permetterà di cliccare e scrivere una mail al negozio in questione*/
            var tapGestureMail = new TapGestureRecognizer();
            tapGestureMail.Tapped += (s, e) => {
                Device.OpenUri(new Uri(String.Format("mailto:{0}", "cfpcm@hotmail.it")));
            };
            LinkSitoWebAk12();
            indirizzoMail.GestureRecognizers.Add(tapGestureMail);
            /* La variabile positon ci permetterà di indicare sulla mappa l'indirizzo esatto del negozio*/

        }

        public void LinkSitoWebAk12()
        {
            var tapGestureLinkSito = new TapGestureRecognizer();
            tapGestureLinkSito.Tapped += (s, e) => {
                Device.OpenUri(new Uri(URL.sitoAK12));
            };
            logoFooter.GestureRecognizers.Add(tapGestureLinkSito);
        }
    }
}