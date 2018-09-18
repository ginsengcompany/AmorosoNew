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
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private invioQuiz risultato = new invioQuiz();
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
    }
}
