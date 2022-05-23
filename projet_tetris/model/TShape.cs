using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class TShape : ShapePlayer
    {
        public TShape()
        {
            square1 = new int[] { 0, 4 };
            square2 = new int[] { 0, 5 };
            square3 = new int[] { 0, 6 };
            square4 = new int[] { 1, 5 };
            color = Brushes.Purple;
            isPlaced = false;
            state = 0;
        }

        public override void rotateShape(int[,] board)
        {
            switch (this.state)
            {
                case 0:
                    if (this.square2[0] > 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] += 1;

                        this.square3[0] += 1;
                        this.square3[1] -= 1;

                        this.square4[0] -= 1;
                        this.square4[1] -= 1;

                        this.state = 1;
                    }
                    break;

                case 1:
                    if (this.square2[1] < 9)
                    {
                        this.square1[0] += 1;
                        this.square1[1] += 1;

                        this.square3[0] -= 1;
                        this.square3[1] -= 1;

                        this.square4[0] -= 1;
                        this.square4[1] += 1;

                        this.state = 2;
                    }
                    break;

                case 2:
                    if (this.square2[0] < 19)
                    {
                        this.square1[0] += 1;
                        this.square1[1] -= 1;

                        this.square3[0] -= 1;
                        this.square3[1] += 1;

                        this.square4[0] += 1;
                        this.square4[1] += 1;

                        this.state = 3;
                    }
                    break;
                case 3:
                    if (this.square2[1] > 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] -= 1;

                        this.square3[0] += 1;
                        this.square3[1] += 1;

                        this.square4[0] += 1;
                        this.square4[1] -= 1;

                        this.state = 0;
                    }
                    break;
            }
        }
    }
}