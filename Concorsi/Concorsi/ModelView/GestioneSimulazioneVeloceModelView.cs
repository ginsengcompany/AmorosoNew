using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
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
        private Double valoreSlider = 10;
        private bool isEnabled = false;
       private bool isBusy = false;

        public event PropertyChangedEventHandler PropertyChanged;

       protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
       }

       public bool IsBusy
       {
           get { return isBusy; }
           set
           {
               OnPropertyChanged();
               isBusy = value;
           }
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
            var response = await connessioneMaterieConcorsi.PostJson(SingletonURL.Instance.getRotte().datiSpeedQuiz,utente);
            if (connessioneMaterieConcorsi.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)connessioneMaterieConcorsi.responseMessage, connessioneMaterieConcorsi.warning, "OK");
            }
            else
            {
                ListaConcorsi = response.message;
            }
            
            
        }

       public void RicezioneMaterie(Concorso materiaSelezionata)
       {
          
            MaxDomande = materiaSelezionata.domandemax;
            ValoreSlider = Int32.Parse(materiaSelezionata.numerodomande);
            IsEnabled = true;
           if (ListaMaterie.Count != 0)
               ListaMaterie= new List<Materie>();

           ListaMaterie = materiaSelezionata.materie;
       }
        public void ModificaSlider(ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 5);
            ValoreSlider = newStep * 5;
            if (ValoreSlider > Int32.Parse(MaxDomande))
            {
                ValoreSlider = Int32.Parse(MaxDomande);
            }
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
