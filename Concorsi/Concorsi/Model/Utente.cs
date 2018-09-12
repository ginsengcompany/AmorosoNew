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
        public string cognome { get; set; }
        public string devDescrizione { get; set; }
        public string nome { get; set; }
        public string attivo { get; set; }
        public string materia { get; set; }


        public Utente(Utente utente)
        {
            this.username = utente.username;
            this.password = utente.password;
            this.devDescrizione = utente.devDescrizione;
            this.devInfo = utente.devInfo;
            this.nome = utente.nome;
            this.cognome = utente.cognome;
            this.attivo = utente.attivo;
            this.materia = utente.materia;
        }

        public Utente()
        {
            this.username = string.Empty;
            this.password = string.Empty;
            this.devDescrizione = string.Empty;
            this.devInfo = string.Empty;
            this.nome = string.Empty;
            this.cognome = string.Empty;
            this.attivo = string.Empty;
            this.materia = string.Empty;
        }

        public async Task Login()
        {
            REST<Utente, Response<Utente>> connessioneLogin = new REST<Utente, Response<Utente>>();
            var respone = await connessioneLogin.PostJson(URL.login, this);
            if (connessioneLogin.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneLogin.responseMessage, connessioneLogin.warning, "OK");
            } else
            {
                App.Current.MainPage = new NavigationPage( new MainPage(respone.message));
            }
        }

        public async Task Logout()
        {
            REST<Utente, Response<Utente>> connessioneLogout = new REST<Utente, Response<Utente>>();
            this.devDescrizione = GestioneUtente.Instance.getDevDescrizione;
            this.devInfo = GestioneUtente.Instance.getDevInfo;
            var respone = await connessioneLogout.PostJson(URL.logout, this);
            if (connessioneLogout.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneLogout.responseMessage, connessioneLogout.warning, "OK");
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

    }
}
