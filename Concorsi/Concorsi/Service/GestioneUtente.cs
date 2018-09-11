using Plugin.DeviceInfo;
using Xamarin.Forms;

/*
 * @Author: Antonio Saverio Valente
 * 
 * Questa classe serve a tenere traccia dei dati personali di accesso e 
 * dei dati anagrafici dell'utente. Gestisce inoltre il salvataggio delle credenziali sul
 * dispositivo definendo delle classi capaci di memorizzare le informazioni
 * all'interno del dizionario dell'applicazione (Application.Current.Properties)
 * */

namespace Concorsi.Service
{
    public class GestioneUtente
    {
        // Indica l'username dell'utente
        private string userName;
        // Indica la Password dell'utente
        private string password;
        // Indica il nome di battesimo dell'utente
        private string nomeDiBattesimo;
        // Costituisce la dichiarazione di un oggetto di tipo Utente
        private static GestioneUtente instance;
        // Informazioni del device
        private string devInfo = "";
        // Descrizione del device utente
        private string devDescrizione = "";
        //Il bit di login assumerà valore 1 durante l'esecuzione della loginpage; 
        // # FORSE VA TOLTO # 
        private int bitLogin = 0;

        /**
         * 
         * @param us: parametro che indica l'username, serve per inizializzare l'oggetto
         * @param pass: è un parametro che viene passato per inizializzare la variabile di istanza password
         * dell'oggetto Utente
         * Il costruttore privato permette i generare un signleton della classe utente.
         * 
         * */
        private GestioneUtente(string us, string pass)
        {
            this.userName = us;
            this.password = pass;
            this.devInfo = getDevInfo;
            this.devDescrizione = getDevDescrizione;
            this.nomeDiBattesimo = getNomeDiBattesimo;
        }

        public string getUserName { get; set; }
        public string getPassword { get; set; }
        public string getNomeDiBattesimo { get; set; }

        public string getDevInfo
        {
            get
            {
                devInfo = CrossDeviceInfo.Current.Id;
                return devInfo;
            }
            set
            {
                devInfo = CrossDeviceInfo.Current.Id;
            }
        }

        public string getDevDescrizione
        {
            get
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    devDescrizione = CrossDeviceInfo.Current.Idiom + " " + CrossDeviceInfo.Current.Model + " " + CrossDeviceInfo.Current.Platform;
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    devDescrizione = CrossDeviceInfo.Current.Idiom + " " + CrossDeviceInfo.Current.Model + " " + CrossDeviceInfo.Current.Platform;
                }
                return devDescrizione;
            }
            set
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    devDescrizione = CrossDeviceInfo.Current.Idiom + " " + CrossDeviceInfo.Current.Model + " " + CrossDeviceInfo.Current.Platform;
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    devDescrizione = CrossDeviceInfo.Current.Idiom + " " + CrossDeviceInfo.Current.Model + " " + CrossDeviceInfo.Current.Platform;
                }
            }
        }

        /**
         * Questo metodo genera un singleton della classe Utente
         * */
        public static GestioneUtente Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestioneUtente("", "");
                }
                return instance;
            }
        }

        /**
         * Questo metodo permette di salvare le credenziali (in particolare l'username) dell'utente
         * all'interno del dizionario gestito dal metodo statico Application.Current.Properties.Add
         * */
        public void salvaCredenzialiAccesso(string user)
        {
            if (!string.IsNullOrWhiteSpace(user))
            {
                this.userName = user;
                Application.Current.Properties.Add("userName", user);
                Application.Current.SavePropertiesAsync();
            }
        }

        /**
         * Questo metodo permette di recuperare l'username utente dalla memoria interna.
         * */
        public string recuperaUserName()
        {
            string u;
            /**
             * Se è già presente una chiave userName in memoria viene recuperato il campo userName 
             * dal dizionario interno dell'applicazione che è stato in precedenza settatto 
             * al valore inserito in fase di login. 
             * Tale dizionario (Application.Current.Properties) viene usato per memorizzare i dati
             * sul dispositivo.
             * */
            if (Application.Current.Properties.ContainsKey("userName"))
            {
                u = Application.Current.Properties["userName"].ToString();
            }
            else
            {
                u = null;
            }
            return u;
        }

        /**
         * Questo metodo agisce in caso di aggiornamento da parte dell'utente dell'username.
         * In tal modo viene salvato il nuovo username inserito in memoria del telefono, in 
         * particolare all'interno dell'Application.Current...
         * */
        public void cancellaEdAggiornaUsername(string nuovo)
        {
            this.userName = nuovo;
            Application.Current.Properties.Clear();
            Application.Current.Properties.Add("userName", nuovo);
            Application.Current.SavePropertiesAsync();
        }
    }
}
