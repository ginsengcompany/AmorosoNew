using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Concorsi.View;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class SelezionaModalitaQuizPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string testoModalitaClassica, testoModalitaVeloce;
        private bool isBusy = false;
        private bool isEnabled = true;
        public ICommand VaiPaginaModalitaClassica { protected set; get; }
        public ICommand VaiPaginaModalitaVeloce { protected set; get; }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                OnPropertyChanged();
                isEnabled = value;
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

        public string TestoModalitaClassica
        {
            set
            {
                OnPropertyChanged();
                testoModalitaClassica = value;
            }
            get
            {
                return testoModalitaClassica;
            }
        }


        public string TestoModalitaVeloce
        {
            set
            {
                OnPropertyChanged();
                testoModalitaVeloce = value;
            }
            get
            {
                return testoModalitaVeloce;
            }
        }

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SelezionaModalitaQuizPageModelView()
        {
            IsEnabled = true;
            VaiPaginaModalitaClassica = new Command(async () =>
                {
                    if (IsEnabled)
                    {
                        IsEnabled = false;
                        await App.Current.MainPage.Navigation.PushAsync(new ModalitaClassicaPage());
                        IsEnabled = true;
                    }
                });
            VaiPaginaModalitaVeloce = new Command(async () =>
            {
                if (IsEnabled)
                {
                    IsEnabled = false;
                    await App.Current.MainPage.Navigation.PushAsync(new SpeedQuizPageTabbed());
                    IsEnabled = true;
                }
            });



            TestoModalitaClassica = "In questa modalità di esercitazione avrai la possibilità " +
                                    "di eseguire una Simulazione d'esame sia in modalità Classica che in modalità Assistita. ";
            TestoModalitaVeloce= "In questa modalità avrai la possibilità di eseguire un test sfruttando le " +
                                 "domande presenti nell'intera banca dati di Amoroso Concorsi. Selezionando le opzioni in maniera opportuna " +
                                 "avrai la possibilità di definire il tipo di esercitazione da svolgere in maniera mirata." +
                                 "Nota: premendo il tasto back in alto a sinistra le statistiche saranno contate." +
                                 "In questa modalità è previsto una misura cronometrica dei tempi di risposta";
        }
    }
}
