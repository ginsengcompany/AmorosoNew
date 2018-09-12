using Concorsi.Model;
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
	public partial class Resoconto : ContentPage
	{
        ResocontoModelView z;
		public Resoconto (List<RisultatoDomande> listaDomande)
		{
			InitializeComponent ();
            z = new ResocontoModelView(this,listaDomande);
            BindingContext = z;
        }
	}
}