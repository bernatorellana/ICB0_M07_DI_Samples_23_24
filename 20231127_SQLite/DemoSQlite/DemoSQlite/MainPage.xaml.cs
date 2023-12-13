﻿using DBLib;
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

namespace DemoSQlite
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
            launchQuery();
            cboCap.DisplayMemberPath = "Cognom";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            launchQuery();
        }

        private void launchQuery()
        {

            DateTime? dt = null;
            dt = dtpDate.SelectedDate?.Date;
            dtgEmpleats.ItemsSource = DBEmpleat.getEmpleats(txbCognom.Text, dt );
            // Ara fem el recompte d'empleats
            long numEmpleats = DBEmpleat.getNumeroEmpleats(txbCognom.Text, dt );
            txbNumEmpleats.Text = numEmpleats.ToString();

      
            
        }
   
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dtpDate.SelectedDate=null;
        }



        //public DBEmpleat EmpleatSeleccionat{ get; set; }



        public DBEmpleat EmpleatSeleccionat
        {
            get { return (DBEmpleat)GetValue(EmpleatSeleccionatProperty); }
            set { SetValue(EmpleatSeleccionatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmpleatSeleccionat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpleatSeleccionatProperty =
            DependencyProperty.Register("EmpleatSeleccionat", typeof(DBEmpleat), typeof(MainPage), 
                new PropertyMetadata(new DBEmpleat(0,"","",0,DateTime.Now,0,0,0)));



        private void dtgEmpleats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgEmpleats.SelectedItem != null)
            {
                DBEmpleat em = (DBEmpleat)dtgEmpleats.SelectedItem;
                EmpleatSeleccionat = new DBEmpleat(em);

                /*List<DBEmpleat> possiblesCaps = DBEmpleat.getEmpleats();
                possiblesCaps.Remove(em);
                List<DBEmpleat> possiblesCapsActuals = (List<DBEmpleat>) cboCap.ItemsSource;
                // No reemplacem el ItemSource del combobox per no trencar el binding.
                // Per contra, buidem la llista i la tornem a omplir per mantenir l'ús del 
                // mateix punter.
                possiblesCapsActuals.Clear();
                possiblesCapsActuals.AddRange(possiblesCaps);*/


                //SelectedValue="{Binding ElementName=pageMain,Path=EmpleatSeleccionat.Cap,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"


                cboCap.ItemsSource = DBEmpleat.getEmpleats();
                // Binding dinàmic, en comptes de fer-ho al XAML ho fem al codi
                // per poder canviar el ItemSource
                Binding binding = new Binding() { ElementName="pageMain",
                                                Path = new PropertyPath("EmpleatSeleccionat.Cap"),
                                                Mode=BindingMode.TwoWay, 
                                                UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged};
                cboCap.SetBinding(ComboBox.SelectedValueProperty, binding);


            }
        }
    }
}
