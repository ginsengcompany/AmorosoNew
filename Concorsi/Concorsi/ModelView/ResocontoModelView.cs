using Concorsi.Model;
using Concorsi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class ResocontoModelView:INotifyPropertyChanged
    {
        private List<Domande> listaDomande = new List<Domande>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Domande> ListaDomande
        {
            get { return listaDomande; }
            set
            {
                OnPropertyChanged();
                listaDomande = value;
            }
        }
        public ResocontoModelView(Resoconto ResocontoPage,List<Domande>listaDomande)
        {
            foreach( var domanda in listaDomande)
            {
                if(domanda.esito == "Errata")
                    domanda.color = Color.Red;
                else if (domanda.esito == "Corretta")
                    domanda.color = Color.Green;
                else
                    domanda.color = Color.OrangeRed;
            }
            ListaDomande = listaDomande;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
