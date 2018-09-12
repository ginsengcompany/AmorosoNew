using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class StatisticheModelView : INotifyPropertyChanged
    {
        private DatiStatistica datiStatistica = new DatiStatistica();
        private List<BindingStatistica> datiPieChart = new List<BindingStatistica>();
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> listaMaterie = new List<string>();
        private List<string> listaMaterietemporanea = new List<string>();

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DatiStatistica DatiStatisticaUtente
        {
            get { return datiStatistica; }
            set
            {
                OnPropertyChanged();
                datiStatistica = new DatiStatistica(value);
            }
        }



        public List<BindingStatistica> DatiPieChart
        {
            get { return datiPieChart; }
            set
            {
                OnPropertyChanged();
                datiPieChart = value;
            }
        }

        public List<string> ListaMaterie
        {
            get { return listaMaterie; }
            set
            {
                OnPropertyChanged();
                listaMaterie = value;
            }
        }

        public StatisticheModelView()
        {
            RicezioneMaterie();
            RicezioneStatistiche(null);


        }
        public async void RicezioneStatistiche(string materiaSelezionata)
        {
            Utente utenza = new Utente();
            utenza.username = GestioneUtente.Instance.getUserName;
            utenza.materia = materiaSelezionata;
            REST<Utente, Response<DatiStatistica>> connessioneStatistiche = new REST<Utente, Response<DatiStatistica>>();
            var responseStatistiche = await connessioneStatistiche.PostJson(URL.statisticheURL, utenza);
            if (connessioneStatistiche.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneStatistiche.responseMessage, connessioneStatistiche.warning, "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                DatiStatisticaUtente = responseStatistiche.message;
                DatiPieChart = new List<BindingStatistica>()
                    {
                        new BindingStatistica("Risposte esatte", DatiStatisticaUtente.domandeEsatte),
                        new BindingStatistica("Risposte errate", DatiStatisticaUtente.domandeErrate),
                        new BindingStatistica("Domande senza risposta", DatiStatisticaUtente.domandeNonRisposte)
                    };
            }

        }
        public async void RicezioneMaterie()
        {
            REST<Utente, Response<List<string>>> connessioneMaterie = new REST<Utente, Response<List<string>>>();
            var response = await connessioneMaterie.GetSingleJson(URL.materie);
            if (connessioneMaterie.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneMaterie.responseMessage, connessioneMaterie.warning, "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                foreach (var materia in response.message)
                {
                    listaMaterietemporanea.Add(materia);
                }

                ListaMaterie = listaMaterietemporanea;

            }

        }
    }
}
