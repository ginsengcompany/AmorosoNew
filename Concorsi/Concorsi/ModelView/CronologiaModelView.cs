#region Librerie

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Concorsi.Model;
using Concorsi.Service;
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
        private List<Sessioni> dateDisponibili = new List<Sessioni>();
        private List<Sessioni> sessioneDisponibile = new List<Sessioni>();

        #endregion

        #region Proprietà

        public ICommand effettuaLogin { protected set; get; }

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

        public List<Sessioni>DateDisponibili
        {
            get{return dateDisponibili;}
            set
            {
                OnPropertyChanged();
                dateDisponibili = value;
            }
        }
        public List<Sessioni> SessioneDisponibile
        {
            get
            {
                return sessioneDisponibile;
            }
            set
            {
                OnPropertyChanged();
                sessioneDisponibile = value;
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
            connessioneCronologia();
        }

        #endregion

        #region Metodi

        public async Task connessioneCronologia()
        {
            REST<Utente,Response> connectHistory = new REST<Utente, Response>();
            Utente utenteUsername = new Utente();
            utenteUsername.username = GestioneUtente.Instance.getUserName.ToUpper();
            var response = await connectHistory.PostJson(URL.cronologia, utenteUsername);
            /*List<KeyValuePair<string, string>> valuePairs = new List<KeyValuePair<string, string>>();
            valuePairs.Add(new KeyValuePair<string, string>("username",GestioneUtente.Instance.getUserName.ToUpper()));
            var response = await connectHistory.PostFormURLEncoded(URL.cronologia,valuePairs);*/
            DateDisponibili = response;
        }
  

        #endregion
    }
}
