using Concorsi.Model;
using Concorsi.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class MainPageModelView : INotifyPropertyChanged
    {
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
        }
    }
}
