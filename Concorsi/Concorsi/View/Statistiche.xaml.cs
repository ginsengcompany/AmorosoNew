﻿using Concorsi.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Concorsi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistiche : ContentPage
    {
        private StatisticheModelView modelView;

        public Statistiche()
        {
            InitializeComponent();
            modelView = new StatisticheModelView();
            BindingContext = modelView;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = sender as Picker;
            var b = a.SelectedItem as string;
            modelView.RicezioneStatistiche(b);
        }
    }
}