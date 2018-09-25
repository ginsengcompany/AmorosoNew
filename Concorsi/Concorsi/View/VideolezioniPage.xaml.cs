using System;
using Concorsi.Model;
using Concorsi.Service;
using FormsVideoLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideolezioniPage : ContentPage
	{
        Timer time = new Timer();
	    private bool exit = false;
		public VideolezioniPage (string urlVideo)
		{
            InitializeComponent();
            time.Tempo(true);
            var video = urlVideo.Replace(" ", "%20");
            urlVideo = URL.urlBase + video;
            videoView.Source = VideoSource.FromUri(urlVideo);
            
		}

	    protected override void OnDisappearing()
	    {
            FineSessione();
	        base.OnDisappearing();
	    }
	    protected override bool OnBackButtonPressed()
	    {
            FineSessione();
	        return true;
	    }

	    public async void FineSessione()
	    {
	        if (!exit)
	        {
                time.FermaTempo();
	            exit = await DisplayAlert("Attenzione", "sei sicuro di voler uscire dalla pagina?", "SI", "NO");
	            if (exit)
	            {
	               await time.invioTempi("tempoVideo");
	               await Navigation.PopAsync();
	            }
	            else
	            {
	                time.RestartTempo();
	            }
	        }
	    }

	    private void MenuItem_OnClicked(object sender, EventArgs e)
	    {
	        FineSessione();
	    }
	}
}