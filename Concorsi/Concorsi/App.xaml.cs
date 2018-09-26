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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIwMDdAMzEzNjJlMzIyZTMwazRsNDhKcTdvNVZYS082MUI2dnFCNjAyb0lyRUxOcnJqMjJYdkp6bzJrYz0=");


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
