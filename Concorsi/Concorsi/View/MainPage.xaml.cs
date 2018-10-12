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
            z = new MainPageModelView(this, utente);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe LoginModelView
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            XfxCardView card = (XfxCardView) sender;
            var x=card.ClassId;
           await z.SceltaCard(x);
        }
    }
}
