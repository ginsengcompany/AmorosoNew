using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Concorsi.ModelView
{
    public class ApprendimentoDetailsPageModelView : INotifyPropertyChanged
    {
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private List<Answers> listaDomande;
        public List<Answers> ListaDomande
        {
            set
            {
                OnPropertyChanged();
                listaDomande = value;
            }
            get
            {
                return listaDomande;
            }
        }
        public async Task prelevaAnswers()
        {
            Set values = new Set();
            values.nome_set = "Attualità 1";
            REST<Set, Response<List<Answers>>> riceviVideo = new REST<Set,Response<List<Answers>>>();
            var response = await riceviVideo.PostJson(URL.DomandeApprendimento, values);
            ListaDomande = response.message;
        }
        public ApprendimentoDetailsPageModelView()
        {
            prelevaAnswers();
        }
    }
}
