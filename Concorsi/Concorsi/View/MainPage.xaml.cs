using Concorsi.Model;
using Concorsi.ModelView;
using Xamarin.Forms;

namespace Concorsi
{
    public partial class MainPage : ContentPage
    {

        private MainPageModelView z;
        public MainPage(Utente utente)
        {
            InitializeComponent();
            z = new MainPageModelView(this, utente);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe LoginModelView

        }
    }
}
