﻿using Concorsi.Model;
using Concorsi.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class MainPageModelView : INotifyPropertyChanged
    {
        private string testoEsercitazione, testoRisultati, testoStatistiche, testoLezioni;
        public ICommand effettuaLogout { protected set; get; }
        public ICommand visualizzaInfo { protected set; get; }
        public ICommand VaiPaginaCronologiaStatistiche { protected set; get; }
        public ICommand VaiPaginaLezioni { protected set; get; }
        public ICommand VaiPaginaCronologia { protected set; get; }
        public ICommand VaiPaginaSelezioneModalitaQuiz { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public string TestoEsercitazione
        {
            set
            {
                OnPropertyChanged();
                testoEsercitazione = value;
            }
            get
            {
                return testoEsercitazione;
            }

        }


        public string TestoRisultati
        {
            set
            {
                OnPropertyChanged();
                testoRisultati = value;
            }
            get
            {
                return testoRisultati;
            }
        }
        public string TestoStatistiche
        {
            set
            {
                OnPropertyChanged();
                testoStatistiche = value;
            }
            get
            {
                return testoStatistiche;
            }
        }
        public string TestoLezioni
        {
            set
            {
                OnPropertyChanged();
                testoLezioni = value;
            }
            get
            {
                return testoLezioni;
            }
        }

        public MainPageModelView(MainPage mainPage, Utente utente)
        {
            effettuaLogout = new Command(async () =>
            {
                await utente.Logout();
            });

            visualizzaInfo = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new InfoPage());
            });

            VaiPaginaCronologiaStatistiche = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new Statistiche());
            });

            VaiPaginaLezioni = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new SezioneLezioniPage());// era listamaterie videolezioni
            });

            VaiPaginaCronologia = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new CronologiaPage());
            });

            VaiPaginaSelezioneModalitaQuiz = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new SelezionaModalitaQuizPage());
            });

            TestoEsercitazione = "Accedi alla sezione dedicata alle Esercitazioni. Potrai cimentarti nell'" +
                "esecuzione della Simulazione d'esame in Modalità Classica o in Modalità Assistita!"; 
            TestoRisultati = "Visualizza i risultati ottenuti durante le esercitazioni e valuta la tua preparazione.";
            TestoStatistiche = "Vuoi un un quadro completo sulla tua preparazione per ogni materia? Accedi quì per " +
                "valutare il tuo tasso di successo!";
            TestoLezioni = "Migliora la tua preparazione grazie alle videolezioni " +
                "tenute dai nostri docenti esperti ed accedendo alla nostra vasta banca dati dedicata al tuo piano di studi.";
        }
    }
}
