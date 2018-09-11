using Concorsi.Model;
using FormsVideoLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideolezioniPage : ContentPage
	{
		public VideolezioniPage (string urlVideo)
		{
            InitializeComponent();
            var video = urlVideo.Replace(" ", "%20");
            urlVideo = URL.urlBase + video;
            videoView.Source = VideoSource.FromUri(urlVideo);


            //videoView.Source = VideoSource.FromUri("https://amorosoconcorsi.ak12srl.it/services/video/2%20Mcd%20Mcm%20Insiemi%20Numerici-1.mp4");
        }
    }
}