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
using System.Threading;

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
        Random randomShape = new Random();
        List<ShapePlayer> shapes = new List<ShapePlayer>();
        ViewModel tetrisContext;

        int[,] board = {
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        };

        public Tetris()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            tetrisContext = (ViewModel)this.DataContext;

            changeShape();
            
                Thread t = new Thread(autoFalling);
                t.Start();
            



        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
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
            if(e.Key == Key.Up)
            {
                moveShape(currentShape, "up", 0);
            }


        }

        public void moveShape(ShapePlayer shape, string move, int coordType)
        {
            switch (move)
            {
                case "left":
                    if (shape.square1[coordType] - 1 > -1 && shape.square2[coordType] - 1 > -1 && shape.square3[coordType] - 1 > -1 && shape.square4[coordType] - 1 > -1)
                    {
                        shape.square1[coordType] = shape.square1[coordType] - 1;
                        shape.square2[coordType] = shape.square2[coordType] - 1;
                        shape.square3[coordType] = shape.square3[coordType] - 1;
                        shape.square4[coordType] = shape.square4[coordType] - 1;
                    }

                    break;
                case "right":
                    if (shape.square1[coordType] + 1 < 10 && shape.square2[coordType] + 1 < 10 && shape.square3[coordType] + 1 < 10 && shape.square4[coordType] + 1 < 10)
                    {
                        shape.square1[coordType] = shape.square1[coordType] + 1;
                        shape.square2[coordType] = shape.square2[coordType] + 1;
                        shape.square3[coordType] = shape.square3[coordType] + 1;
                        shape.square4[coordType] = shape.square4[coordType] + 1;
                    }
                    break;
                case "down":
                    if (checkIsPlaced(shape))
                    {
                        board[shape.square1[0], shape.square1[1]] = 1;
                        board[shape.square2[0], shape.square2[1]] = 1;
                        board[shape.square3[0], shape.square3[1]] = 1;
                        board[shape.square4[0], shape.square4[1]] = 1;
                        changeShape();
                    }
                    else
                    {
                        shape.square1[coordType] = shape.square1[coordType] + 1;
                        shape.square2[coordType] = shape.square2[coordType] + 1;
                        shape.square3[coordType] = shape.square3[coordType] + 1;
                        shape.square4[coordType] = shape.square4[coordType] + 1;
                    }
                    break;
                case "up":
                    rotateShape(shape);
                    break;
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

        public bool checkIsPlaced(ShapePlayer shape)
        {
            if (shape.square1[0] == 19 || shape.square2[0] == 19 || shape.square3[0] == 19 || shape.square4[0] == 19)
            {
                shape.isPlaced = true;
                return true;
            }
            else if (board[shape.square1[0] + 1, shape.square1[1]] == 1 || board[shape.square2[0] + 1, shape.square2[1]] == 1 || board[shape.square3[0] + 1, shape.square3[1]] == 1 || board[shape.square4[0] + 1, shape.square4[1]] == 1)
            {
                shape.isPlaced = true;
                return true;
            }
            return false;
        }

        public void changeShape()
        {

            generateShape();
            MessageBox.Show("Carré 1 : " + currentShape.square1[0] + " | " + currentShape.square1[1]
                + "\n Carré 2 " + currentShape.square2[0] + " | " + currentShape.square2[1]
                + "\n Carré 3 :" + currentShape.square3[0] + " | " + currentShape.square3[1]
                + "\n Carré 4 " + currentShape.square4[0] + " | " + currentShape.square4[1]);

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

        public void rotateShape(ShapePlayer shape)
        {
            shape.rotateShape();
        }

        public  void autoFalling()
        {
            do
            {
                synchronize(() =>
                {
                    checkCollide(currentShape);
                    moveShape(currentShape, "down", 0);

                });
                Thread.Sleep(1000);
            } while (currentShape.isPlaced == false);
        }

        private static void synchronize(Action a)
        {
            Application app = Application.Current;
            if (app != null && app.Dispatcher != null)
            {
                Application.Current.Dispatcher.Invoke(a);
            }
        }

        private void checkCollide(ShapePlayer shape)
        {

            if (checkIsPlaced(shape))
            {
                board[shape.square1[0], shape.square1[1]] = 1;
                board[shape.square2[0], shape.square2[1]] = 1;
                board[shape.square3[0], shape.square3[1]] = 1;
                board[shape.square4[0], shape.square4[1]] = 1;
                changeShape();
            }
            
        }

        public void generateShape()
        {
            int entier = randomShape.Next(7);
            MessageBox.Show("Forme : " + entier);
            string shapeStr = tetrisContext.shape[entier];
            ShapePlayer newShape = null;
            switch (shapeStr) 
            {
                case "JShape":
                    newShape = new JShape();
                    break;

                case "LShape":
                    newShape = new LShape();
                    break;

                case "OShape":
                    newShape = new OShape();
                    break;

                case "SShape":
                    newShape = new SShape();
                    break;

                case "StickShape":
                    newShape = new StickShape();
                    break;

                case "TShape":
                    newShape = new TShape();
                    break;

                case "ZShape":
                    newShape = new ZShape();
                    break;
            }

            shapes.Add(newShape);

            currentShape = shapes[shapes.Count - 1];
        }

        private void Classement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}

