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
       invioQuiz listaDomande = new invioQuiz();
        List<Grid> gridDomande = new List<Grid>();
        int posizioneCorrente = 0;
        Set set = new Set();
        Timer tempototale = new Timer();
        Timer tempodomanda = new Timer();
        Boolean simulazioneAssistita;
        public QuizPage(Set set, Boolean simulazioneAssistita)
        {
            InitializeComponent();
            this.set = set;
            Title = set.Descrizione;
            GrigliaDomanda.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            this.simulazioneAssistita = simulazioneAssistita;
            ingessoPagina();
        }
        public async Task ingessoPagina()
        {
            tempototale.Tempo(true, lblTimer);
            tempodomanda.Tempo(true);
            await connessioneDomande();
        }
        private async Task connessioneDomande()
        {
            REST<Set, Response<List<Quiz>>> connessioneDomande = new REST<Set, Response<List<Quiz>>>();
            var respone = await connessioneDomande.PostJson(URL.DomandeApprendimento, set);
            if (connessioneDomande.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneDomande.responseMessage, connessioneDomande.warning, "OK");
            }
            else
            {
                listaDomande.quiz = respone.message;
                posizioneCorrente = 0;
                Title = set.Descrizione + " " + (posizioneCorrente + 1) + "/" + listaDomande.quiz.Count;
                listaDomande.nome_set = set.nome_set;
                listaDomande.numeroDomande = respone.message.Count;
                listaDomande.data_sessione = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
                listaDomande.ora_sessione = String.Format("{0:HH:mm}", DateTime.Now);
                await creaGriglia();
            }
        }
        private async Task avanti()
        {
            tempodomanda.ResetTempo();
            tempodomanda.RestartTempo();
            Title = "Domanda: " + (posizioneCorrente + 1) + "/" + listaDomande.quiz.Count;
            if (posizioneCorrente == 0)
                btnIndietro.IsVisible = false;
            else
                btnIndietro.IsVisible = true;
            btnAvanti.Clicked -= ButtonClickedFine;
            btnAvanti.Clicked -= ButtonClickedAvanti;
            if (posizioneCorrente < listaDomande.quiz.Count - 1)
            {
                btnAvanti.Text = "Avanti";
                btnAvanti.Clicked += ButtonClickedAvanti;
            }
            else
            {
                btnAvanti.Text = "Fine";
                btnAvanti.Clicked += ButtonClickedFine;

            }
            if (posizioneCorrente < listaDomande.quiz.Count - 1)
            {
                GrigliaDomanda.Children.Clear();
                GrigliaDomanda.Children.Add(gridDomande[posizioneCorrente]);
            }
            else
            {
                tempototale.FermaTempo();
                listaDomande.tempoTotale = tempototale.tempoTotale;
                listaDomande.risposteNonDate = listaDomande.numeroDomande - listaDomande.risposteGiuste - listaDomande.risposteSbagliate;
                await Navigation.PushAsync(new RisultatoQuizPage(listaDomande));
            }
                
        }

        private async Task creaGriglia()
        {
            foreach(var quesito in listaDomande.quiz)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                Label domanda = new Label
                {
                    Text = quesito.Domanda,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold
                };
                Grid quesiti = new Grid();
                quesiti = await gridQuesiti(quesito.Quesiti, quesito.Risposta,quesito.tempo_risposta);
                grid.Children.Add(domanda, 0, 0);
                grid.Children.Add(quesiti, 0, 1);
                if (quesito.tipo == "pdf")
                {
                    Button pdf = new Button
                    {
                        Text = "apri documento",
                        TextColor = Color.Black,
                    };
                    pdf.Clicked += async delegate (object sender, EventArgs e)
                    {
                        Device.OpenUri(new Uri(URL.urlBase + quesito.link));
                    };
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    grid.Children.Add(pdf, 0, 2);
                }
                else if (quesito.tipo == "img")
                {
                    var urlRisorsa = URL.urlBase + quesito.link;
                    var urlProva = new System.Uri(urlRisorsa);
                    Task<ImageSource> result = Task<ImageSource>.Factory.StartNew(() => ImageSource.FromUri(urlProva));
                    Image img = new Image();
                    img.Source = await result;
                    img.HorizontalOptions = LayoutOptions.Center;
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    grid.Children.Add(img, 0, 2);
                }
                gridDomande.Add(grid);
            }

            GrigliaDomanda.Children.Clear();
            GrigliaDomanda.Children.Add(gridDomande[posizioneCorrente]);
        }
        private async Task<Grid> gridQuesiti(List<Quesiti> quesiti, String risposta,String tempoRisposta)
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

                Label detalies = new Label
                {
                    Text = quesito.quesito,
                    TextColor = Color.Black,
                };
                lettera.Clicked += async delegate (object sender, EventArgs e)
                {
                    tempoRisposta = tempodomanda.tempoTotale;
                    
                    if (lettera.Text == risposta)
                        listaDomande.risposteGiuste = listaDomande.risposteGiuste + 1;
                    else
                        listaDomande.risposteSbagliate = listaDomande.risposteSbagliate + 1;
                    if (simulazioneAssistita)
                    {
                        lettera.BackgroundColor = Color.Red;
                        detalies.TextColor = Color.Red;
                        await SimulazioneAssistitaClick(grid,risposta);
                    }
                    else
                    {
                        lettera.BackgroundColor = Color.DarkBlue;
                        detalies.FontAttributes = FontAttributes.Bold
                        posizioneCorrente++;
                        await avanti();
                    }
                };               
                grid.Children.Add(lettera, 0, i);
                grid.Children.Add(detalies, 1, i);
                i++;
            }
            return grid;
        }

        private async void Lettera_Clicked(object sender, EventArgs e)
        {
            
            posizioneCorrente++;
            await avanti();
        }
        private async void ButtonClickedIndietro(object sender, EventArgs e)
        {
            posizioneCorrente--;
            await avanti();
        }
        private async void ButtonClickedAvanti(object sender, EventArgs e)
        {
            posizioneCorrente++;
            await avanti();
        }
        private async void ButtonClickedFine(object sender, EventArgs e)
        {
           await DisplayAlert("FINE", "FINEEEEEE", "OK");
        }

        private async Task SimulazioneAssistitaClick(Grid grid,String risposta)
        {
            Label label = new Label();
            Button button = new Button();
            bool flag = false;
            foreach (var y in grid.Children)
            {
                if (y.GetType() == label.GetType())
                    if (flag)
                    {
                        flag = false;
                        var a = y as Label;
                        a.TextColor = Color.Green;
                    }
                if (y.GetType() == button.GetType())
                {
                    y.IsEnabled = false;
                    var a = y as Button;
                    if (a.Text == risposta)
                    {
                        flag = true;
                        a.BackgroundColor = Color.Green;
                    }
                }
            }
        }

    }
}