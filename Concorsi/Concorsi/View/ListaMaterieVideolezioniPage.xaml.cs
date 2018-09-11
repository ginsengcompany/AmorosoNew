using Concorsi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaMaterieVideolezioniPage : ContentPage
    {
        List<MaterieVideo> listaMaterieVideo = new List<MaterieVideo>();

        public ListaMaterieVideolezioniPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ConnessioneMaterie();
        }
        public async Task ConnessioneMaterie()
        {
            var client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync(URL.listaMaterieVideo);
                var resultcontent = await result.Content.ReadAsStringAsync();
                listaMaterieVideo = JsonConvert.DeserializeObject<List<MaterieVideo>>(resultcontent);
                listaMaterie.ItemsSource = listaMaterieVideo;
            }
            catch
            {
                await DisplayAlert("Errore", "Errore nel prelievo dei dati!", "OK");
            }
        }

        private async void listaMaterie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var elementoTappato = e.Item as MaterieVideo;
            await Navigation.PushAsync(new ListaArgomentiVideolezioniPage(elementoTappato.Materia));
        }
    }
}