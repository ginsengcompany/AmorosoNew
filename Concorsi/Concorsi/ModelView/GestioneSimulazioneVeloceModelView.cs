using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Concorsi.Model;
using Concorsi.Service;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
   public class GestioneSimulazioneVeloceModelView:INotifyPropertyChanged
   {
        private List<Concorso> listaConcorsi = new List<Concorso>();
        private List<Materie> listaMaterie = new List<Materie>();
        private String maxDomande = "";
        private String domandaSelezionata = "";
        private Double valoreSlider = 100;
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
        public String MaxDomande
        {
            get { return maxDomande; }
            set
            {
                OnPropertyChanged();
                maxDomande = value;
            }
        }
        public String DomandaSelezionata
        {
            get { return domandaSelezionata; }
            set
            {
                OnPropertyChanged();
                domandaSelezionata = value;
            }
        }
        public Double ValoreSlider
        {
            get { return valoreSlider; }
            set
            {
                OnPropertyChanged();
                valoreSlider = value;
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
            MaxDomande = materiaSelezionata.domandemax;
            ValoreSlider = Int32.Parse(materiaSelezionata.numerodomande);
            IsEnabled = true;
            ListaMaterie = materiaSelezionata.materie;
       }
        public void ModificaSlider(ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 5);
            ValoreSlider = newStep * 5;
            DomandaSelezionata = ValoreSlider.ToString();
        }
        public void SelezionaMateria(Materie a)
        {
            DomandaSelezionata = "0";
            ValoreSlider = 0;
            MaxDomande = a.domandemateriamax;
        }
    }
}
