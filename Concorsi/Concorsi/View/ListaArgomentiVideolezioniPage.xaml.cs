using Concorsi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaArgomentiVideolezioniPage : ContentPage
	{
        List<VideoLezioniNuovo> listaVideoLezioni = new List<VideoLezioniNuovo>();
        string materia;
        public ListaArgomentiVideolezioniPage(string materiaVideo)
        {
            InitializeComponent();
            materia = materiaVideo;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ConnessioneMaterie();
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
        public async Task ConnessioneMaterie()
        {
            var client = new HttpClient();
            try
            {
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("materia", materia));
                var content = new FormUrlEncodedContent(values);
                var result = await client.PostAsync(URL.ListaLezioniVideo, content);
                var resultcontent = await result.Content.ReadAsStringAsync();
                listaVideoLezioni = JsonConvert.DeserializeObject<List<VideoLezioniNuovo>>(resultcontent);
                ListaVideo.ItemsSource = listaVideoLezioni;
            }
            catch
            {
                await DisplayAlert("Errore", "errore nel prelievo dei dati!", "OK");
            }
        }

        private async void ListaVideo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var elementoTappato = e.Item as VideoLezioniNuovo;
            await Navigation.PushAsync(new VideolezioniPage(elementoTappato.VideoSource));
        }
    }
    public class VideoLezioniNuovo
    {
        public string Nome { set; get; }
        public string VideoSource { set; get; }
        public string Descrizione { set; get; }
        public string sottoCategoria { set; get; }
        public string Materia { set; get; }
    }
}