using Concorsi.Model;
using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaArgomentiVideolezioniPage : ContentPage
	{
        public ListaArgomentiVideolezioniModelView listaArgomentiVideolezioni;

        public ListaArgomentiVideolezioniPage(string materieSelezionate)
        {
            InitializeComponent();
            listaArgomentiVideolezioni = new ListaArgomentiVideolezioniModelView(materieSelezionate);
            BindingContext = listaArgomentiVideolezioni;
        }

        private async void ListaVideo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var elementoTappato = e.Item as VideoLezioni;
            await listaArgomentiVideolezioni.selezioneVideo(elementoTappato);
        }
    }
}