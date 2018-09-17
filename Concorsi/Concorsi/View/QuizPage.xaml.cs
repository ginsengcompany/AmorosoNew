using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        List<Answers> listaDomande = new List<Answers>();
        int posizioneCorrente = 0;
        Set set = new Set();
        public QuizPage(Set set)
        {
            InitializeComponent();
            this.set = set;
            ingessoPagina();
        }
        public async Task ingessoPagina()
        {
            await connessioneDomande();
        }
        private async Task connessioneDomande()
        {
            REST<Set, Response<List<Answers>>> connessioneDomande = new REST<Set, Response<List<Answers>>>();
            var respone = await connessioneDomande.PostJson(URL.DomandeApprendimento, set);
            if (connessioneDomande.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneDomande.responseMessage, connessioneDomande.warning, "OK");
            }
            else
            {
                listaDomande = respone.message;
                await creaGriglia();
            }
        }
        private async Task creaGriglia()
        {
            GrigliaDomanda.Children.Clear();
            GrigliaDomanda.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            Label domanda = new Label
            {
                Text = listaDomande[posizioneCorrente].Domanda,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold
            };
            Grid quesiti = new Grid();
            quesiti = await gridQuesiti(listaDomande[posizioneCorrente].Quesiti, listaDomande[posizioneCorrente].Risposta);
            GrigliaDomanda.Children.Add(domanda, 0, 0);
            GrigliaDomanda.Children.Add(quesiti, 0, 1);
        }
        private async Task<Grid> gridQuesiti(List<Quesiti> quesiti, String risposta)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            int i = 0;
            foreach (var quesito in quesiti)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                Button lettera = new Button
                {
                    Text = quesito.lettera,
                    TextColor = Color.Black,
                };
                lettera.Clicked += Lettera_Clicked;
                Label detalies = new Label
                {
                    Text = quesito.quesito,
                    TextColor = Color.Black,
                };
                if (quesito.lettera == risposta)
                {
                    detalies.TextColor = Color.Green;
                    detalies.FontAttributes = FontAttributes.Bold;
                    lettera.FontAttributes = FontAttributes.Bold;
                }
                grid.Children.Add(lettera, 0, i);
                grid.Children.Add(detalies, 1, i);
                i++;
            }
            return grid;
        }

        private async void Lettera_Clicked(object sender, EventArgs e)
        {
            posizioneCorrente++;
            await creaGriglia();
        }
    }
}