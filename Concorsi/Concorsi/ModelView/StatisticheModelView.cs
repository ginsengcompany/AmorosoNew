using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class StatisticheModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

         protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public StatisticheModelView()
        {

        }
    }
}
