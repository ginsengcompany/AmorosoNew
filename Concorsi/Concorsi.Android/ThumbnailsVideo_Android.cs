using Concorsi.Service;
using Xamarin.Forms;
using Concorsi.Droid;
using Android.Media;
using System.Collections.Generic;
using System.IO;
using Android.Graphics;

[assembly: Dependency(typeof (ThumbnailsVideo_Android))]

namespace Concorsi.Droid
{
    public class ThumbnailsVideo_Android : IThumbnailsVideo
    {
        public ImageSource GenerateThumbImage(string url, long usecond)
        {
            MediaMetadataRetriever retriever = new MediaMetadataRetriever();
            retriever.SetDataSource(url, new Dictionary<string, string>());
            Bitmap bitmap = retriever.GetFrameAtTime(usecond);
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                byte[] bitmapData = stream.ToArray();
                return ImageSource.FromStream(() => new MemoryStream(bitmapData));
            }
            return null;
        }
    }
}