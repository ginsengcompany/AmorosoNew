using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class VideoLezioni
    {
        public string Nome { set; get; }
        public string VideoSource { set; get; }
        public string Descrizione { set; get; }
        public string sottoCategoria { set; get; }
        public string Materia { set; get; }
    }
    public class MaterieVideo
    {
        public string Materia { set; get; }
    }
}