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
        List<Grid> gridDomande = new List<Grid>();
        int posizioneCorrente = 0;
        Set set = new Set();
        Timer tempo = new Timer();
        public QuizPage(Set set)
        {
            InitializeComponent();
            this.set = set;
            Title = set.Descrizione;
            GrigliaDomanda.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            GrigliaDomanda.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            ingessoPagina();
        }
        public async Task ingessoPagina()
        {
            tempo.Tempo(true, lblTimer);
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
                posizioneCorrente = 0;
                Title = set.Descrizione + " " + (posizioneCorrente + 1) + "/" + listaDomande.Count;
                await creaGriglia();
            }
        }
        private async Task avanti()
        {
            Title = "Domanda: " + (posizioneCorrente + 1) + "/" + listaDomande.Count;
            if (posizioneCorrente == 0)
                btnIndietro.IsVisible = false;
            else
                btnIndietro.IsVisible = true;
            btnAvanti.Clicked -= ButtonClickedFine;
            btnAvanti.Clicked -= ButtonClickedAvanti;
            if (posizioneCorrente < listaDomande.Count - 1)
            {
                btnAvanti.Text = "Avanti";
                btnAvanti.Clicked += ButtonClickedAvanti;
            }
            else
            {
                btnAvanti.Text = "Fine";
                btnAvanti.Clicked += ButtonClickedFine;

            }
            if (posizioneCorrente < listaDomande.Count - 1)
            {
                GrigliaDomanda.Children.Clear();
                GrigliaDomanda.Children.Add(gridDomande[posizioneCorrente]);
            }
            else
            {
               await DisplayAlert("fine", "finone", "ok");
            }
               
        }

        private async Task creaGriglia()
        {
            foreach(var quesito in listaDomande)
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
                quesiti = await gridQuesiti(quesito.Quesiti, quesito.Risposta);
                grid.Children.Add(domanda, 0, 0);
                grid.Children.Add(quesiti, 0, 1);
                gridDomande.Add(grid);
            }

            GrigliaDomanda.Children.Clear();
            GrigliaDomanda.Children.Add(gridDomande[posizioneCorrente]);
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

                Label detalies = new Label
                {
                    Text = quesito.quesito,
                    TextColor = Color.Black,
                };
                lettera.Clicked += async delegate (object sender, EventArgs e)
                {
                    lettera.BackgroundColor = Color.Red;
                    detalies.TextColor = Color.Red;
                    bool flag = false;
                    foreach(var y in grid.Children)
                    {
                        if (y.GetType() == detalies.GetType())
                            if (flag)
                            {
                            flag = false;
                            var a = y as Label;
                            a.TextColor = Color.Green;
                            }
                        if (y.GetType() == lettera.GetType())
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
                    posizioneCorrente++;
                    await avanti();
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
    }
}