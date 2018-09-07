using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private bool flaglogin = false;
        private LoginModelView z;
        public LoginPage()
        {
            InitializeComponent();
            z = new LoginModelView(this);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe LoginModelView

		}
	}
}