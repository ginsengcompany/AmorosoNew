using Concorsi.Model;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Concorsi.ModelView
{
    public class StatisticheModelView : INotifyPropertyChanged
    {
        private DatiStatistica datiStatistica = new DatiStatistica();
        private List<BindingStatistica> datiPieChart = new List<BindingStatistica>();
        public event PropertyChangedEventHandler PropertyChanged;

         protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        public DatiStatistica DatiStatisticaUtente
        {
            get { return datiStatistica; }
            set
            {
                OnPropertyChanged();
                datiStatistica = new DatiStatistica(value);
            }
        }

        public List<BindingStatistica> DatiPieChart
        {
            get { return datiPieChart; }
            set
            {
                OnPropertyChanged();
                datiPieChart = value;
            }
        }

        public StatisticheModelView()
        {
            RicezioneStatistiche();
        }
        public async void RicezioneStatistiche()
        {
            Utente utenza = new Utente();
            utenza.username = GestioneUtente.Instance.getUserName;
            REST<Utente, Response<DatiStatistica>> connessioneStatistiche = new REST<Utente, Response<DatiStatistica>>();
            var responseStatistiche = await connessioneStatistiche.PostJson(URL.statisticheURL, utenza);
            DatiStatisticaUtente = responseStatistiche.message;
            DatiPieChart = new List<BindingStatistica>()
                    {
                        new BindingStatistica("Risposte esatte", DatiStatisticaUtente.domandeEsatte),
                        new BindingStatistica("Risposte errate", DatiStatisticaUtente.domandeErrate),
                        new BindingStatistica("Domande senza risposta", DatiStatisticaUtente.domandeNonRisposte)
                    };
        }
    }
}
