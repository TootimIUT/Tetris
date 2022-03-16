using projet_tetris.model;
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
using System.Windows.Navigation;

namespace projet_tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ViewModel tetrisContext = (ViewModel)this.DataContext;



            Binding printBinding = new Binding();
            printBinding.Source = tetrisContext;
            printBinding.Path = new PropertyPath("Matrix");
            printBinding.Mode = BindingMode.TwoWay;
            printBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            BindingOperations.SetBinding(matrix, TextBlock.TextProperty, printBinding);

        }

    }
}
