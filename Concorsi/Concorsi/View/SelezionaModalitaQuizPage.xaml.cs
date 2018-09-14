using Concorsi.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelezionaModalitaQuizPage : ContentPage
	{
        private SelezionaModalitaQuizPageModelView selezionaModalitaQuizPageModelView;
		public SelezionaModalitaQuizPage()
		{
			InitializeComponent ();
            setLabel();
            selezionaModalitaQuizPageModelView = new SelezionaModalitaQuizPageModelView();
            BindingContext = selezionaModalitaQuizPageModelView;
        }

        public void setLabel()
        {
            LabelModalitaClassica.Text = "In questa modalità di esercitazione avrai la possibilità " +
                "di eseguire una Simulazione d'esame sia in modalità Classica che in modalità Assistita. " +
                "Entrambe le modalità prevedono che selezionata una risposta, automaticamente si passa alla successiva." +
                "La Simulazione Assistita rispetto alla modalità Simulazione Classica permette" +
                "in caso di errore di vedere indicata la risposta esatta." +
                "Nota: premendo il tasto back in alto a sinistra le statistiche saranno contate." +
                "In questa modalità è previsto una misura cronometrica dei tempi di risposta";

            LabelModalitaQuizVeloce.Text = "In questa modalità avrai la possibilità di eseguire un test sfruttando le " +
                "domande presenti nell'intera banca dati di Amoroso Concorsi. Selezionando le opzioni in maniera opportuna " +
                "avrai la possibilità di definire il tipo di esercitazione da svolgere in maniera mirata." +
                "Nota: premendo il tasto back in alto a sinistra le statistiche saranno contate." +
                "In questa modalità è previsto una misura cronometrica dei tempi di risposta"; ;
        }
	}
}