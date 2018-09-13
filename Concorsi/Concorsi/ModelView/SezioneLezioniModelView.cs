using Concorsi.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    class SezioneLezioniModelView : INotifyPropertyChanged
    {
        public ICommand VaiPaginaListaMaterieVideolezioniPage { protected set; get; }
        public ICommand VaiPaginaApprendimento { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SezioneLezioniModelView(SezioneLezioniPage page)
        {
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
