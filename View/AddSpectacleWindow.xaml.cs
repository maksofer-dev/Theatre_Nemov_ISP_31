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
using System.Windows.Shapes;

namespace Theatre_Nemov_ISP_31.View
{
    /// <summary>
    /// Логика взаимодействия для AddSpectacleWindow.xaml
    /// </summary>
    public partial class AddSpectacleWindow : Window
    {
        private Spectacle spectacle = new Spectacle();
        public AddSpectacleWindow(Spectacle selectedSpectacle)
        {

            InitializeComponent();
            if (selectedSpectacle != null)
                spectacle = selectedSpectacle;

            

            DataContext = spectacle;
            genreComboBox.ItemsSource = TheatreEntities.GetContext().Genres.ToList();
            actorComboBox.ItemsSource = TheatreEntities.GetContext().Actors.ToList();
        }

        private void addSpectacleBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(spectacle.NameOfSpectacle))
                errors.AppendLine("Укажите название спектакля");
            if (spectacle.Genre == null)
                errors.AppendLine("Укажите Жанр");
            if (spectacle.Actor == null)
                errors.AppendLine("Укажите актера");
            if (spectacle.Budget == null)
                errors.AppendLine("Укажите бюджет");
            if (spectacle.Time == null)
                errors.AppendLine("Укажите название спектакля");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (spectacle.id == 0)
            {
                TheatreEntities.GetContext().Spectacles.Add(spectacle);
            }
            try
            {
                TheatreEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                addSpectacleWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(timePicker.SelectedTime != null)
            {
                string t = timePicker.Text.ToString();
                string d = datePicker.Text;
                DateTime dt = DateTime.Parse(d +" "+ t);
                spectacle.Time = dt;
            }
        }
    }
}
