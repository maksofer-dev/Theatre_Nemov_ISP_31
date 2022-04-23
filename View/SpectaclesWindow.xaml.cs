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
    /// Логика взаимодействия для SpectaclesWindow.xaml
    /// </summary>
    public partial class SpectaclesWindow : Window
    {
        public SpectaclesWindow()
        {
            InitializeComponent();
            dGridSpectacles.ItemsSource = TheatreEntities.GetContext().Spectacles.ToList();

        }

        private void spectaclesBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            spectaclesWindow.Hide();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSpectacleWindow addSpectacleWindow = new AddSpectacleWindow(null);
            addSpectacleWindow.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddSpectacleWindow addSpectacleWindow = new AddSpectacleWindow((sender as Button).DataContext as Spectacle);
            addSpectacleWindow.Show();

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TheatreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dGridSpectacles.ItemsSource = TheatreEntities.GetContext().Spectacles.ToList();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var spectacleForRemoving = dGridSpectacles.SelectedItems.Cast<Spectacle>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {spectacleForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TheatreEntities.GetContext().Spectacles.RemoveRange(spectacleForRemoving);
                    TheatreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dGridSpectacles.ItemsSource = TheatreEntities.GetContext().Spectacles.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
