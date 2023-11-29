using AppDataGrid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppDataGrid
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
        public class GroupInfoCollection<T> : ObservableCollection<T>
        {
            public object Key { get; set; }

            public new IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)base.GetEnumerator();
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //dtgHeroes.ItemsSource = Hero.GetListOfHeroes();

            ObservableCollection<GroupInfoCollection<Hero>>
                heroGroups = new ObservableCollection<GroupInfoCollection<Hero>>();
            var query = from hero in Hero.GetListOfHeroes()
                        group hero by hero.Team into g
                        select new { GroupName = g.Key, Items = g };
            foreach (var g in query) {
                GroupInfoCollection<Hero> heroGroup = new GroupInfoCollection<Hero>();
                heroGroup.Key = g.GroupName;
                foreach(var h in g.Items)
                {
                    heroGroup.Add(h);
                }
                heroGroups.Add(heroGroup);
            }

            //Create the CollectionViewSource  and set to grouped collection
            CollectionViewSource groupedItems = new CollectionViewSource();
            groupedItems.IsSourceGrouped = true;
            groupedItems.Source = heroGroups;

            // Connectem la collectionviewsource al datagrid.
            dtgHeroes.ItemsSource = groupedItems.View;
        }

        private void dtgHeroes_LoadingRowGroup(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            Hero item = group.GroupItems[0] as Hero;
            e.RowGroupHeader.PropertyValue = item.Team.Name;
        }
    }
}
