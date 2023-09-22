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
        private List<Persona> llistaPersones;
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
            llistaPersones = new List<Persona>();
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
            List<Persona> filtrada = llistaPersones.Where(p => p.Id >= 4).ToList();
            foreach (Persona p in filtrada)
            {
                txbDebug.Text += $"\t - {p}\n";
            }
            txbDebug.Text += ">>"+llistaPersones.Max(p => p.Id) + "\n" ;

            int index = llistaPersones.IndexOf(p5);
            txbDebug.Text += index + "\n";
            Persona p5bis = new Persona(6, "Pere Pau", 83);
            llistaPersones.Remove(p5bis);

            index = llistaPersones.IndexOf(p5bis);
            txbDebug.Text += index + "\n";

            lsb1.ItemsSource = llistaPersones;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String nomAInserir = txbNew.Text;
            Boolean esPotInserir = true;
            esPotInserir = this.esPotInserir();
            long maxId = llistaPersones.Max(p => p.Id);

            if (esPotInserir)
            {
                Persona p = new Persona(maxId + 1, nomAInserir, 0);
                llistaPersones.Add(p);
                lsb1.ItemsSource = null;
                lsb1.ItemsSource = llistaPersones;
                txbNew.Text = "";
            }
        }

        private bool esPotInserir()
        {
            /*long maxId = -1;
            for(int i = 0; esPotInserir && i < llistaPersones.Count; i++)
            {
                if (llistaPersones[i].Id > maxId)
                {
                    maxId = llistaPersones[i].Id;
                }
                if (llistaPersones[i].Name == nomAInserir)
                {
                    esPotInserir = false;
                }
            }*/
            return llistaPersones.Where(
                        p => p.Name == txbNew.Text
                    ).Count() == 0;
        }

        private void txbNew_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAdd.IsEnabled = esPotInserir();
        }
    }
}
