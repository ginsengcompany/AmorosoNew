using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Concorsi.Model;
using Concorsi.Service;
using Syncfusion.SfChart.XForms;

namespace Concorsi.ModelView
{
   public class GestioneSimulazioneVeloceModelView:INotifyPropertyChanged
   {
       private List<Concorso> listaConcorsi = new List<Concorso>();
        private List<Materie> listaMaterie = new List<Materie>();
       private bool isEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

       protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
       }


       public bool IsEnabled
       {
           get { return isEnabled; }
           set
           {
               OnPropertyChanged();
               isEnabled = value;
           }
       }

        public List<Concorso> ListaConcorsi
        {
            get { return listaConcorsi; }
            set
            {
                OnPropertyChanged();
                listaConcorsi = value;
            }
        }

       public List<Materie> ListaMaterie
       {
           get { return listaMaterie; }
           set
           {
               OnPropertyChanged();
               listaMaterie = value;
           }
       }
        public GestioneSimulazioneVeloceModelView()
        {
            RicezioneConcorsiMaterie();
        }

        private async void RicezioneConcorsiMaterie()
        {
            Utente utente = new Utente();
            List<Materie> listappoggio = new List<Materie>();
            REST<Utente,Response<List<Concorso>>> connessioneMaterieConcorsi = new REST<Utente, Response<List<Concorso>>>();
            utente.username = GestioneUtente.Instance.getUserName;
            var response = await connessioneMaterieConcorsi.PostJson(URL.speedQuiz,utente);
            ListaConcorsi = response.message;
            
        }

       public void RicezioneMaterie(Concorso materiaSelezionata)
       {
           IsEnabled = true;
           ListaMaterie = materiaSelezionata.materie;
       }
    }
}
