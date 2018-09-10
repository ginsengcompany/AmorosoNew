#region Librerie

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Concorsi.Model;
using Concorsi.View;

#endregion


namespace Concorsi.ModelView
{
    public class CronologiaModelView : INotifyPropertyChanged
    {
        #region DichiarazioneVariabili

        public event PropertyChangedEventHandler PropertyChanged; //evento che implementa l'interfaccia INotifyPropertyChanged
        private bool isenabled;//booleano utilizzato per abilitare o meno un elemento nello xaml
        private CronologiaPage cronologiaPage;//Oggetto del tipo della pagina Login
        public static string risultatoRispostaCronologia;
        public static List<Sessioni> SessionedataSelezionata = new List<Sessioni>();

        #endregion

        #region Proprietà

        //Command utilizzato per il tentativo di accesso ai servizi da parte dell'utente
        public ICommand effettuaLogin { protected set; get; }
        //Command utilizzato per mostrare la password

        //proprietà relativa al campo isEnabled
        public bool IsEnabled
        {
            get { return isenabled; }
            set
            {
                OnPropertyChanged();
                isenabled = value;
            }
        }

        #endregion

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Costruttore

        // Costruttore del ModelView che inizializza le variabili fondamentali per il corretto funzionamento della pagina di login (sia Android che IOS).
        public CronologiaModelView(CronologiaPage cronologiaPage)
        {
            
        }

        #endregion

        #region Metodi


        public void modificaFlag(bool flag)
        {

        }

        #endregion
    }
}
