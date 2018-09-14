using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelezionaTipoSimulazione : ContentPage
	{
        private SezioneTipoSimulazioneModelView sezioneTipoSimulazioneModelView;
        public SelezionaTipoSimulazione ()
		{
			InitializeComponent ();
            setTestoLabel();
            sezioneTipoSimulazioneModelView = new SezioneTipoSimulazioneModelView();
            BindingContext = sezioneTipoSimulazioneModelView;
        }

        public void setTestoLabel()
        {
            LabelSimulazione.Text = "In questa modalità è possibile eseguire una simulazione d'esame del test, " +
                "pertanto selezionata una risposta automaticamente si passa alla successiva. *Nota: premendo il " +
                "tasto back in alto a sinistra le statistiche saranno contate. " +
                "NOTA: In questa modalità è previsto una misura cronometrica dei tempi di risposta";
            LabelSimulazioneAssistita.Text = "In questa modalità è possibile eseguire una simulazione d'esame " +
                "del test. Rispetto alla modalità Simulazione, in caso di errore, si avrà il vantaggio di vedere " +
                "indicata la risposta esatta. " +
                "NOTA: In questa modalità è prevista una misurazione del tempo totale di risposta";
        }
	}
}