using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GestioneSimulazioneVeloce : ContentPage
	{
	    private GestioneSimulazioneVeloceModelView modelView;
		public GestioneSimulazioneVeloce ()
		{
			InitializeComponent ();
            modelView= new GestioneSimulazioneVeloceModelView();
		    BindingContext = modelView;
		}
	}
}