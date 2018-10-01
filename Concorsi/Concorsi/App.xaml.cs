using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Concorsi.View;
using ImageCircle.Forms.Plugin.Abstractions;
using Concorsi.Service;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Concorsi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3NzdAMzEzNjJlMzMyZTMwQXRHYmpuSDdrK1U5bkhzN0E3UFpBaXc1d0JJUTR0SWRYOWdDZzF1OWMrUT0=");


            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new SimulazioneVeloceSequenziale());
        }

        protected async override void OnStart()
        {
            await SingletonURL.Instance.prelevaRotte();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
