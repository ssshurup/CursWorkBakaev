using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CursWork.Pages;

namespace CursWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        public UserP()
        {
            InitializeComponent();
            ItemListDG.ItemsSource = App.DB.films.ToList();

        }


        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = ItemListDG.SelectedItem as films;
            if (selectedItem == null)
            {
                MessageBox.Show("Выберите пожалуйста хоть что-то :)");
                return;
            }
            NavigationService.Navigate(new EditP(selectedItem));
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());

        }

        private void AllBT_Click(object sender, RoutedEventArgs e)
        {
            ItemListDG.ItemsSource = App.DB.films.ToList();
        }

        private void DrammBT_Click(object sender, RoutedEventArgs e)
        {
            ItemListDG.ItemsSource = App.DB.films.ToList().Where(x => x.idGenre == 1);
        }

        private void CrimeBT_Click(object sender, RoutedEventArgs e)
        {
            ItemListDG.ItemsSource = App.DB.films.ToList().Where(x => x.idGenre == 3);
        }

        private void FantasyBT_Click(object sender, RoutedEventArgs e)
        {
            ItemListDG.ItemsSource = App.DB.films.ToList().Where(x => x.idGenre == 2);

        }

        
    }
}
