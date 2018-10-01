﻿using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Concorsi.View;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;

namespace Concorsi.ModelView
{
    public class SimulazioneVeloceSequenzialeModelView: INotifyPropertyChanged
    {
        private List<Concorso> listaConcorsi = new List<Concorso>();
        private List<Materie> listaMaterie = new List<Materie>();
        private List<Pacchetti>pacchetti = new List<Pacchetti>();
        private bool isBusy = false;
        private SpeedQuiz quiz = new SpeedQuiz();
        int numeroDomande = 0;
        private bool isEnabledList = true;

        private bool isEnabled, isEnabledMateria,visiblePacchetti = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool IsEnabledList
        {
            get { return isEnabledList; }
            set
            {
                OnPropertyChanged();
                isEnabledList = value;
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                OnPropertyChanged();
                isBusy = value;
            }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                OnPropertyChanged();
                isEnabled = value;
            }
        }

        public bool IsEnabledMateria
        {
            get { return isEnabledMateria; }
            set
            {
                OnPropertyChanged();
                isEnabledMateria = value;
            }
        }


        public List<Concorso> ListaConcorsi
        {
            get { return listaConcorsi; }
            set
            {
                OnPropertyChanged();
                listaConcorsi = value;
            }
        }

        public List<Pacchetti> Pacchetti
        {
            get { return pacchetti; }
            set
            {
                OnPropertyChanged();
                pacchetti = value;
            }
        }

        public List<Materie> ListaMaterie
        {
            get { return listaMaterie; }
            set
            {
                OnPropertyChanged();
                listaMaterie = value;
            }
        }

        public bool VisibleListaPacchetti
        {
            get { return visiblePacchetti; }
            set
            {
                OnPropertyChanged();
                visiblePacchetti = value;
            }
        }

        private async void RicezioneConcorsiMaterie()
        {
            Utente utente = new Utente();
            REST<Utente, Response<List<Concorso>>> connessioneMaterieConcorsi = new REST<Utente, Response<List<Concorso>>>();
           // utente.username = GestioneUtente.Instance.getUserName;
            utente.username =GestioneUtente.Instance.getUserName;
            var response = await connessioneMaterieConcorsi.PostJson(SingletonURL.Instance.getRotte().datiSpeedQuiz, utente);
            if (connessioneMaterieConcorsi.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneMaterieConcorsi.responseMessage, connessioneMaterieConcorsi.warning, "OK");
            }
            else
            {
                ListaConcorsi = response.message;

            }

        }

        public void RicezioneConcorso(Concorso concorsoSelezionato)
        {
            IsEnabledList = true;
            IsEnabledMateria = false;
            Pacchetti = new List<Pacchetti>();
            IsEnabled = true;
            if (ListaMaterie.Count != 0)
                ListaMaterie = new List<Materie>();
            quiz.concorso = concorsoSelezionato.id_concorso;
            quiz.valoreGiusta = Int32.Parse(concorsoSelezionato.rispostaesatta);
            quiz.valoreSbagliata = Int32.Parse(concorsoSelezionato.rispostaerrata);
            ListaMaterie = concorsoSelezionato.materie;
        }


        public SimulazioneVeloceSequenzialeModelView()
        {
            RicezioneConcorsiMaterie();
        }

        public async void PacchettoSelezionato(int pacchetto)
        {

            switch (pacchetto)
            {
                case 0:
                    numeroDomande = 20;
                    break;
                case 1:
                    numeroDomande = 40;
                    break;
                case 2:
                    numeroDomande = 60;
                    break;
                case 3:
                    numeroDomande = 80;
                    break;
                case 4:
                    numeroDomande = 100;
                    break;
            }

            IsBusy = true;
           RiempimentoListaPacchetti();
        }

        public async void RiempimentoListaPacchetti()
        {
            REST<SpeedQuiz, Response<List<Pacchetti>>> connessionePacchetti = new REST<SpeedQuiz, Response<List<Pacchetti>>>();
            quiz.intervallo = numeroDomande;
            var response = await connessionePacchetti.PostJson(SingletonURL.Instance.getRotte().domandePacchetti, quiz);
            if (connessionePacchetti.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessionePacchetti.responseMessage, connessionePacchetti.warning, "OK");
            }
            else
            {
                Pacchetti = response.message;
                IsBusy = false;
                VisibleListaPacchetti = true;
            }
            

        }

        public async void MateriaSelezionata(Materie materiaSelezionata)
        {
            IsEnabledMateria = true;
            Pacchetti=new List<Pacchetti>();
            quiz.materia = materiaSelezionata.materia;
        }

        public async Task VaiPaginaQuiz(Pacchetti pacchettoSelezionato)
        {

            IsEnabledList = false;
            await  App.Current.MainPage.Navigation.PushAsync(new QuizPage(quiz, pacchettoSelezionato.domande));
            IsEnabledList = true;
        }
    }
}
