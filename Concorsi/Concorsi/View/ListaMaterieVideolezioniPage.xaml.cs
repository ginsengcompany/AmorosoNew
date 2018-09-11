using Concorsi.Model;
using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaMaterieVideolezioniPage : ContentPage
    {
        public ListaMaterieVideolezioniModelView listaMaterieVideolezioni;

        public ListaMaterieVideolezioniPage()
        {
            InitializeComponent();
            listaMaterieVideolezioni = new ListaMaterieVideolezioniModelView();
            BindingContext = listaMaterieVideolezioni;
        }

        private async void listaMaterie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var elementoTappato = e.Item as MaterieVideo;
            await Navigation.PushAsync(new ListaArgomentiVideolezioniPage(elementoTappato.Materia));
        }
    }
}