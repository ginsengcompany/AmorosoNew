using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class SpeedQuiz
    {
        public string concorso { get; set; }
        public string materia { get; set; }
        public int intervallo { get; set; }

    }

    public class Pacchetti
    {
        public int pacchetto { get; set; }
        public List<Answers> domande { get; set; }
    }

}
