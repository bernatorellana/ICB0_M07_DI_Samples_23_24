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

namespace NavigationView
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(PageA));
        }

        private void NavigationView_ItemInvoked(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            String opcio = ((string)args.InvokedItem);
            if (opcio.Equals(nviOpcioA.Content))
            {
                ContentFrame.Navigate(typeof(PageA));
            } else if (opcio.Equals(nviOpcioB.Content))
            {
                ContentFrame.Navigate(typeof(PageB));
            }
        }
    }
}
