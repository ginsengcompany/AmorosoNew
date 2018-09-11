using AVFoundation;
using Concorsi.iOS;
using Concorsi.Service;
using CoreGraphics;
using CoreMedia;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ThumbnailsVideo_IOS))]

// https://forums.xamarin.com/discussion/119450/create-thumbnail-from-video
namespace Concorsi.iOS
{
    public class ThumbnailsVideo_IOS : IThumbnailsVideo
    {
        public ImageSource GenerateThumbImage(string url, long usecond)
        {
            AVAssetImageGenerator imageGenerator = new AVAssetImageGenerator(AVAsset.FromUrl((new Foundation.NSUrl(url))));
            imageGenerator.AppliesPreferredTrackTransform = true;
            CMTime actualTime;
            NSError error;
            CGImage cgImage = imageGenerator.CopyCGImageAtTime(new CMTime(usecond, 1000000), out actualTime, out error);
            return ImageSource.FromStream(() => new UIImage(cgImage).AsPNG().AsStream());
        }
    }
}

