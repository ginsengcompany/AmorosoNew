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
            selezionaModalitaQuizPageModelView = new SelezionaModalitaQuizPageModelView();
            BindingContext = selezionaModalitaQuizPageModelView;
        }

     
	}
}