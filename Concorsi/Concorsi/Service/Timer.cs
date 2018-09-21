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

        public string tipoTempo;
        /**
         * TEMPO TRASCORSO
         * */
        public void Tempo(bool start,Label tempolbl)
        {
            avviaTempo = start;
            tempoGlobale.Start();

            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                tempo = tempoGlobale.Elapsed;
                tempoTotale = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", tempo.Hours, tempo.Minutes, tempo.Seconds, tempo.Milliseconds);
                tempolbl.Text = string.Format("{0:00}:{1:00}:{2:00}", tempo.Hours, tempo.Minutes, tempo.Seconds);
                return avviaTempo;
            });
        }
        public void Tempo(bool start)
        {
            avviaTempo = start;
            tempoGlobale.Start();

            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                tempo = tempoGlobale.Elapsed;
                tempoTotale = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", tempo.Hours, tempo.Minutes, tempo.Seconds,tempo.Milliseconds);
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

