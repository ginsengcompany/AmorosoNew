﻿using Concorsi.Model;
using Concorsi.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xfx;

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

        protected override bool OnBackButtonPressed()
        {
            FineQuiz();
            return true;
        }

        public async void FineQuiz()
        {
            var responseAlert = await DisplayAlert("Attenzione", "sei sicuro di voler terminare il test?", "SI", "NO");
            if (responseAlert)
            {
                REST<invioQuiz, Response<string>> connessioneInvioStatistiche = new REST<invioQuiz, Response<string>>();
                tempototale.FermaTempo();
                listaDomande.tempoTotale = tempototale.tempoTotale;
                listaDomande.risposteNonDate = listaDomande.numeroDomande - listaDomande.risposteGiuste - listaDomande.risposteSbagliate;
                string json = JsonConvert.SerializeObject(listaDomande);
                var response = await connessioneInvioStatistiche.PostJson(URL.salvataggioStatistiche, listaDomande);
                await Navigation.PushAsync(new RisultatoQuizPage(listaDomande));
                Navigation.RemovePage(this);
            }
        }


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
                listaDomande.username = GestioneUtente.Instance.getUserName;
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
                 FineQuiz();
            }
                
        }
        private async Task creaGriglia()
        {
            int index = 0;
            foreach(var quesito in listaDomande.quiz)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                XfxCardView cardDomanda = new XfxCardView
                {
                    CornerRadius = 10,
                    Elevation = 10,
                    
                };
                Label domanda = new Label
                {
                    Text = quesito.Domanda,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold
                };
                Grid quesiti = new Grid();
                quesiti = await gridQuesiti(quesito.Quesiti, quesito.Risposta, index);
                grid.Children.Add(domanda, 0, 0);
                grid.Children.Add(quesiti, 0, 1);
                if (quesito.tipo == "pdf")
                {
                    Button pdf = new Button
                    {
                        Text = "apri documento",
                        WidthRequest = 20,
                        HeightRequest = 15,
                        BackgroundColor = Color.FromHex("#275B8C"),
                        TextColor = Color.White
                    
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
                index++;
            }

            GrigliaDomanda.Children.Clear();
            GrigliaDomanda.Children.Add(gridDomande[posizioneCorrente]);
        }
        private async Task<Grid> gridQuesiti(List<Quesiti> quesiti, String risposta, int y)
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
                    WidthRequest = 60,
                    HeightRequest = 40,
                    BackgroundColor = Color.FromHex("#275B8C"),
                    TextColor = Color.White
                };

                Label detalies = new Label
                {
                    Text = quesito.quesito,
                    TextColor = Color.Black,
                };
                lettera.Clicked += async delegate (object sender, EventArgs e)
                {
                    listaDomande.quiz[y].tempo_risposta = tempodomanda.tempoTotale;
                    listaDomande.quiz[y].risposta_utente = quesito.quesito;
                    if (lettera.Text == risposta)
                    {
                        listaDomande.risposteGiuste = listaDomande.risposteGiuste + 1;
                        listaDomande.quiz[y].risposta_esatta  = "1";
                    }
                    else
                    {
                        listaDomande.quiz[y].risposta_esatta = "0";
                        listaDomande.risposteSbagliate = listaDomande.risposteSbagliate + 1;
                    }
                    if (simulazioneAssistita)
                    {
                        lettera.BackgroundColor = Color.Red;
                        detalies.TextColor = Color.Red;
                        await SimulazioneAssistitaClick(grid,risposta);
                    }
                    else
                    {
                        lettera.BackgroundColor = Color.DarkBlue;
                        detalies.FontAttributes = FontAttributes.Bold;
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

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            FineQuiz();
        }
    }
}