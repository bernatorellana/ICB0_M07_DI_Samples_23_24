using AppCollections.Model;
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

namespace AppCollections
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
            Persona p0 = new Persona(1, "Joan Busquets", 32);
            Persona p1 = new Persona(2, "Maria Gutiérrez", 36);
            Persona p2 = new Persona(3, "Pepe Saez", 34);
            Persona p3 = new Persona(4, "Joao Figueira", 75);
            Persona p4 = new Persona(5, "Ester Minator", 64);
            Persona p5 = new Persona(6, "Pere Pau", 83);

            // Creació d'una llista de persones
            List<Persona> llistaPersones = new List<Persona>();
            llistaPersones.Add(p0);
            llistaPersones.Add(p1);
            llistaPersones.Add(p2);
            llistaPersones.Add(p3);
            llistaPersones.Add(p4);
            llistaPersones.Add(p5);
            llistaPersones.Add(p5);
            llistaPersones.Add(p5);

            llistaPersones[5].Name = "SATAN";
            txbDebug.Text += llistaPersones.Count + "";
            txbDebug.Text += llistaPersones[6].Name;
            llistaPersones.Remove(p5);
            //llistaPersones.RemoveAll(p => p.Id>4);
            txbDebug.Text += llistaPersones.Count + "";
            foreach (Persona p in llistaPersones)
            {
                txbDebug.Text += $"\t - {p}\n";
            }
        }
    }
}
