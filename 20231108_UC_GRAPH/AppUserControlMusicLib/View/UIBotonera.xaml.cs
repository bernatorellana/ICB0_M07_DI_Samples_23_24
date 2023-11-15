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

namespace AppUserControlMusicLib.View
{
    public sealed partial class UIBotonera : UserControl
    {
        public UIBotonera()
        {
            this.InitializeComponent();
        }


        public List<Int32> Valors
        {
            get { return (List<Int32>)GetValue(ValorsProperty); }
            set { SetValue(ValorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorsProperty =
            DependencyProperty.Register("Valors", typeof(List<Int32>), typeof(UIBotonera), new PropertyMetadata(new List<Int32>(), ValorsChangedCallbackStatic));

        private static void ValorsChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           UIBotonera b = (UIBotonera)d;
            b.ValorsChangedCallback(d,e);
        }

        private  void ValorsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            //  ´{4,, 12, 32}
            //    0    1   2

           stpBotons.Children.Clear();
            int n=0;
            foreach(Int32 i in Valors)
            {
                UIVolume ui = new UIVolume();
                ui.Valor = i;
                ui.Max = this.Max;
                ui.Min = this.Min;
                ui.Step = this.Step;
                ui.Width = ui.Height = 100;
                ui.Tag = n++;
                ui.Margin = new Thickness(10);
                stpBotons.Children.Add(ui);
            }
        }



        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(UIBotonera), new PropertyMetadata(100));

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(UIBotonera), new PropertyMetadata(0));
        
        public int Step
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(UIBotonera), new PropertyMetadata(20));


    }
}
