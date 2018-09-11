using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Concorsi.Service
{
    public interface IThumbnailsVideo
    {
        ImageSource GenerateThumbImage(string url, long usecond);
    }
}
