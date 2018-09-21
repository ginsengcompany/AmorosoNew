using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class SpeedQuiz
    {
        public string concorso { get; set; }
        public int valoreGiusta { get; set; } = 0;
        public int valoreSbagliata { get; set; } = 0;
        public string materia { get; set; }
        public int intervallo { get; set; }

    }

    public class Pacchetti
    {
        public string pacchetto { get; set; }
        public string intervallo { get; set; }
        public List<Quiz> domande { get; set; }
    }

}
