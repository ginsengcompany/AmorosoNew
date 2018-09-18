using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Concorsi.Service
{
    public class Timer
    {
        // Timer tempo totale simulazione
        private Stopwatch tempoGlobale = new Stopwatch();
        private TimeSpan tempo;
        public string tempoTotale;
        private bool avviaTempo;
        /**
         * TEMPO TRASCORSO
         * */
        public void Tempo(bool start,Label tempolbl)
        {
            avviaTempo = start;
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                tempoGlobale.Start();
                tempo = tempoGlobale.Elapsed;
                tempoTotale = string.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);
                tempolbl.Text = tempoTotale;
                return avviaTempo;
            });
        }

        public void FermaTempo()
        {
            tempoGlobale.Stop();
        }

        public void ResetTempo()
        {
            avviaTempo = false;
            tempoGlobale.Reset();
        }

        public void RestartTempo()
        {
            avviaTempo = true;
            tempoGlobale.Restart();
        }

    }
}

