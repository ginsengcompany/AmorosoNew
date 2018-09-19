using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Concorsi.ModelView;
using Concorsi.Model;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelezionaTipoSimulazione : ContentPage
	{
        private SelezionaTipoSimulazioneModelView selezionaTipoSimulazioneModelView;
        public SelezionaTipoSimulazione (Set set)
		{
			InitializeComponent ();
            setTestoLabel();
            selezionaTipoSimulazioneModelView = new SelezionaTipoSimulazioneModelView(set);
            BindingContext = selezionaTipoSimulazioneModelView;
        }

        public void setTestoLabel()
        {
            LabelSimulazione.Text = "In questa modalità è possibile eseguire una simulazione d'esame del test, " +
                                    "pertanto selezionata una risposta automaticamente si passa alla successiva.  ";
            LabelSimulazioneAssistita.Text = "In questa modalità è possibile eseguire una simulazione d'esame " +
                                             "del test. Rispetto alla modalità Simulazione, in caso di errore, si avrà il vantaggio di vedere " +
                                             "indicata la risposta esatta. ";

        }
    }
}