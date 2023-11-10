using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace AppUserControlMusicLib.View
{
    public sealed partial class UIVolume : UserControl
    {

        double angleReserva;
        double angle;


        public event EventHandler OnValorChanged; 

        public UIVolume()
        {
            this.InitializeComponent();

        }



        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(UIVolume), new PropertyMetadata(0,ValueChangedCallbackStatic));

        private static void ValueChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIVolume ui = d as UIVolume;
            ui.ValueChangedCallback(e);
        }

        private void ValueChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            UserControl_Loaded(null, null);
            OnValorChanged?.Invoke(this, new EventArgs());
        }

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(UIVolume), new PropertyMetadata(0));




        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(UIVolume), new PropertyMetadata(100));




        public int Step
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Step.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(UIVolume), new PropertyMetadata(20));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Netejar TOTS els fills
            cnv.Children.Clear();


            // Inicialitzem l'angle base
            angleReserva = 50;
            angle = 90 - angleReserva * 0.5;

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/button.png"));
            

            double dimension = Math.Min(this.Width, this.Height);
            image.Width = dimension * 0.7;
            image.Height = dimension * 0.7;
            Canvas.SetTop(image, this.Height * 0.5 - image.Height * 0.5);
            Canvas.SetLeft(image, this.Width * 0.5 - image.Width * 0.5);
            cnv.Children.Add(image);

            CompositeTransform ct3 = new CompositeTransform();
            ct3.CenterX = image.Width * 0.5;
            ct3.CenterY = image.Height * 0.5;
            

            // Quan canvia el valor, estaré aquí !!!!!! 
            double angleDisponible = 360 - angleReserva;
            double proporcio = (Valor - Min) / (double)(Max - Min);
            double angleAGirar = proporcio * angleDisponible;
            double angleTotal = angle - angleAGirar;
            ct3.Rotation = angleTotal;
            image.RenderTransform = ct3;

            //===================================================
            double midaLletra = 30;

            int passos = (Max - Min) / Step;
            double pasAngular = angleDisponible / passos;

           
            for (int i=Min;i<=Max; i+=Step) { 
                Canvas c = new Canvas();
                c.Width = midaLletra;
                c.Height = midaLletra;
                Canvas.SetLeft(c, this.Width*0.5 + image.Width * 0.5);
                Canvas.SetTop(c, this.Height*0.5 - midaLletra * 0.5);
                CompositeTransform ct = new CompositeTransform();
                ct.CenterX = -image.Width*0.5;
                ct.CenterY = midaLletra * 0.5;
                ct.Rotation = angle;
                angle -= pasAngular;
                c.RenderTransform = ct;



                //*************************************************
                TextBlock t = new TextBlock();
                t.FontSize = 15;
                t.FontWeight = FontWeights.Bold;
                t.Width = midaLletra;
                t.Height = midaLletra;
                t.Text = ""+i;
                t.Foreground = new SolidColorBrush(Colors.White);
                t.TextAlignment = TextAlignment.Center;
                c.Children.Add(t);
                cnv.Children.Add(c);
                t.Tapped += T_Tapped;

                CompositeTransform ct2 = new CompositeTransform();
                ct2.CenterX = midaLletra * 0.5;
                ct2.CenterY = midaLletra * 0.5;
                ct2.Rotation = -ct.Rotation;
                t.RenderTransform = ct2;
               
            }

            /*
            <Image Source="Assets/button.png" Width="100" Height="100">
                <Image.RenderTransform>
                    <CompositeTransform Rotation="180" CenterX="50" CenterY="50"></CompositeTransform>
                </Image.RenderTransform>
            </Image>
            <Canvas Canvas.Top="35" Canvas.Left="100" Height="30" Width="30">
                <TextBlock Foreground="White" FontSize="20" FontWeight="Bold"
                        Height="30" Width="30" 
                       TextAlignment="Center" Text="4">
                    <TextBlock.RenderTransform>
                        <CompositeTransform Rotation="-50" CenterX="15" CenterY="15"></CompositeTransform>
                    </TextBlock.RenderTransform>
                </TextBlock>
                <Canvas.RenderTransform>
                    <CompositeTransform Rotation="50" CenterY="15" CenterX="-50"></CompositeTransform>
                </Canvas.RenderTransform>
            </Canvas>
       
             * 
             * 
             */
        }

        private void T_Tapped(object sender, TappedRoutedEventArgs e)
        {   
            Valor = Int32.Parse((sender as TextBlock).Text);
        }
    }
}
