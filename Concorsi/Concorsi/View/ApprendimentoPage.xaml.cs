using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Concorsi.ModelView;
using Concorsi.Model;

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

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var a = sender as Picker;
            var b = a.SelectedItem as PianiFormativi;
            modelView.PianoSelezionato(b);

        }

	    private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var a = e.Item as Set;
	        Navigation.PushAsync(new ApprendimentoDetailsPage(a));
        }
	}
}


