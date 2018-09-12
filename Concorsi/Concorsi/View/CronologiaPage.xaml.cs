using Concorsi.Model;
using Concorsi.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CronologiaPage : ContentPage
    {
        private CronologiaModelView z;

        public CronologiaPage()
        {
            InitializeComponent();
            z = new CronologiaModelView(this);
            BindingContext = z; //Questa pagina utilizza l'MWWM ed effettua il binding con la classe CronologiaModelView
        }

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var a = sender as Picker;
            var b = a.SelectedItem as Cronologia;
            z.SessioneDataSelezionata(b.sessioni);

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var a = e.Item as Sessione;
            var b = a.domande;
            Navigation.PushAsync(new Resoconto(b));
        }
    }
}