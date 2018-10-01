using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concorsi.Model;
using Concorsi.ModelView;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimulazioneVeloceSequenziale : ContentPage
	{
	    private SimulazioneVeloceSequenzialeModelView modelView;
		public SimulazioneVeloceSequenziale ()
		{
			InitializeComponent ();
            modelView= new SimulazioneVeloceSequenzialeModelView();
		    BindingContext = modelView;
		}

	    private void SfSegmentedControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	    {
	        var a = e.Index;
            modelView.PacchettoSelezionato(a);
	    }

	    private void Concorsi_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        var a = sender as Picker;
	        var b = a.SelectedItem as Concorso;
	        modelView.RicezioneConcorso(b);
	    }

	    private void Materie_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        if (pickermaterie.SelectedIndex == -1)
	            return;

	        var a = sender as Picker;
	        var b = a.SelectedItem as Materie;
            modelView.MateriaSelezionata(b);

	    }

	    private async void VaiQuiz(object sender, ItemTappedEventArgs e)
	    {
	        var a = e.Item as Pacchetti;
           await modelView.VaiPaginaQuiz(a);

        }
	}
}