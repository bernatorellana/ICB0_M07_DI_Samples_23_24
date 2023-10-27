using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace _20231025_UC_NT.View
{
    public sealed partial class UINumericTextbox : UserControl
    {
        public UINumericTextbox()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Aquest event es dispara per qualsevol canvi de valor del control.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        #region Prop-dps


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UINumericTextbox), new PropertyMetadata(0));


        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(UINumericTextbox), new PropertyMetadata(100));


        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(UINumericTextbox), new PropertyMetadata(0));


        #endregion

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value;
            bool isNumber = Int32.TryParse(txtValue.Text, out value);
            if(isNumber)
            {
                Value = value;
            } else
            {
                Value = 0;
            }
            //if(ValueChanged!=null) ValueChanged.Invoke(this, EventArgs.Empty);
            ValueChanged?.Invoke(this, new EventArgs());


        }

        private void txtValue_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ( !(
                e.Key==VirtualKey.Back ||e.Key==VirtualKey.Delete||
                e.Key==VirtualKey.Left || e.Key == VirtualKey.Right ||
                (e.Key>=Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9) ||
                (e.Key>=Windows.System.VirtualKey.NumberPad0 && e.Key <= Windows.System.VirtualKey.NumberPad9)
                )
            )
            {
                e.Handled = true;
            }
        }

        private void txtValue_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            e.Handled= true;
        }
    }
}
