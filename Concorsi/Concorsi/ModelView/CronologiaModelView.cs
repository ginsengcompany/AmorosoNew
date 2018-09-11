#region Librerie

using System;
using System.Collections.Generic;
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
        private static List<Sessioni> dataSessione = new List<Sessioni>();
        private DateTime appuntamento=new DateTime(2018,12,4);

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
        public List<Sessioni> DataSessioni
        {
            get { return dataSessione; }
            set
            {
                OnPropertyChanged();
                dataSessione = value;
            }
        }

        public DateTime Appuntamento
        {
            get { return appuntamento; }
            set
            {
                OnPropertyChanged();
                appuntamento = value;
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
            REST<string, List<Sessioni>> connectHistory = new REST<string, List<Sessioni>>();
            List<KeyValuePair<string, string>> valuePairs = new List<KeyValuePair<string, string>>();
            valuePairs.Add(new KeyValuePair<string, string>("username",GestioneUtente.Instance.getUserName.ToUpper()));
            var response = await connectHistory.PostFormURLEncoded(URL.cronologia,valuePairs);
            DataSessioni = response;
        }
  

        #endregion
    }
    public class Meeting
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color Color { get; set; }
        public string RecurrenceRule { get; set; }
    }
}
