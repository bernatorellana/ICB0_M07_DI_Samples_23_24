﻿using GestioDequips.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace NBA.View
{
    public sealed partial class MiTeam : UserControl
    {
        public MiTeam()
        {
            this.InitializeComponent();


           // dtpCreationDate.Date = DateTime.Now;

        }



        public Equip TheTeam
        {
            get { return (Equip)GetValue(TheTeamProperty); }
            set { SetValue(TheTeamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheTeam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheTeamProperty =
            DependencyProperty.Register("TheTeam", typeof(Equip), typeof(MiTeam), new PropertyMetadata(null, TheTeamChangedStatic));

        private static void TheTeamChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MiTeam instance = (MiTeam)d;
            instance.TheTeamChanged(e);
        }

        private void TheTeamChanged(DependencyPropertyChangedEventArgs e)
        {
            dtpCreationDate.Date = ((Equip)e.NewValue).DataCreacio;
        }
    }
}
