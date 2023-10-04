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
        private Dictionary<Level, RadioButton> radiosLevel; 

        public MainPage()
        {
            this.InitializeComponent();

            radiosLevel = new Dictionary<Level, RadioButton>();
            // Crear la llista de radiobuttons del nivell
            foreach (Level l in Enum.GetValues(typeof(Level)))
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content=l.ToString();
                stkRadiosLevel.Children.Add(radioButton);
                radiosLevel[l] = radioButton;
                radioButton.Tag = l;
                // Programar els events del RadioButton
                radioButton.Checked += RadioButton_Checked;
                
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Persona p = lsvPersones.SelectedItem as Persona;
            p.Level = (Level) rb.Tag;           
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
            radiosLevel[p.Level].IsChecked = true;
        }

    }
}
