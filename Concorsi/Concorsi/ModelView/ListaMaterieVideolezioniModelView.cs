using Concorsi.Model;
using Concorsi.Service;
using Concorsi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Concorsi.ModelView
{
    public class ListaMaterieVideolezioniModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<MaterieVideo> materia;
        private bool isBusy = false;
        private bool isEnabled = true;


        public ListaMaterieVideolezioniModelView()
        {
            IsEnabled = true;
            prelevaMaterieVideolezioni();
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
        public List<MaterieVideo> Materia
        {
            set
            {
                OnPropertyChanged();
                materia = value;
            }
            get
            {
                return materia;
            }
        }

        public async Task prelevaMaterieVideolezioni()
        {
            REST<Object, Response<List<MaterieVideo>>> riceviMaterie = new REST<Object, Response<List<MaterieVideo>>>();
            var result = await riceviMaterie.GetSingleJson(SingletonURL.Instance.getRotte().materieVideo);
            if (riceviMaterie.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)riceviMaterie.responseMessage, riceviMaterie.warning, "OK");
            }
            else
            {
                Materia = result.message;
            }
        }
        public async Task vaiListaLezionielementoTappato(MaterieVideo materia)
        {
            IsEnabled = false;
            await App.Current.MainPage.Navigation.PushAsync(new ListaArgomentiVideolezioniPage(materia.Materia));
            IsEnabled = true;
        }

        #region OnPropertyChange
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
