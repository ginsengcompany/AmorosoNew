using Concorsi.Service;
using Concorsi.View;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Concorsi.Model
{
    public class Utente
    {
        public string username { get; set; }
        public string password { get; set; }
        public string devInfo { get; set; }
        public string devDescrizione { get; set; }


        public Utente(Utente utente)

        {
            this.username = utente.username;
            this.password = utente.password;
            this.devDescrizione = utente.devDescrizione;
            this.devInfo = utente.devInfo;
        }

        public Utente()
        {
            this.username = string.Empty;
            this.password = string.Empty;
            this.devDescrizione = string.Empty;
            this.devInfo = string.Empty;
        }

        public async Task Login()
        {
            REST<Utente, Response> connessioneLogin = new REST<Utente, Response>();
            var respone = await connessioneLogin.PostJson(URL.login, this);
            if (connessioneLogin.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneLogin.responseMessage, connessioneLogin.warning, "OK");
            } else
            {
                var obj = respone.message;
                App.Current.MainPage = new NavigationPage( new MainPage(this));
            }
        }

        public async Task Logout()
        {
            REST<Utente, Response> connessioneLogout = new REST<Utente, Response>();
            var respone = await connessioneLogout.PostJson(URL.logout, this);
            if (connessioneLogout.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneLogout.responseMessage, connessioneLogout.warning, "OK");
            }
            else
            {
                App.Current.MainPage = new LoginPage();
            }
        }

    }
}
