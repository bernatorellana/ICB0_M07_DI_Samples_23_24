using ComptaParaules.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace ComptaParaules
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ComptadorParaules cp = new ComptadorParaules();
            Dictionary<string, int> paraules1 = await cp.carregaArxiuAsync("Dracula.txt");           
            Dictionary<string, int> paraules2 = await cp.carregaArxiuAsync("RomeoAndJuliet.txt");

            //var llista = paraules1.Intersect(paraules2).ToList();

            List<Parell> resultatFinal = new List<Parell>();
            foreach(var parell in paraules1)
            {
                if (paraules2.ContainsKey(parell.Key))
                {
                    int recompteConjunt = parell.Value + paraules2[parell.Key];
      
                    resultatFinal.Add(new Parell(parell.Key, recompteConjunt));
                }
            }
            lsbResultat.ItemsSource = resultatFinal;
        
        }
    }
}
