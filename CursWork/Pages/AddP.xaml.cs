using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Xaml;

namespace CursWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddP.xaml
    /// </summary>
    public partial class AddP : Page
    {
        public AddP()
        {
            InitializeComponent();
            CountryCB.ItemsSource = App.DB.country.ToList();
            DirectorCB.ItemsSource = App.DB.director.ToList();
            GenreCB.ItemsSource = App.DB.genre.ToList();
        }
        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            int countP = 0;
            films film = new films();
            country couun = new country();
            director dir = new director();
            genre gen = new genre();
            //поиск id страны

            var Countr = App.DB.country.Where(a => a.name == CountryCB.Text);
            if (Countr.Any() == true)
            {
                foreach (country r in Countr)
                {
                    couun.id = r.id;
                }
            }
            else
            {
                MessageBox.Show("Enter Rarity");
                countP++;
            }

            //поиск id жанра
            var Genr = App.DB.genre.Where(a => a.name == GenreCB.Text);
            if (Genr.Any() == true)
            {
                foreach (genre g in Genr)
                {
                    gen.id = g.id;
                }
            }
            else
            {
                MessageBox.Show("Enter Rarity");
                countP++;
            }
            //поиск id режиссера
            var Dir = App.DB.director.Where(a => a.name == DirectorCB.Text);
            if (Dir.Any() == true)
            {
                foreach (director c in Dir)
                {
                   dir.id = c.id;
                }
            }
            else
            {
                MessageBox.Show("Enter Class");
                countP++;
            }

            try
            {
                film.name = NameTB.Text;
                film.idCountry = couun.id;
                film.releaseDate = DateTime.ParseExact(DateTB.Text, "yyyy-M-dd", null);
                film.idGenre = gen.id;
                film.duration = DurationTB.Text;
                film.idDirector = dir.id;
                film.description = DescriptionTB.Text;
                film.rating = Convert.ToInt32(RatingTB.Text);
                App.DB.films.Add(film);
                App.DB.SaveChanges();
                MessageBox.Show("Succes!");
            }
            catch
            {
                MessageBox.Show("Find " + countP + " error");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
    }
}
