using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class ApprendimentoModelView: INotifyPropertyChanged
    {
        private List<PianiFormativi> piani = new List<PianiFormativi>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<PianiFormativi> Piani
        {
            get { return piani; }
            set {
                OnPropertyChanged();
                piani = value;
            }
        }
        public ApprendimentoModelView()
        {
            RicezionePianiFormativi();
        }

        public async void RicezionePianiFormativi()
        {
            Utente utente = new Utente();
            utente.username = GestioneUtente.Instance.getUserName;
            REST<Utente, Response<List<PianiFormativi>>> connessionePianiFormativi = new REST<Utente, Response<List<PianiFormativi>>>();
            var response = await connessionePianiFormativi.PostJson(URL.Apprendimento, utente);
            Piani = response.message;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
