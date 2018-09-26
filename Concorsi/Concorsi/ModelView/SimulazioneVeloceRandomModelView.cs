﻿using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Concorsi.View;
using Xamarin.Forms;
using System.Windows.Input;

namespace Concorsi.ModelView
{
    public class SimulazioneVeloceRandomModelView: INotifyPropertyChanged
    {
        private List<Concorso> listaConcorsi = new List<Concorso>();
        private Concorso concorso = new Concorso();
        private Boolean isEnabled = false;
        private bool isBusy = false;
        public ICommand avviaSimulazione { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        public Boolean IsEnabled
        {
            get { return isEnabled; }
            set
            {
                OnPropertyChanged();
                isEnabled = value;
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


        public SimulazioneVeloceRandomModelView()
        {
            IsEnabled = false;
            avviaSimulazione = new Command(async () =>
            {
                if(concorso!=null)
                    await App.Current.MainPage.Navigation.PushAsync(new QuizPage(concorso));
            });
        RicezioneConcorsiMaterie();
        }

        private async void RicezioneConcorsiMaterie()
        {
            Utente utente = new Utente();
            REST<Utente, Response<List<Concorso>>> connessioneMaterieConcorsi = new REST<Utente, Response<List<Concorso>>>();
            utente.username = GestioneUtente.Instance.getUserName;
            var response = await connessioneMaterieConcorsi.PostJson(SingletonURL.Instance.getRotte().datiSpeedQuiz, utente);
            ListaConcorsi = response.message;

            IsEnabled = false;
        }

        public async void ConcorsoSelezionato(Concorso concorsoSelezionato)
        {
            IsEnabled = true;
            concorso = concorsoSelezionato;
        }

       
    
    }
}

