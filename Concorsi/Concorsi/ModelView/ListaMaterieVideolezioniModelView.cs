using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Concorsi.ModelView
{
    public class ListaMaterieVideolezioniModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<MaterieVideo> materia;
        

        public ListaMaterieVideolezioniModelView()
        {
            prelevaMaterieVideolezioni();
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
            REST<Object, List<MaterieVideo>> riceviMaterie = new REST<Object, List<MaterieVideo>>();
            var result = await riceviMaterie.GetSingleJson(URL.listaMaterieVideo);
            Materia = result;
        }

        #region OnPropertyChange
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
