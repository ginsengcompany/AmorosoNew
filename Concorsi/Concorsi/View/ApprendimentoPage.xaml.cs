using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Concorsi.ModelView;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Questa classe gestisce le domande da presentare all'utente in modalità apprendimento
    /// </summary>
	public partial class ApprendimentoPage : ContentPage
	{
        ApprendimentoModelView modelView;
        public ApprendimentoPage()
        {
            InitializeComponent();
            modelView = new ApprendimentoModelView();
            BindingContext = modelView;
        }
     
    }
}


