using Concorsi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class RisultatoQuizPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private invioQuiz risultato = new invioQuiz();
        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                OnPropertyChanged();
                isBusy = value;
            }
        }
        public invioQuiz Risultato
        {
            get { return risultato; }
            set
            {
                OnPropertyChanged();
                risultato = value;
            }
        }
        public RisultatoQuizPageModelView(invioQuiz risulatoQuiz)
        {
            Risultato = risulatoQuiz;
        }
       protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
