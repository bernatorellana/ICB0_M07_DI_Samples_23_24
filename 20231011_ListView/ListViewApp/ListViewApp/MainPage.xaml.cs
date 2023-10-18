using ListViewApp.Model;
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

namespace ListViewApp
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
            lsvPersones.ItemsSource = Persona.getPersones();
        }

        private void lsvPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filSeleccionada.LaPersona = lsvPersones.SelectedItem as Persona;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Persona.getPersones().Remove(lsvPersones.SelectedItem as Persona);
            Persona.getPersones().RemoveAt(lsvPersones.SelectedIndex);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Persona p0 = new Persona(666, "Jhon Devil", 99);
            Persona.getPersones().Add(p0);
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
