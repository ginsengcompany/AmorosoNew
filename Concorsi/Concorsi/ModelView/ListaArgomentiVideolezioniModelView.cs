﻿using Concorsi.Model;
using Concorsi.Service;
using Concorsi.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Concorsi.ModelView
{
    public class ListaArgomentiVideolezioniModelView : INotifyPropertyChanged
    {
        public string materieSelezionate = "";
        public event PropertyChangedEventHandler PropertyChanged;
        private List<VideoLezioni> argomenti;
        private bool isBusy = false;
        private bool isEnabled = true;

        public ListaArgomentiVideolezioniModelView(string materieSelezionate)
        {
            IsEnabled = true;
            this.materieSelezionate = materieSelezionate;
            prelevaArgomentiVideolezioni();
            // generaThumbnails();
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
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                OnPropertyChanged();
                isBusy = value;
            }
        }

        public List<VideoLezioni> Argomenti
        {
            set
            {
                OnPropertyChanged();
                argomenti = value;
            }
            get
            {
                return argomenti;
            }
        }

        public async Task prelevaArgomentiVideolezioni()
        {
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("materia", materieSelezionate));
            REST<string, Response<List<VideoLezioni>>> riceviVideo = new REST<string, Response<List<VideoLezioni>>>();
            var response = await riceviVideo.PostFormURLEncoded(SingletonURL.Instance.getRotte().lezioniVideo, values);
            if (riceviVideo.responseMessage != HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Attenzione " + (int)riceviVideo.responseMessage, riceviVideo.warning, "OK");
            }
            else
            {
                Argomenti = response.message;
            }
        }

        public async void generaThumbnails()
        {
            await prelevaArgomentiVideolezioni();
            /*for (int i = 0; i < Argomenti.Count; i++)
            {
                Argomenti[i].Thumbnail = DependencyService.Get<IThumbnailsVideo>().GenerateThumbImage(
                URL.urlBase + Argomenti[i].VideoSource, 0);
            }*/
        }
        public async Task selezioneVideo(VideoLezioni video)
        {
            IsEnabled = false;
            await App.Current.MainPage.Navigation.PushAsync(new VideolezioniPage(video.VideoSource));
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
