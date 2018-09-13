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
	public partial class ApprendimentoDetailsPage : ContentPage
    {
        public ApprendimentoDetailsPageModelView listaArgomentiVideolezioni;

        public ApprendimentoDetailsPage()
        {
            InitializeComponent();
            listaArgomentiVideolezioni = new ApprendimentoDetailsPageModelView();
            BindingContext = listaArgomentiVideolezioni;
        }
	}
}