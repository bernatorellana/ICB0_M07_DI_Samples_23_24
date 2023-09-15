using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IntroCsharp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Hola Món !!");
            txbSortida.Text = "HOLA MÓN ";

            // sencers
            int i = 12;
            long l = 2342342;
            l = i;
            i = (int)l;
            // amb decimals
            float f = (float)23.10;
            debug("" + f.ToString("##.0000000000000"));
            double d = 23.12;
            decimal dec = 234.3m;// BigDecimal
            char c = 'a';
            String nom = "Paco";
            nom = nom.ToUpper();
            debug(nom);
            nom += " Gutiérrez Pérez" + "\n";

            // Extracció del nom
            debug(nom.Substring(0, nom.IndexOf(" ")));
            debug(nom.Substring(nom.IndexOf(" ") + 1));
            string[] noms = nom.Split(' ');
            debug(noms[0]);
            debug(noms[1] + " " + noms[2]);
            debug("ria".PadLeft(50));
            debug("Mar".PadLeft(50));
            debug("Maria".PadLeft(50));
            debug("ria".PadLeft(50));
            debug("Maria".PadLeft(50));
            debug("ia".PadLeft(50));
            debug("Mara".PadLeft(50));

            //***************************************
            // Conversió de números a String
            int edat = 34;
            float pes = 2256.3f;
            CultureInfo ciEnglish = new CultureInfo("en-US");
            String frase = $"Maria té {edat} anys i pesa " + pes.ToString("#,###.00", ciEnglish);
            debug(frase);
            frase = $"Maria té {edat} anys i pesa {pes.ToString("#,###.00", new CultureInfo("ca-ES"))}";
            debug(frase);
            //***************************************
            // Conversió de dates a String
            DateTime ara = DateTime.Now;
            DateTime avui = DateTime.Today;
            if (avui < ara)
            {
                debug("Passaré per aquí??????");

                debug(ara.ToString("dddd, dd \\de MMMM \\de yyyy, hh:mm tt", ciEnglish));
            }

            

            for(int m = 1; m <= 12; m++)
            {
                DateTime data = new DateTime(2023, m, 01);
                debug(data.ToString("MMMM", ciEnglish));
            }
            DateTime dilluns = new DateTime(2023, 09, 11);
            for (int m = 1; m <= 7; m++)
            {   
                debug(dilluns.ToString("dddd", ciEnglish));
                dilluns = dilluns.AddDays(1);
            }


        }

        private void debug(string nom)
        {
            txbSortida.Text += nom + "\n";
        }
    }
}
