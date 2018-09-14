using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class SelezionaModalitaQuizPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string test;

        public string Test
        {
            set
            {
                OnPropertyChanged();
                test = value;
            }
            get
            {
                return test;
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

        }
    }
}
