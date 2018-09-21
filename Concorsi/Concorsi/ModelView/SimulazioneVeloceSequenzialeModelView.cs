﻿using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class SimulazioneVeloceSequenzialeModelView: INotifyPropertyChanged
    {
        private List<Concorso> listaConcorsi = new List<Concorso>();
        private List<Materie> listaMaterie = new List<Materie>();
        private List<string>pacchetti = new List<string>();
        private SpeedQuiz quiz = new SpeedQuiz();
        int numeroDomande = 0;

        private bool isEnabled, isEnabledMateria = false;

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

        public bool IsEnabledMateria
        {
            get { return isEnabledMateria; }
            set
            {
                OnPropertyChanged();
                isEnabledMateria = value;
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

        public List<string> Pacchetti
        {
            get { return pacchetti; }
            set
            {
                OnPropertyChanged();
                pacchetti = value;
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

        private async void RicezioneConcorsiMaterie()
        {
            Utente utente = new Utente();
            REST<Utente, Response<List<Concorso>>> connessioneMaterieConcorsi = new REST<Utente, Response<List<Concorso>>>();
           // utente.username = GestioneUtente.Instance.getUserName;
            utente.username = "MANUTENZIONE1234";
            var response = await connessioneMaterieConcorsi.PostJson(URL.speedQuiz, utente);
            ListaConcorsi = response.message;

        }

        public void RicezioneConcorso(Concorso concorsoSelezionato)
        {

            IsEnabled = true;
            if (ListaMaterie.Count != 0)
                ListaMaterie = new List<Materie>();
            quiz.concorso = concorsoSelezionato.id_concorso;
            ListaMaterie = concorsoSelezionato.materie;
        }


        public SimulazioneVeloceSequenzialeModelView()
        {
            RicezioneConcorsiMaterie();
        }

        public async void PacchettoSelezionato(int pacchetto)
        {

            switch (pacchetto)
            {
                case 0:
                    numeroDomande = 20;
                    break;
                case 1:
                    numeroDomande = 40;
                    break;
                case 2:
                    numeroDomande = 60;
                    break;
                case 3:
                    numeroDomande = 80;
                    break;
                case 4:
                    numeroDomande = 100;
                    break;
            }

            REST<SpeedQuiz, Response<List<Pacchetti>>> connessionePacchetti = new REST<SpeedQuiz, Response<List<Pacchetti>>>();
            quiz.intervallo = numeroDomande;
            var response = await connessionePacchetti.PostJson(URL.pacchetti, quiz);

        }

        public async void MateriaSelezionata(Materie materiaSelezionata)
        {
            IsEnabledMateria = true;
            quiz.materia = materiaSelezionata.materia;
        }
    }
}
