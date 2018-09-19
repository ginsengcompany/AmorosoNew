using Concorsi.Model;
using Concorsi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class SelezionaTipoSimulazioneModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand VaiSimulazioneAssistita { protected set; get; }
        public ICommand VaiSimulazione { protected set; get; }

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SelezionaTipoSimulazioneModelView(Set set)
        {
            VaiSimulazioneAssistita = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new QuizPage(set,true));
            });

            VaiSimulazione = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new QuizPage(set,false));
            });
        }
    }
}

