using System;
using Concorsi.Model;
using Concorsi.ModelView;
using Concorsi.Service;
using Xamarin.Forms;
using Xfx;

namespace Concorsi
{
    public partial class MainPage : ContentPage
    {

        private MainPageModelView z;
        public MainPage( Utente utente)
        {
            InitializeComponent();
            labelReminder.Text = "Gentile " + utente.nome + " ti invitiamo ad effettuare l'operazione di Logout " +
                "al termine dell'utilizzo dell'applicazione.";
            labelReminder.Style = Device.Styles.BodyStyle;
            labelReminder.TextColor = Color.FromHex("1b2776");
            z = new MainPageModelView(this, utente);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe LoginModelView
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            XfxCardView card = (XfxCardView) sender;
            card.Equals("Esercitazione");
            var x=card.ClassId;
        }
    }
}
