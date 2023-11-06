using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace MaskedTextBox.View
{
    public sealed partial class UIMaskedTextbox : UserControl
    {
        public UIMaskedTextbox()
        {
            this.InitializeComponent();
            txtMasked.PlaceholderText = Mask;
        }


        public String Mask
        {
            get { return (String)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mask.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(String), typeof(UIMaskedTextbox), new PropertyMetadata(""));



        /// <summary>
        /// Caràcters admesos a la màscara
        /// </summary>
        private String separadors = " ();-_:.,/\\|[]{}'\"";

        private String escrit = "";


            

        /// <summary>
        /// Prenem la cadena escrit i la formatem usant la Mask
        /// </summary>
        private void showEscrit()
        {
            String sortida = "";
            int posMask = 0;
            foreach (var lletra in escrit)
            {
                while (posMask < Mask.Length && separadors.Contains(Mask[posMask]))
                {
                    sortida += Mask[posMask];
                    posMask++;
                }
                sortida += lletra;
                posMask++;
            }
            txtMasked.Text = sortida;
            txtMasked.SelectionStart = txtMasked.Text.Length;
        }

        private Boolean pucEscriure(char c, int posMasked)
        {
            // "(999) aaa 999-999";
            //  (223)  

            while (posMasked < Mask.Length && Mask[posMasked] != 'a' && Mask[posMasked] != '9')
            {
                posMasked++;
            }
            if (posMasked >= Mask.Length) return false;

            if (Mask[posMasked] == 'a')
            {
                return (Char.IsLetter(c));
            }
            else if (Mask[posMasked] == '9')
            {
                return Char.IsNumber(c);
            }
            return false;

        }

        private void txtMasked_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {

            char caracter = (char)0;
            String c = e.Key.ToString();
            if (c.Length == 1 && Char.IsLetter(c[0]))
            {
                caracter = c[0];
            }
            else if (c.StartsWith("Number"))
            {
                caracter = c.Last();
            }
            else
            {


                var shiftState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Shift);
                var isShiftDown = shiftState != CoreVirtualKeyStates.None;

                Dictionary<VirtualKey, List<Char>> mapping = new Dictionary<VirtualKey, List<Char>>()
                {
                    { (VirtualKey)188 , new List<Char>() { ';', ',' }  },
                    { (VirtualKey)190 , new List<Char>() { ':', '.' }  },
                    { (VirtualKey)189 , new List<Char>() { '_', '-' }  }
                };
                if (mapping.ContainsKey(e.Key))
                {
                    caracter = mapping[e.Key][isShiftDown ? 0 : 1];
                }
            }
            System.Diagnostics.Debug.WriteLine(caracter);
            bool caracterCorrecte = (caracter != 0 && pucEscriure(caracter, txtMasked.SelectionStart));

            if (e.Key != VirtualKey.Back)
            {
                e.Handled = true;
            }
            else
            {
                escrit = escrit.Substring(0, escrit.Length - 1);
            }


            if (caracterCorrecte)
            {
                escrit += caracter;
                showEscrit();
            }

        }


    }
}
