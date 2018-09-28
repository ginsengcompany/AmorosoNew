﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concorsi.Model;
using Concorsi.ModelView;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimulazioneVeloceRandom : ContentPage
	{
	    private SimulazioneVeloceRandomModelView modelView;
		public SimulazioneVeloceRandom ()
		{
			InitializeComponent ();
            modelView= new SimulazioneVeloceRandomModelView();
		    BindingContext = modelView;
		}
	    private void Concorsi_OnSelectedIndexChanged(object sender, EventArgs e)
	    {

            var a = sender as Picker;
            var b = a.SelectedItem as Concorso;
	        modelView.ConcorsoSelezionato(b);
	    }
    }
}