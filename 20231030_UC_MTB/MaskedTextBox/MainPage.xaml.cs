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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace MaskedTextBox
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private String Mask = "(999) aaa 999-999";
        /// <summary>
        /// Caràcters admesos a la màscara
        /// </summary>
        private String separadors=" ();-_:.,/\\|[]{}'\"";

        private String escrit = "";

        public MainPage()
        {
            this.InitializeComponent();

        }
        /// <summary>
        /// Prenem la cadena escrit i la formatem usant la Mask
        /// </summary>
        private void showEscrit()
        {
            String sortida = "";
            int posMask = 0;
            foreach(var lletra in escrit)
            {
                while (posMask<Mask.Length && separadors.Contains(Mask[posMask]))
                {
                    sortida += Mask[posMask];
                    posMask++;
                }
                sortida += lletra;                
                posMask++;
            }
            txtMasked.Text = sortida;
        }

        private void txtEscrit_TextChanged(object sender, TextChangedEventArgs e)
        {
            escrit = txtEscrit.Text;
            showEscrit();
        }


        private Boolean pucEscriure(char c, int posMasked)
        {
            // "(999) aaa 999-999";
            //  (223)  

            while (posMasked<Mask.Length && Mask[posMasked]!='a' && Mask[posMasked] != '9')
            {
                posMasked++;
            }
            if (posMasked >= Mask.Length) return false;

            if (Mask[posMasked] == 'a')
            {
                return (Char.IsLetter(c));
            }
            else if (Mask[posMasked] == '9') { 
                return Char.IsNumber(c); 
            }
            return false;

        }

        private void txtMasked_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            /*
            KeysConverter converter = new KeysConverter0();
            char character = (char)converter.ConvertFrom(virtualKeyCode.ToString());

            String c =  e.Key.ToString();*/
        }
    }
}
