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
        private List<Set> listaSetDomande = new List<Set>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<PianiFormativi> Piani
        {
            get { return piani; }
            set {
                OnPropertyChanged();
                piani = value;
            }
        }

        public List<Set> ListaSetDomande
        {
            get { return listaSetDomande; }
            set
            {
                OnPropertyChanged();
                listaSetDomande = value;
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
            var response = await connessionePianiFormativi.PostJson(SingletonURL.Instance.getRotte().apprendimento, utente);
            Piani = response.message;
        }

        public async void PianoSelezionato(PianiFormativi pianoSelezionato)
        {
            ListaSetDomande = pianoSelezionato.set;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
