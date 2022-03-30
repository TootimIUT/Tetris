using projet_tetris.view_model;
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

namespace projet_tetris.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Tetris : Window
    {
        public Tetris()
        {
            //InitializeComponent();
            this.DataContext = new ViewModel();
            ViewModel tetrisContext = (ViewModel)this.DataContext;

            Rectangle rect = new Rectangle();
            rect.Fill = Brushes.Green;
            Grid.SetColumn(rect, 5);
            Grid.SetRow(rect, 5);
            tetrisGrid.Children.Add(rect);
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Classement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
