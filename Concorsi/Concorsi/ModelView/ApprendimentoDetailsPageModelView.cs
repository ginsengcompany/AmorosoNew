using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    class ApprendimentoDetailsPageModelView : INotifyPropertyChanged
    {
        private List<Answers> listaDomande = new List<Answers>();
        private Set set = new Set();
        private Timer tempo = new Timer();
        public Boolean responseAlert = false;

        private bool isvisible; //variabile booleana utilizzata per gestire la proprietà IsVisible dell'activity indicator
        private bool isbusy; //variabile booleana utilizzata per gestire la proprietà IsRunning dell'activity indicator
        public bool IsVisible
        {
            get { return isvisible; }
            set
            {
                OnPropertyChanged();
                isvisible = value;
            }
        }
        //Proprietà relativa alla variabile isbusy
        public bool IsBusy
        {
            get { return isbusy; }
            set
            {
                OnPropertyChanged();
                isbusy = value;
            }
        }
        public List<Answers> ListaDomande
        {
            get { return listaDomande; }
            set
            {
                OnPropertyChanged();
                listaDomande = value;
            }
        }
        public async void fineSessione()
        {
            if (!responseAlert)
            {
                tempo.FermaTempo();
                responseAlert = await App.Current.MainPage.DisplayAlert("Attenzione", "sei sicuro di voler terminare la sessione", "SI", "NO");
                if (responseAlert)
                {
                    tempo.invioTempi("tempoApprendimento");
                    App.Current.MainPage.Navigation.PopAsync();
                }
                else
                    tempo.RestartTempo();
            }
     
        }
        public ApprendimentoDetailsPageModelView(Set set, Label lbltempo)
        {
            IsVisible = true;
            IsBusy = true;
            this.set = set;
            tempo.Tempo(true, lbltempo);
            prelevaAnswers();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async void prelevaAnswers()
        {
            REST<Set, Response<List<Answers>>> ricevidomande = new REST<Set, Response<List<Answers>>>();
            var response = await ricevidomande.PostJson(SingletonURL.Instance.getRotte().domande, set);
            if (ricevidomande.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)ricevidomande.responseMessage, ricevidomande.warning, "OK");
            }
            else
            {
                for(int i = 0; i<response.message.Count; i++)
                {

                    for(int y=0; y < response.message[i].Quesiti.Count; y++)
                    {
                        if(response.message[i].Risposta == response.message[i].Quesiti[y].lettera)
                        {
                            response.message[i].Quesiti[y].colore = Color.Green;
                            response.message[i].Quesiti[y].attribute = FontAttributes.Bold;
                        }
                    }
                    if (response.message[i].Quesiti.Count < 7)
                    {
                        for (int count = response.message[i].Quesiti.Count; count < 9; count++)
                        {
                            Quesiti completamento = new Quesiti();
                            completamento.lettera = "z";
                            completamento.quesito = "z";
                            completamento.visible = "false";
                            response.message[i].Quesiti.Add(completamento);
                        }
                    }
                }
                ListaDomande = response.message;
                IsBusy = false;
                IsVisible = false;
            }
        }

    }
}
