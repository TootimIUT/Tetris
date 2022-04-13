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
using System.Windows.Shapes;

namespace projet_tetris.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Tetris : Window
    {

        ShapePlayer currentShape;
        Rectangle rect1;
        Rectangle rect2;
        Rectangle rect3;
        Rectangle rect4;

        public Tetris()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ViewModel tetrisContext = (ViewModel)this.DataContext;

            int j = 0;
            List<ShapePlayer> shapes = new List<ShapePlayer>();
            do
            {
                shapes.Add(tetrisContext.shape[0]);
                
                Random randomShape = new Random();
                tetrisContext.shape = tetrisContext.shape.OrderBy(x => randomShape.Next()).ToArray();
                currentShape = shapes[shapes.Count-1];
                System.Threading.Thread.Sleep(100);
                j++;

            } while (j < 4);



            rect1 = new Rectangle();
            rect1.Fill = currentShape.color;
            Grid.SetColumn(rect1, currentShape.square1[1]);
            Grid.SetRow(rect1, currentShape.square1[0]);
            rect2 = new Rectangle();
            rect2.Fill = currentShape.color;
            Grid.SetColumn(rect2, currentShape.square2[1]);
            Grid.SetRow(rect2, currentShape.square2[0]);
            rect3 = new Rectangle();
            rect3.Fill = currentShape.color;
            Grid.SetColumn(rect3, currentShape.square3[1]);
            Grid.SetRow(rect3, currentShape.square3[0]);
            rect4 = new Rectangle();
            rect4.Fill = currentShape.color;
            Grid.SetColumn(rect4, currentShape.square4[1]);
            Grid.SetRow(rect4, currentShape.square4[0]);


            tetrisGrid.Children.Add(rect1);
            tetrisGrid.Children.Add(rect2);
            tetrisGrid.Children.Add(rect3);
            tetrisGrid.Children.Add(rect4);

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void moveShape(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Left)
            {
                moveShape(currentShape, "left", 1);
            }
            if (e.Key == Key.Right)
            {
                moveShape(currentShape, "right", 1);
            }
            if (e.Key == Key.Down)
            {
                moveShape(currentShape, "down", 0);
            }

            Grid.SetColumn(rect1, currentShape.square1[1]);
            Grid.SetRow(rect1, currentShape.square1[0]);

            Grid.SetColumn(rect2, currentShape.square2[1]);
            Grid.SetRow(rect2, currentShape.square2[0]);

            Grid.SetColumn(rect3, currentShape.square3[1]);
            Grid.SetRow(rect3, currentShape.square3[0]);

            Grid.SetColumn(rect4, currentShape.square4[1]);
            Grid.SetRow(rect4, currentShape.square4[0]);
        }

        public void moveShape(ShapePlayer shape, string move, int coordType)
        {
            switch (move)
            {
                case "left":
                    if(currentShape.square1[coordType] - 1 > -1 && currentShape.square2[coordType] - 1 > -1 && currentShape.square3[coordType] - 1 > -1 && currentShape.square4[coordType] - 1 > -1)
                    {
                        currentShape.square1[coordType] = currentShape.square1[coordType] - 1;
                        currentShape.square2[coordType] = currentShape.square2[coordType] - 1;
                        currentShape.square3[coordType] = currentShape.square3[coordType] - 1;
                        currentShape.square4[coordType] = currentShape.square4[coordType] - 1;
                    }
                        break;
                case "right":
                    if (currentShape.square1[coordType] + 1 < 10 && currentShape.square2[coordType] + 1 < 10 && currentShape.square3[coordType] + 1 < 10 && currentShape.square4[coordType] + 1 < 10)
                    {
                        currentShape.square1[coordType] = currentShape.square1[coordType] + 1;
                        currentShape.square2[coordType] = currentShape.square2[coordType] + 1;
                        currentShape.square3[coordType] = currentShape.square3[coordType] + 1;
                        currentShape.square4[coordType] = currentShape.square4[coordType] + 1;
                    }
                    break;
                case "down":
                    if (currentShape.square1[coordType] + 1 < 20 && currentShape.square2[coordType] + 1 < 20 && currentShape.square3[coordType] + 1 < 20 && currentShape.square4[coordType] + 1 < 20)
                    {
                        currentShape.square1[coordType] = currentShape.square1[coordType] + 1;
                        currentShape.square2[coordType] = currentShape.square2[coordType] + 1;
                        currentShape.square3[coordType] = currentShape.square3[coordType] + 1;
                        currentShape.square4[coordType] = currentShape.square4[coordType] + 1;
                    }
                    break;

            }
            
        }


    }
}
