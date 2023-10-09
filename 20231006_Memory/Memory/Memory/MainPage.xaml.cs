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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Memory
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const int FILES = 4;
        const int COLUMNES = 5;
        const int CARTES = (int)(FILES*COLUMNES*0.5);
        int[,] cartes = new int[FILES,COLUMNES];
        int punts = 0;
        List<Image> cartesSeleccionades = new List<Image>();
        Boolean finalPartida = false;
        Boolean enEspera = false;

        //   codicarta,# vegades posada
        Dictionary<int, int> cartesColocades = new Dictionary<int, int>();
        private void incialitzaTauler()
        {
            Random r = new Random();
            for(int i=0;i<CARTES;i++)
            {
                cartesColocades[i] = 0;
            }
            int f = 0, c = 0;
            while (cartesColocades.Keys.Count > 0)
            {
                int idx = r.Next(cartesColocades.Keys.Count);
                int codiCarta = cartesColocades.Keys.ToList()[idx];
                cartes[f, c] = codiCarta;
                cartesColocades[codiCarta]++;
                if (cartesColocades[codiCarta] == 2)
                {
                    cartesColocades.Remove(codiCarta); // eliminem la carta
                }
                c++;
                if (c >= COLUMNES)
                {
                    c = 0;
                    f++;
                }
            }
            int k = 0;
        }

        public MainPage()
        {
            this.InitializeComponent();

            incialitzaTauler();

            mostraPunts();

            // Inicialitzar el grid de joc
            for (int i = 0; i < COLUMNES; i++)
            {
                ColumnDefinition c = new ColumnDefinition();
                grdMemory.ColumnDefinitions.Add(c);
            }
            for (int i = 0; i < FILES; i++)
            {
                RowDefinition c = new RowDefinition();
                grdMemory.RowDefinitions.Add(c);
            }
            for (int c = 0; c < COLUMNES; c++)
            {
                for (int f = 0; f < FILES; f++)
                {
                    //   <Image Source="/Assets/cards/i1.jpg" Grid.Row="2" Grid.Column="3"></Image>
                    
                    Image im = new Image();
                    int carta = this.cartes[f, c];
                    im.Source = new BitmapImage(new Uri($"ms-appx:///Assets/cards/i{carta}.jpg"));
                    Grid.SetColumn(im, c);
                    Grid.SetRow(im, f);
                    grdMemory.Children.Add(im);
                    //------------------------------
                    im = new Image();
                    im.Source = new BitmapImage(new Uri($"ms-appx:///Assets/cards/back.jpg"));
                    Grid.SetColumn(im, c);
                    Grid.SetRow(im, f);
                    grdMemory.Children.Add(im);
                    im.Tapped += Im_Tapped;
                    im.Tag = carta;

                }
            }


        }

        private async void Im_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!finalPartida && !enEspera )
            {
                Image image = (sender as Image);
                image.Opacity = 0;
                cartesSeleccionades.Add(image);


                if (cartesSeleccionades.Count==2)
                {
                    if(cartesSeleccionades[0].Tag.Equals(cartesSeleccionades[1].Tag))
                    {
                        punts++;
                        mostraPunts();
                        if (punts == CARTES)
                        {
                            this.finalPartida = true;
                            mostraFinalPartida();
                        }
                    } else
                    {
                        enEspera = true;
                        await Task.Delay(2000);
                        cartesSeleccionades[0].Opacity = 1;
                        cartesSeleccionades[1].Opacity = 1;
                        enEspera = false;

                    }
                    cartesSeleccionades.Clear();
                }
            }
        }

        private void mostraPunts()
        {
            txbPunts.Text = punts + "";
        }

        private void mostraFinalPartida()
        {
        }
    }
}
