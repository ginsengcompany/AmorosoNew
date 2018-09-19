#region Librerie

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Concorsi.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Concorsi.Service;
using Concorsi.View;

#endregion

/*
 * Questa classe è il ModelView delle pagine Login e LoginIOS. La classe gestisce tutte le informazioni inserite e prelevate da remoto riguardanti l'utenza del cliente.
 * La classe concede l'accesso all'utente solo se le informazioni da lui inserite sono corrette. 
 */

namespace Concorsi.ModelView
{
    public class LoginModelView : INotifyPropertyChanged
    {

        #region DichiarazioneVariabili

        private bool flagLogin = false;//Booleano che andrà a true quando l'utente avrà effettuato la login
        public event PropertyChangedEventHandler PropertyChanged; //evento che implementa l'interfaccia INotifyPropertyChanged
        private string nameErrorTextPassword;//Variabile utilizzata nel caso in cui ci sia un errore nel campo password o sia vuoto
        private Utente utente;
        private bool isbusy; //variabile booleana utilizzata per gestire la proprietà IsRunning dell'activity indicator
        private string nameErrorText;//Variabile utilizzata nel caso in cui ci sia un errore nel campo nome o sia vuoto
        private bool showPassword = true;//Booleano utilizzato per mostrare o meno la password
        private bool isvisible; //variabile booleana utilizzata per gestire la proprietà IsVisible dell'activity indicator
        private bool loginisvisible;//Booleano utilizzato per mostrare o meno alcuni elementi nello xaml
        private bool isenabled;//booleano utilizzato per abilitare o meno un elemento nello xaml
        private LoginPage loginPage;//Oggetto del tipo della pagina Login
        private List<Header> listaHeader = new List<Header>();//Lista di header
        private ImageSource showPasswordImage = "eye.png";//Sorgente da cui andremo a prendere l'immagine dell'occhio per mostrare la password

        #endregion

        #region Proprietà

        //Proprietà per il campo ShowPassword
        public ImageSource ShowPasswordImage
        {
            get { return showPasswordImage; }
            set
            {
                OnPropertyChanged();
                showPasswordImage = value;
            }
        }

        //Command utilizzato per il tentativo di accesso ai servizi da parte dell'utente
        public ICommand effettuaLogin { protected set; get; }
        //Command utilizzato per mostrare la password
        public ICommand showPass { protected set; get; }


        //proprietà relativa al campo loginVisible
        public bool LoginIsVisible
        {
            get { return loginisvisible; }
            set
            {
                OnPropertyChanged();
                loginisvisible = value;
            }
        }

        //proprietà relativa al campo ShowPassword
        public bool ShowPassword
        {
            get { return showPassword; }
            set
            {
                OnPropertyChanged();
                showPassword = value;
            }
        }

        //Proprietà relativa alla variabile isvisible
        public bool IsVisible
        {
            get { return isvisible; }
            set
            {
                OnPropertyChanged();
                isvisible = value;
            }
        }

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

        //Proprietà relativa alla variabile isbusy
        public bool IsBusy
        {
            get { return isbusy; }
            set
            {
                OnPropertyChanged();
                isbusy = value;
            }
        }

        //proprietà relativa al campo NameErrorTextPassword
        public string NameErrorTextPassword
        {
            get { return nameErrorTextPassword; }
            set
            {
                OnPropertyChanged();
                nameErrorTextPassword = value;
            }
        }

        //Proprietà che definisce l' Username di chi effettua l'accesso
        public string Username
        {
            get { return GestioneUtente.Instance.getUserName; }
            set
            {
                OnPropertyChanged();
                GestioneUtente.Instance.getUserName = value;
            }
        }

        //Proprietà che definisce la password di chi effettua il login
        public string passWord
        {
            get { return GestioneUtente.Instance.getPassword; }
            set
            {
                OnPropertyChanged();
                GestioneUtente.Instance.getPassword = value;
            }
        }

        //Proprietà relativa al campo nome
        public string NameErrorText
        {
            get { return nameErrorText; }
            set
            {
                OnPropertyChanged();
                nameErrorText = value;
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
        public LoginModelView(LoginPage loginPage)
        {
            utente = new Utente();
            LoginIsVisible = true;
            this.loginPage = loginPage;
            IsEnabled = true;
            IsVisible = false; //L'activity indicator non è visibile
            IsBusy = false; //L'activity indicator non si trova nello stato IsRunning

            effettuaLogin = new Command(async () => //Definisce il metodo del Command effettuaLogin che gestisce il tentativo di login da parte dell'utente
            {
                IsEnabled = false;
                if (string.IsNullOrEmpty(Username)) //Controlla che il campo codice fiscale non sia nullo o vuoto
                {
                    NameErrorText = "Attenzione Username non inserito correttamente";
                    IsBusy = false;
                }
                 if (string.IsNullOrEmpty(passWord)) //Controlla che il campo password non sia nullo o vuoto
                {
                    NameErrorTextPassword = "Attenzione password non inserita correttamente";
                    IsBusy = false;
                }
                 if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(passWord)) 
                //se i campi codice fiscale e password non sono vuoti o null
                {
                    LoginIsVisible = false;
                    IsVisible = true; //L'activity indicator è visibile
                    IsBusy = true; //L'activity indicator è in stato IsRunning
                    utente.username = Username.ToUpper();
                    GestioneUtente.Instance.salvaCredenzialiAccesso(Username);
                    utente.password = passWord;
                    utente.devDescrizione = GestioneUtente.Instance.getDevDescrizione;
                    utente.devInfo = GestioneUtente.Instance.getDevInfo;
                    await  utente.Login();
                    IsBusy = false; //L'activity indicator non è in stato IsRunning
                    IsVisible = false; //L'activity indicator non è visibile
                    LoginIsVisible = true;
                    IsEnabled = true;
                }
                else
                    IsEnabled = true;
            }
            );

            showPass = new Command(() =>
            {
                if (ShowPassword == true)
                {
                    ShowPasswordImage = "eye.png";
                    ShowPassword = false;
                }   
                else
                {
                    ShowPassword = true;
                    ShowPasswordImage = "eye_hide.png";
                }
            });
        }

        #endregion

        #region Metodi


        public void modificaFlag(bool flag)
        {
            flagLogin = flag;
        }

        #endregion

    }
}
