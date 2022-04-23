using Microsoft.Win32;
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
    /// Логика взаимодействия для AddActorWindow.xaml
    /// </summary>
    public partial class AddActorWindow : Window
    {
        private Actor actor = new Actor();

        public AddActorWindow(Actor selectedActor)
        {
            InitializeComponent();
            if (selectedActor != null)
                actor = selectedActor;
            

            DataContext = actor;
        }

        private void addActorBorder_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(actor.FullName))
                errors.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(actor.Education))
                errors.AppendLine("Укажите образование");
            if (string.IsNullOrWhiteSpace(actor.AwardsOrTitles))
                errors.AppendLine("Укажите награды или звания");
            if (string.IsNullOrWhiteSpace(actor.ActorIMG))
                errors.AppendLine("прикрепите изображение");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (actor.id == 0)
            {
                TheatreEntities.GetContext().Actors.Add(actor);
            }
            try
            {
                TheatreEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                addActorWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addImaage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                actor.ActorIMG = openDialog.FileName;
            }
        }
    }
}
