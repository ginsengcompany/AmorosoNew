using Xamarin.Forms;

namespace Concorsi.Model
{
    public class VideoLezioni
    {
        public string Nome { set; get; }
        public string VideoSource { set; get; }
        public string Descrizione { set; get; }
        public string sottoCategoria { set; get; }
        public string Materia { set; get; }
        public ImageSource Thumbnail { get; set; }
    }
    public class MaterieVideo
    {
        public string Materia { set; get; }
    }    
}