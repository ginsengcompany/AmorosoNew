using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concorsi.ModelView;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimulazioneVeloceRandom : ContentPage
	{
	    private SimulazioneVeloceRandomModelView modelView;
		public SimulazioneVeloceRandom ()
		{
			InitializeComponent ();
            modelView= new SimulazioneVeloceRandomModelView();
		    BindingContext = modelView;
		}

	    private void SfSegmentedControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	    {
	        var a = e.Index.ToString();
	    }
	}
}