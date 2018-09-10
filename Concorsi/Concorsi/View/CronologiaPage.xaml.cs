using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CronologiaPage : TabbedPage
    {
        private bool flaglogin = false;
        private CronologiaModelView z;
        public CronologiaPage()
        {
            InitializeComponent();
            z = new CronologiaModelView(this);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe CronologiaModelView
        }
    }
}