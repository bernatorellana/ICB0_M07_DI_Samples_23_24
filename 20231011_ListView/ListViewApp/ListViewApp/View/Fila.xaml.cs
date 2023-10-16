﻿using ListViewApp.Model;
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

namespace ListViewApp.View
{
    public sealed partial class Fila : UserControl
    {
        public Fila()
        {
            this.InitializeComponent();
        }




        public Persona LaPersona
        {
            get { return (Persona)GetValue(LaPersonaProperty); }
            set { SetValue(LaPersonaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LaPersona.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPersonaProperty =
            DependencyProperty.Register("LaPersona", typeof(Persona), typeof(Fila), new PropertyMetadata(null));



    }
}
