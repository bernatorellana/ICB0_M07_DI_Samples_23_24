using AppCollections.Model;
using System;
using System.Collections;
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

namespace AppCollections
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Persona> llistaPersones;
        private List<Persona> llistaPersones2;
        public MainPage()
        {
            this.InitializeComponent(); 
            
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Persona p0 = new Persona(1, "Joan Busquets", 32, Level.NOOB);
            Persona p1 = new Persona(2, "Maria Gutiérrez", 36, Level.AVERAGE);
            Persona p2 = new Persona(3, "Pepe Saez", 34, Level.PRO);
            Persona p3 = new Persona(4, "Joao Figueira", 75, Level.HACKER);
            Persona p4 = new Persona(5, "Ester Minator", 64, Level.GOD);
            Persona p5 = new Persona(6, "Pere Pau", 83, Level.PRO);
  

            // Creació d'una llista de persones
            llistaPersones = new List<Persona>();

            llistaPersones.Add(p0);
            llistaPersones.Add(p1);
            llistaPersones.Add(p2);
            llistaPersones.Add(p3);
            llistaPersones.Add(p4);
            llistaPersones.Add(p5);

            lsvPersones.ItemsSource = llistaPersones;
        }

        private void lsvPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = (Persona)lsvPersones.SelectedItem;



            // Versió 1: "a sac pac"
            ////rdoLevelNoob.IsChecked = p.Level == Level.NOOB;
            ////rdoLevelAverage.IsChecked = p.Level == Level.AVERAGE;
            ////rdoLevelPro.IsChecked = p.Level == Level.PRO;
            ////rdoLevelHacker.IsChecked = p.Level == Level.HACKER;
            ////rdoLevelGod.IsChecked = p.Level == Level.GOD;     
            ///

            // Versió 2: una mica millor
            //List<RadioButton> rdos = new List<RadioButton>()
            //{
            //    rdoLevelNoob,
            //    rdoLevelAverage,
            //    rdoLevelPro,
            //    rdoLevelHacker,
            //    rdoLevelGod
            //};
            //RadioButton aActivar = rdos[(int)p.Level];
            //aActivar.IsChecked = true;


            // Versió 3: dictionary 
            Dictionary<Level, RadioButton> rdos = new Dictionary<Level, RadioButton>() {
                { Level.NOOB,       rdoLevelNoob },
                { Level.AVERAGE,    rdoLevelAverage },
                { Level.PRO,        rdoLevelPro },
                { Level.HACKER,     rdoLevelHacker },
                { Level.GOD,        rdoLevelGod },
            };
            rdos[p.Level].IsChecked=true;
        }

        private void rdoLevelNoob_Checked(object sender, RoutedEventArgs e)
        {
            ((Persona)lsvPersones.SelectedItem).Level = Level.NOOB;
        }

        private void rdoLevelAverage_Checked(object sender, RoutedEventArgs e)
        {
            ((Persona)lsvPersones.SelectedItem).Level = Level.AVERAGE;
        }

        private void rdoLevelPro_Checked(object sender, RoutedEventArgs e)
        {
            ((Persona)lsvPersones.SelectedItem).Level = Level.PRO;
        }

        private void rdoLevelHacker_Checked(object sender, RoutedEventArgs e)
        {
            ((Persona)lsvPersones.SelectedItem).Level = Level.HACKER;
        }

        private void rdoLevelGod_Checked(object sender, RoutedEventArgs e)
        {
            ((Persona)lsvPersones.SelectedItem).Level = Level.GOD;
        }
    }
}
