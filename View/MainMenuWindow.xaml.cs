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
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void mainMenuBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void actorsBtn_Click(object sender, RoutedEventArgs e)
        {
            ActorsWindow actorsWindow = new ActorsWindow();
            actorsWindow.Show();
            mainMenuWindow.Close();
        }

        private void spectaclesBtn_Click(object sender, RoutedEventArgs e)
        {
            SpectaclesWindow spectaclesWindow = new SpectaclesWindow(); 
            spectaclesWindow.Show();
            mainMenuWindow.Close();
        }
    }
}
