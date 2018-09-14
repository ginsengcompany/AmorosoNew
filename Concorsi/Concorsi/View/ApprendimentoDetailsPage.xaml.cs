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
            modelView = new ApprendimentoDetailsPageModelView(set);
            BindingContext = modelView;
        }
        /*
        public async Task creatable()
        {
            int i = 0;

            gridDetails.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            foreach (var quesito in listaDomande)
            {

                gridDetails.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                gridDetails.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                Label domanda = new Label
                {
                    Text = quesito.Domanda,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold
                };
                Grid quesiti = new Grid();
                quesiti = await gridQuesiti(quesito.Quesiti, quesito.Risposta);
                gridDetails.Children.Add(domanda, 0, i);
                i++;
                gridDetails.Children.Add(quesiti, 0, i);
                i++;
            }            
        }
        private async Task<Grid> gridQuesiti(List<Quesiti> quesiti, String risposta)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            int i = 0;
            foreach (var quesito in quesiti)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                Label lettera = new Label
                {
                    Text = quesito.lettera,
                    TextColor = Color.Black,
                };
                Label detalies = new Label
                {
                    Text = quesito.quesito,
                    TextColor = Color.Black,
                };
                if (quesito.lettera == risposta)
                {
                    detalies.TextColor = Color.Green;
                    detalies.FontAttributes = FontAttributes.Bold;
                    lettera.FontAttributes = FontAttributes.Bold;
                }
                grid.Children.Add(lettera, 0, i);
                grid.Children.Add(detalies, 1, i);
                i++;
            }
            return grid;
        }*/
    }
}