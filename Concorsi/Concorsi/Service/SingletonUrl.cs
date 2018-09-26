using Concorsi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Concorsi.Service
{
    sealed class SingletonURL
    {
        private static SingletonURL instance = null;
        public static string errorePrelievoRotte = "";
        public bool error = false;
        public static URL rotte = new URL();

        private SingletonURL()
        {
        }

        public URL getRotte()
        {
            return rotte;
        }

        public async Task prelevaRotte()
        {
            REST<object, URL> connessione = new REST<object, URL>();
            var response = await connessione.GetSingleJson("https://amorosoconcorsi.ak12srl.it/services/servizioappNew/getrotte");
            if (connessione.responseMessage != System.Net.HttpStatusCode.OK)
            {
                error = true;
                if (string.IsNullOrEmpty(connessione.warning))
                {
                    connessione.warning = "Nessuna connessione rilevata o errore di connessione";
                }
                await App.Current.MainPage.DisplayAlert("Attenzione", connessione.warning, "OK");
            }
            else
                rotte = response;
        }

        static internal SingletonURL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonURL();
                }
                return instance;
            }
        }
    }
}
