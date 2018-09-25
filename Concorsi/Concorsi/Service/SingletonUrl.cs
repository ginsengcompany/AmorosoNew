using Concorsi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            var response = await connessione.GetSingleJson("http://ecuptservice.ak12srl.it/urlserviziapp");
            if (connessione.responseMessage != System.Net.HttpStatusCode.OK)
            {
                error = true;
                await App.Current.MainPage.DisplayAlert("Attenzione", connessione.warning, "OK");
                rotte = null;
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
