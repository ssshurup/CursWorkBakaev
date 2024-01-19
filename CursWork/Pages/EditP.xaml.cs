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

namespace CursWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditP.xaml
    /// </summary>
    public partial class EditP : Page
    {
        films contextFilm;
        public EditP(films film)
        {
            InitializeComponent();
            contextFilm = film;
            DataContext = contextFilm;
            CountryCB.ItemsSource = App.DB.country.ToList();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            DirectorCB.ItemsSource = App.DB.director.ToList();
            //RareCB.ItemsSource = App.DB.rarity.ToList();
            //ClassCB.ItemsSource = App.DB.classC.ToList();
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            if (contextFilm.id == 0)
                App.DB.films.Add(contextFilm);
            App.DB.SaveChanges();
            NavigationService.Navigate(new UserP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
    }
}
