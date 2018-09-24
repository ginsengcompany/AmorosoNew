using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
   public class ModalitaClassicaPageModelView:INotifyPropertyChanged
   {
       private List<PianiFormativi> piani = new List<PianiFormativi>();
       private List<Set> listaSetDomande = new List<Set>();
       private bool isBusy = false;

       public event PropertyChangedEventHandler PropertyChanged;


       public bool IsBusy
       {
           get { return isBusy; }
           set
           {
               OnPropertyChanged();
               isBusy = value;
           }
       }
        public List<PianiFormativi> Piani
       {
           get { return piani; }
           set
           {
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
       public ModalitaClassicaPageModelView()
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
