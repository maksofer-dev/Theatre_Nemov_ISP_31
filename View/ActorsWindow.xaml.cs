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
    /// Логика взаимодействия для ActorsWindow.xaml
    /// </summary>
    public partial class ActorsWindow : Window
    {
        public ActorsWindow()
        {
            InitializeComponent();
            dGridActors.ItemsSource = TheatreEntities.GetContext().Actors.ToList();
        }

        private void actorsBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
            actorsWindow.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddActorWindow addActorWindow = new AddActorWindow(null);
            addActorWindow.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            AddActorWindow addActorWindow = new AddActorWindow(null);
            addActorWindow.Show();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TheatreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dGridActors.ItemsSource = TheatreEntities.GetContext().Actors.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddActorWindow addActorWindow = new AddActorWindow((sender as Button).DataContext as Actor);
            addActorWindow.Show(); 
        }
    }
}
