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
            t.IsBackground = true;
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
                if (currentShape.square1[1] - 1 > -1 && currentShape.square2[1] - 1 > -1 && currentShape.square3[1] - 1 > -1 && currentShape.square4[1] - 1 > -1)
                {
                    moveShape(currentShape, "left");
                }
            }
            if (e.Key == Key.Right)
            {
                if (currentShape.square1[1] + 1 < 10 && currentShape.square2[1] + 1 < 10 && currentShape.square3[1] + 1 < 10 && currentShape.square4[1] + 1 < 10)
                {
                    moveShape(currentShape, "right");
                }
            }
            if (e.Key == Key.Down)
            {
                if (currentShape.square1[0] < 19 && currentShape.square2[0] < 19 && currentShape.square3[0] < 19 && currentShape.square4[0] < 19 && board[currentShape.square1[0] + 1, currentShape.square1[1]] == 0 && board[currentShape.square2[0] + 1, currentShape.square2[1]] == 0 && board[currentShape.square3[0] + 1, currentShape.square3[1]] == 0 && board[currentShape.square4[0] + 1, currentShape.square4[1]] == 0)
                {
                    moveShape(currentShape, "down");
                }


            }
            if (e.Key == Key.Up)
            {
                moveShape(currentShape, "up");
            }


        }

        public void moveShape(ShapePlayer shape, string move)
        {
            switch (move)
            {
                case "left":
                    if (board[currentShape.square1[0], currentShape.square1[1] - 1] == 0 && board[currentShape.square2[0], currentShape.square2[1] - 1] == 0 && board[currentShape.square3[0], currentShape.square3[1] - 1] == 0 && board[currentShape.square4[0], currentShape.square4[1] - 1] == 0)
                    {
                        shape.square1[1] = shape.square1[1] - 1;
                        shape.square2[1] = shape.square2[1] - 1;
                        shape.square3[1] = shape.square3[1] - 1;
                        shape.square4[1] = shape.square4[1] - 1;
                    }

                    break;
                case "right":
                    if (board[currentShape.square1[0], currentShape.square1[1] + 1] == 0 && board[currentShape.square2[0], currentShape.square2[1] + 1] == 0 && board[currentShape.square3[0], currentShape.square3[1] + 1] == 0 && board[currentShape.square4[0], currentShape.square4[1] + 1] == 0)
                    {
                        shape.square1[1] = shape.square1[1] + 1;
                        shape.square2[1] = shape.square2[1] + 1;
                        shape.square3[1] = shape.square3[1] + 1;
                        shape.square4[1] = shape.square4[1] + 1;
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
                        shape.square1[0] = shape.square1[0] + 1;
                        shape.square2[0] = shape.square2[0] + 1;
                        shape.square3[0] = shape.square3[0] + 1;
                        shape.square4[0] = shape.square4[0] + 1;
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
            shape.rotateShape(board);
        }

        public void autoFalling()
        {
            do
            {
                synchronize(() =>
                {
                    checkCollide(currentShape);
                    moveShape(currentShape, "down");
                    checkIfLineFull();

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

        public void checkIfLineFull()
        {
            int nbSquareInLine = 0;

            for (int i = 0; i < tetrisGrid.RowDefinitions.Count; i++)
            {
                nbSquareInLine = 0;
                for (int j = 0; j < tetrisGrid.ColumnDefinitions.Count; j++)
                {
                    if (board[i, j] == 1)
                    {
                        nbSquareInLine++;

                    }
                }
                if (nbSquareInLine == 10)
                {
                    for (int x = tetrisGrid.Children.Count - 1; x >= 0; x--)
                    {
                        if (Grid.GetRow(tetrisGrid.Children[x]) == i)
                        {
                            tetrisGrid.Children.Remove(tetrisGrid.Children[x]);
                            
                        }
                    }
                    for (int k = 0; k < nbSquareInLine; k++)
                    {
                        board[i, k] = 0;
                    }

                    for (int x = 0; x < tetrisGrid.Children.Count; x++)
                    {
                        if (Grid.GetRow(tetrisGrid.Children[x]) < i)
                        {
                            Grid.SetRow(tetrisGrid.Children[x], Grid.GetRow(tetrisGrid.Children[x]) + 1);

                        }
                    }
                    for(int p = i; p >= 0; p--)
                    {
                        for (int j = 0; j < nbSquareInLine; j++)
                        {
                            if (board[p,j] == 1)
                            {
                                board[p,j] = 0;
                                board[p+1, j] = 1;
                                

                            }
                        }
                        
                    }


                    /*MessageBox.Show(board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " | " + board[0, 3] + " | " + board[0, 4] + " | " + board[0, 5] + " | " + board[0, 6] + " | " + board[0, 7] + " | " + board[0, 8] + " | " + board[0, 9] + "\n" +
                                           board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " | " + board[1, 3] + " | " + board[1, 4] + " | " + board[1, 5] + " | " + board[1, 6] + " | " + board[1, 7] + " | " + board[1, 8] + " | " + board[1, 9] + "\n" +
                                           board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " | " + board[2, 3] + " | " + board[2, 4] + " | " + board[2, 5] + " | " + board[2, 6] + " | " + board[2, 7] + " | " + board[2, 8] + " | " + board[2, 9] + "\n" +
                                           board[3, 0] + " | " + board[3, 1] + " | " + board[3, 2] + " | " + board[3, 3] + " | " + board[3, 4] + " | " + board[3, 5] + " | " + board[3, 6] + " | " + board[3, 7] + " | " + board[3, 8] + " | " + board[3, 9] + "\n" +
                                           board[4, 0] + " | " + board[4, 1] + " | " + board[4, 2] + " | " + board[4, 3] + " | " + board[4, 4] + " | " + board[4, 5] + " | " + board[4, 6] + " | " + board[4, 7] + " | " + board[4, 8] + " | " + board[4, 9] + "\n" +
                                           board[5, 0] + " | " + board[5, 1] + " | " + board[5, 2] + " | " + board[5, 3] + " | " + board[5, 4] + " | " + board[5, 5] + " | " + board[5, 6] + " | " + board[5, 7] + " | " + board[5, 8] + " | " + board[5, 9] + "\n" +
                                           board[6, 0] + " | " + board[6, 1] + " | " + board[6, 2] + " | " + board[6, 3] + " | " + board[6, 4] + " | " + board[6, 5] + " | " + board[6, 6] + " | " + board[6, 7] + " | " + board[6, 8] + " | " + board[6, 9] + "\n" +
                                           board[7, 0] + " | " + board[7, 1] + " | " + board[7, 2] + " | " + board[7, 3] + " | " + board[7, 4] + " | " + board[7, 5] + " | " + board[7, 6] + " | " + board[7, 7] + " | " + board[7, 8] + " | " + board[7, 9] + "\n" +
                                           board[8, 0] + " | " + board[8, 1] + " | " + board[8, 2] + " | " + board[8, 3] + " | " + board[8, 4] + " | " + board[8, 5] + " | " + board[8, 6] + " | " + board[8, 7] + " | " + board[8, 8] + " | " + board[8, 9] + "\n" +
                                           board[9, 0] + " | " + board[9, 1] + " | " + board[9, 2] + " | " + board[9, 3] + " | " + board[9, 4] + " | " + board[9, 5] + " | " + board[9, 6] + " | " + board[9, 7] + " | " + board[9, 8] + " | " + board[9, 9] + "\n" +
                                           board[10, 0] + " | " + board[10, 1] + " | " + board[10, 2] + " | " + board[10, 3] + " | " + board[10, 4] + " | " + board[10, 5] + " | " + board[10, 6] + " | " + board[10, 7] + " | " + board[10, 8] + " | " + board[10, 9] + "\n" +
                                           board[11, 0] + " | " + board[11, 1] + " | " + board[11, 2] + " | " + board[11, 3] + " | " + board[11, 4] + " | " + board[11, 5] + " | " + board[11, 6] + " | " + board[11, 7] + " | " + board[11, 8] + " | " + board[11, 9] + "\n" +
                                           board[12, 0] + " | " + board[12, 1] + " | " + board[12, 2] + " | " + board[12, 3] + " | " + board[12, 4] + " | " + board[12, 5] + " | " + board[12, 6] + " | " + board[12, 7] + " | " + board[12, 8] + " | " + board[12, 9] + "\n" +
                                           board[13, 0] + " | " + board[13, 1] + " | " + board[13, 2] + " | " + board[13, 3] + " | " + board[13, 4] + " | " + board[13, 5] + " | " + board[13, 6] + " | " + board[13, 7] + " | " + board[13, 8] + " | " + board[13, 9] + "\n" +
                                           board[14, 0] + " | " + board[14, 1] + " | " + board[14, 2] + " | " + board[14, 3] + " | " + board[14, 4] + " | " + board[14, 5] + " | " + board[14, 6] + " | " + board[14, 7] + " | " + board[14, 8] + " | " + board[14, 9] + "\n" +
                                           board[15, 0] + " | " + board[15, 1] + " | " + board[15, 2] + " | " + board[15, 3] + " | " + board[15, 4] + " | " + board[15, 5] + " | " + board[15, 6] + " | " + board[15, 7] + " | " + board[15, 8] + " | " + board[15, 9] + "\n" +
                                           board[16, 0] + " | " + board[16, 1] + " | " + board[16, 2] + " | " + board[16, 3] + " | " + board[16, 4] + " | " + board[16, 5] + " | " + board[16, 6] + " | " + board[16, 7] + " | " + board[16, 8] + " | " + board[16, 9] + "\n" +
                                           board[17, 0] + " | " + board[17, 1] + " | " + board[17, 2] + " | " + board[17, 3] + " | " + board[17, 4] + " | " + board[17, 5] + " | " + board[17, 6] + " | " + board[17, 7] + " | " + board[17, 8] + " | " + board[17, 9] + "\n" +
                                           board[18, 0] + " | " + board[18, 1] + " | " + board[18, 2] + " | " + board[18, 3] + " | " + board[18, 4] + " | " + board[18, 5] + " | " + board[18, 6] + " | " + board[18, 7] + " | " + board[18, 8] + " | " + board[18, 9] + "\n" +
                                           board[19, 0] + " | " + board[19, 1] + " | " + board[19, 2] + " | " + board[19, 3] + " | " + board[19, 4] + " | " + board[19, 5] + " | " + board[19, 6] + " | " + board[19, 7] + " | " + board[19, 8] + " | " + board[19, 9]);*/
                }


            }
        }
    }


}

