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
        private bool isEnabled = true;
        public ICommand VaiSimulazioneAssistita { protected set; get; }
        public ICommand VaiSimulazione { protected set; get; }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                OnPropertyChanged();
                IsEnabled = value;
            }
        }
        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SelezionaTipoSimulazioneModelView(Set set)
        {
            IsEnabled = true;
            VaiSimulazioneAssistita = new Command(async () =>
            {
                if (isEnabled)
                {
                    isEnabled = false;
                    await App.Current.MainPage.Navigation.PushAsync(new QuizPage(set, true));
                    IsEnabled = true;
                }
            });

            VaiSimulazione = new Command(async () =>
            {
                if (isEnabled)
                {
                    isEnabled = false;
                    await App.Current.MainPage.Navigation.PushAsync(new QuizPage(set, false));
                    IsEnabled = true;
                }
            });
        }
    }
}

