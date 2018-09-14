﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class SelezionaModalitaQuizPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string testoModalitaClassica, testoModalitaVeloce;

        public string TestoModalitaClassica
        {
            set
            {
                OnPropertyChanged();
                testoModalitaClassica = value;
            }
            get
            {
                return testoModalitaClassica;
            }
        }


        public string TestoModalitaVeloce
        {
            set
            {
                OnPropertyChanged();
                testoModalitaVeloce = value;
            }
            get
            {
                return testoModalitaVeloce;
            }
        }

        #region OnPropertyChange

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        public SelezionaModalitaQuizPageModelView()
        {
            TestoModalitaClassica= "In questa modalità di esercitazione avrai la possibilità " +
                                   "di eseguire una Simulazione d'esame sia in modalità Classica che in modalità Assistita. " +
                                   "Entrambe le modalità prevedono che selezionata una risposta, automaticamente si passa alla successiva." +
                                   "La Simulazione Assistita rispetto alla modalità Simulazione Classica permette" +
                                   "in caso di errore di vedere indicata la risposta esatta." +
                                   "Nota: premendo il tasto back in alto a sinistra le statistiche saranno contate." +
                                   "In questa modalità è previsto una misura cronometrica dei tempi di risposta";
            TestoModalitaVeloce= "In questa modalità avrai la possibilità di eseguire un test sfruttando le " +
                                 "domande presenti nell'intera banca dati di Amoroso Concorsi. Selezionando le opzioni in maniera opportuna " +
                                 "avrai la possibilità di definire il tipo di esercitazione da svolgere in maniera mirata." +
                                 "Nota: premendo il tasto back in alto a sinistra le statistiche saranno contate." +
                                 "In questa modalità è previsto una misura cronometrica dei tempi di risposta";
        }
    }
}
