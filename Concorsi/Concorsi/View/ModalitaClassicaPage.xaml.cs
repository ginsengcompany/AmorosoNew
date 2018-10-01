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
	public partial class ModalitaClassicaPage : ContentPage
	{
	    private ModalitaClassicaPageModelView modelView;
		public ModalitaClassicaPage ()
		{
			InitializeComponent ();
            modelView= new ModalitaClassicaPageModelView();
		    BindingContext = modelView;
		}

	    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
	    {
	        var a = sender as Picker;
	        var b = a.SelectedItem as PianiFormativi;
	        modelView.PianoSelezionato(b);

	    }

	    private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var a = e.Item as Set;
            await modelView.quizSet(a);
        }
    }
}