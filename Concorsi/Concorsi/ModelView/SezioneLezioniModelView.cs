using Concorsi.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class SezioneLezioniModelView : INotifyPropertyChanged
    {
        private string testoApprendimento, videoLezioni;
        public ICommand VaiPaginaListaMaterieVideolezioniPage { protected set; get; }
        public ICommand VaiPaginaApprendimento { protected set; get; }
        private bool isBusy = false;

        public event PropertyChangedEventHandler PropertyChanged;


        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                OnPropertyChanged();
                isBusy = value;
            }
        }
        public string TestoApprendimento
        {
            get { return testoApprendimento; }
            set
            {
                OnPropertyChanged();
                testoApprendimento = value;
            }
        }

        public string VideoLezioni
        {
            get { return videoLezioni; }
            set
            {
                OnPropertyChanged();
                videoLezioni = value;
            }
        }
        //Consulta le tantissime videolezioni disponibili, tenute dai nostri docenti esperti.
        //Prova a sfogliare tutte le domande della nostra banca dati ed apprendi le relative risposte. La risposta esatta sarà evidenziata in verde.
        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SezioneLezioniModelView(SezioneLezioniPage page)
        {
            VideoLezioni = "Consulta le tantissime videolezioni disponibili, tenute dai nostri docenti esperti.";
            TestoApprendimento = "Prova a sfogliare tutte le domande della nostra banca dati ed apprendi le relative risposte. La risposta esatta sarà evidenziata in verde.";
            VaiPaginaListaMaterieVideolezioniPage = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ListaMaterieVideolezioniPage());
            });
            VaiPaginaApprendimento = new Command(async () =>
            {
                // modificare
                await App.Current.MainPage.Navigation.PushAsync(new ApprendimentoPage());
            });
        }
    }
}
