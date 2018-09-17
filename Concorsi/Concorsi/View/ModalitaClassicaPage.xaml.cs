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
	public partial class ModalitaClassicaPage : ContentPage
	{
	    private ModalitaClassicaPageModelView modelView;
		public ModalitaClassicaPage ()
		{
			InitializeComponent ();
            modelView= new ModalitaClassicaPageModelView();
		    BindingContext = modelView;
		}
	}
}