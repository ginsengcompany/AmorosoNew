﻿using Concorsi.Model;
using Concorsi.Service;
using Concorsi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Concorsi.ModelView
{
    public class ApprendimentoModelView: INotifyPropertyChanged
    {
        private List<PianiFormativi> piani = new List<PianiFormativi>();
        private List<Set> listaSetDomande = new List<Set>();

        private bool isBusy = false;
        private bool isVisible = false;
        private bool isEnabled = true;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<PianiFormativi> Piani
        {
            get { return piani; }
            set {
                OnPropertyChanged();
                piani = value;
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
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                OnPropertyChanged();
                isVisible = value;
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
        public List<Set> ListaSetDomande
        {
            get { return listaSetDomande; }
            set
            {
                OnPropertyChanged();
                listaSetDomande = value;
            }
        }
        public ApprendimentoModelView()
        {
            IsEnabled = true;
            IsBusy = true;
            IsVisible = false;
            RicezionePianiFormativi();
        }

        public async void RicezionePianiFormativi()
        {
            Utente utente = new Utente();
            utente.username = GestioneUtente.Instance.getUserName;
            REST<Utente, Response<List<PianiFormativi>>> connessionePianiFormativi = new REST<Utente, Response<List<PianiFormativi>>>();
            var response = await connessionePianiFormativi.PostJson(SingletonURL.Instance.getRotte().apprendimento, utente);
            if (connessionePianiFormativi.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessionePianiFormativi.responseMessage, connessionePianiFormativi.warning, "OK");
            }
            else
            {
               Piani = response.message;
                IsBusy = false;
                IsVisible = true;
            }
        }

        public async void PianoSelezionato(PianiFormativi pianoSelezionato)
        {
            ListaSetDomande = pianoSelezionato.set;
        }
        public async Task ApprendimentoDettagli(Set set)
        {
            IsEnabled = false;
            App.Current.MainPage.Navigation.PushAsync(new ApprendimentoDetailsPage(set));
            IsEnabled = true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
