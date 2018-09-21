﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpeedQuizPageTabbed : TabbedPage
	{
		public SpeedQuizPageTabbed ()
		{
			InitializeComponent ();
            this.Children.Add(new SimulazioneVeloceRandom());
            this.Children.Add(new SimulazioneVeloceSequenziale());
		}
	}
}