using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concorsi.Model;
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

	    private void Concorsi_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        var a = sender as Picker;
	        var b = a.SelectedItem as Concorso;
            modelView.RicezioneMaterie(b);
        }

	    private void Materie_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        var a = sender as Picker;
	        var b = a.SelectedItem as Materie;
        }

	    private void SliderNumeroDomande_OnValueChanged(object sender, ValueChangedEventArgs e)
	    {
	        var newStep = Math.Round(e.NewValue / 5);
	        SliderNumeroDomande.Value = newStep * 5;
	        label.Text = SliderNumeroDomande.Value.ToString();
	    }
	}
}