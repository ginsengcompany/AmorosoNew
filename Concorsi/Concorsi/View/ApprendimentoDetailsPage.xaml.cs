using Concorsi.Model;
using Concorsi.ModelView;
using Concorsi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApprendimentoDetailsPage : ContentPage
    {
        ApprendimentoDetailsPageModelView modelView;
        public ApprendimentoDetailsPage(Set set)
        {
           
            InitializeComponent();
            modelView = new ApprendimentoDetailsPageModelView(set,lblTempo);
            BindingContext = modelView;
        }
        protected override  void OnDisappearing()
        {           
                modelView.fineSessione();
                base.OnDisappearing();
        }
        protected override bool OnBackButtonPressed()
        {
            modelView.fineSessione();
            return true;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            modelView.fineSessione();
        }
    }
}