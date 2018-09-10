using Concorsi.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class MainPageModelView : INotifyPropertyChanged
    {
        public ICommand effettuaLogout { protected set; get; }
        private MainPage mainPage;
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
        }
    }
}
