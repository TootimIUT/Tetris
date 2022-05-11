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

        public Tetris()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ViewModel tetrisContext = (ViewModel)this.DataContext;

            int j = 0;
            List<ShapePlayer> shapes = new List<ShapePlayer>();

            shapes.Add(tetrisContext.shape[0]);

            Random randomShape = new Random();
            tetrisContext.shape = tetrisContext.shape.OrderBy(x => randomShape.Next()).ToArray();
            currentShape = shapes[shapes.Count - 1];

/*            do
            {
               // shapes.Add(tetrisContext.shape[0]);
                

                /*tetrisContext.shape = tetrisContext.shape.OrderBy(x => randomShape.Next()).ToArray();
                currentShape = shapes[shapes.Count-1];
                Thread t = new Thread(new ThreadStart(autoFalling));
                t.Start();
                t.Join();
                j++;

            } while (currentShape.isPlaced == false);*/


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
            if(e.Key == Key.Up)
            {
                moveShape(currentShape, "up", 0);
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
                    if (shape.square1[coordType] + 1 < 20 && shape.square2[coordType] + 1 < 20 && shape.square3[coordType] + 1 < 20 && shape.square4[coordType] + 1 < 20)
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
        }

        public bool checkIsPlaced(ShapePlayer shape)
        {
            if (shape.square1[0] == 20 || shape.square2[0] == 20 || shape.square3[0] == 20 || shape.square4[0] == 20)
            {
                shape.isPlaced = true;
                return true;
            }
            return false;
        }

        public void changeShape(ShapePlayer shape)
        {

        }

        public void rotateShape(ShapePlayer shape)
        {
            Type t = shape.GetType();
            if (t.Equals(typeof(JShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if(shape.square2[1] < 9)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] += 1;
                            shape.square3[0]-=1;
                            shape.square3[1]-=1;
                            shape.square4[0] -= 2;
                            shape.state = 1;
                        }
                        break;

                    case 1:
                        if(shape.square2[0] < 19)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] -= 1;
                            shape.square3[0] -= 1;
                            shape.square3[1] += 1;
                            shape.square4[1] += 2; 
                            shape.state = 2;
                        }
                        break;

                    case 2:
                        if(shape.square2[1] > 0)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] -= 1;
                            shape.square3[0] += 1;
                            shape.square3[1] += 1;
                            shape.square4[0] += 2;
                            shape.state = 3;
                        }
                        break;
                    case 3:
                       
                            shape.square1[0] -= 1;
                            shape.square1[1] += 1;
                            shape.square3[0] += 1;
                            shape.square3[1] -= 1;
                            shape.square4[1] -= 2;
                            shape.state = 0;

                        break;


                }
            }
            if (t.Equals(typeof(LShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if (shape.square2[1] > 0 && shape.square1[0] < 20 && shape.square1[1] < 10)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] -= 1;

                            shape.square3[0] -= 1;
                            shape.square3[1] += 1;

                            shape.square4[0] -= 2;
                            shape.state = 1;
                        }
                        break;

                    case 1:
                        if (shape.square2[0] < 19)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] += 1;
                        
                            shape.square3[0] -= 1;
                            shape.square3[1] -= 1;
                        
                            shape.square4[1] -= 2;
                            shape.state = 2;
                        }
                        
                        break;

                    case 2:
                        if (shape.square2[1] < 9)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] += 1;
                        
                        
                            shape.square3[0] += 1;
                            shape.square3[1] -= 1;
                        
                            shape.square4[0] += 2;
                            shape.state = 3;
                        
                        }
                        break;
                    case 3:
                        if (shape.square2[0] > 0)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] -= 1;
                        
                            shape.square3[0] += 1;
                            shape.square3[1] += 1;
                        
                            shape.square4[1] += 2;
                            shape.state = 0;
                        }
                        break;


                }
            }
            if (t.Equals(typeof(SShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if(shape.square1[0] > 0)
                        {
                        shape.square1[0] -=1;
                        shape.square1[1] +=1;

                        shape.square3[0] -= 1;  
                        shape.square3[1] -=1;

                        shape.square4[1] -=2;

                        shape.state = 1;

                        }


                        break;

                    case 1:
                        if(shape.square4[1] < 8)
                        {
                        shape.square1[0] +=1;
                        shape.square1[1] -=1;

                        shape.square3[0] += 1;
                        shape.square3[1] += 1;

                        shape.square4[1] += 2;

                        shape.state = 0;
                        }
                    break;

                }

            }
            if (t.Equals(typeof(ZShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if (shape.square1[0] > 0)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] -= 1;

                            shape.square3[0] -= 1;
                            shape.square3[1] += 1;

                            shape.square4[1] += 2;
                            shape.state = 1;
                        }


                        break;

                    case 1:
                        
                        if(shape.square2[1] > 0)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] += 1;

                            shape.square3[0] += 1;
                            shape.square3[1] -= 1;

                            shape.square4[1] -= 2;

                            shape.state = 0;
                        }
                        
                        break;

                }

            }

            if (t.Equals(typeof(StickShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if(shape.square1[0] > 0 && shape.square4[0] < 18)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] += 1;

                            shape.square3[0] += 1;
                            shape.square3[1] -= 1;

                            shape.square4[0] +=2;
                            shape.square4[1] -=2;

                            shape.state = 1;
                        }
                        break;

                    case 1:
                        if(shape.square1[1] > 0 && shape.square4[1] < 8)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] -= 1;

                            shape.square3[0] -= 1;
                            shape.square3[1] += 1;

                            shape.square4[0] -= 2;
                            shape.square4[1] += 2;

                            shape.state = 0;
                        }
                        break;
                }
            }
            if (t.Equals(typeof(TShape)))
            {
                switch (shape.state)
                {
                    case 0:
                        if(shape.square2[0] > 0)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] += 1;

                            shape.square3[0] += 1;
                            shape.square3[1] -= 1;

                            shape.square4[0] -= 1;
                            shape.square4[1] -= 1;

                            shape.state = 1;
                        }
                        break;

                    case 1:
                        if (shape.square2[1] < 9)
                        {
                            shape.square1[0] += 1;
                            shape.square1[1] += 1;

                            shape.square3[0] -= 1;
                            shape.square3[1] -= 1;

                            shape.square4[0] -= 1;
                            shape.square4[1] += 1;

                            shape.state = 2;
                        }
                        break;

                    case 2:
                        if (shape.square2[0] < 19 )
                        { 
                            shape.square1[0] += 1;
                            shape.square1[1] -= 1;

                            shape.square3[0] -= 1;
                            shape.square3[1] += 1;

                            shape.square4[0] += 1;
                            shape.square4[1] += 1;

                            shape.state = 3;
                        }
                            break;
                    case 3:
                        if (shape.square2[1] > 0)
                        {
                            shape.square1[0] -= 1;
                            shape.square1[1] -= 1;

                            shape.square3[0] += 1;
                            shape.square3[1] += 1;

                            shape.square4[0] += 1;
                            shape.square4[1] -= 1;

                            shape.state = 0;
                        }
                        break;
                }
            }
        }

        public  void autoFalling()
        {
            moveShape(currentShape, "down", 0);
        }

    }


    }

