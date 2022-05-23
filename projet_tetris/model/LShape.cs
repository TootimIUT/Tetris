using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class LShape : ShapePlayer
    {
        public LShape()
        {
            square1 = new int[] { 0, 5 };
            square2 = new int[] { 1, 5 };
            square3 = new int[] { 2, 5 };
            square4 = new int[] { 2, 6 };
            color = Brushes.Orange;
            isPlaced = false;
            state = 0;
        }

        public override void rotateShape(int[,] board)
        {
            switch (this.state)
            {
                case 0:
                    if (this.square2[1] > 0 && this.square1[0] < 20 && this.square1[1] < 10 && board[this.square1[0] + 1, this.square1[1] - 1] == 0 && board[this.square3[0] - 1, this.square3[1] + 1] == 0 && board[this.square4[0] - 2, this.square4[1]] == 0)
                    {
                        this.square1[0] += 1;
                        this.square1[1] -= 1;

                        this.square3[0] -= 1;
                        this.square3[1] += 1;

                        this.square4[0] -= 2;
                        this.state = 1;
                    }
                    break;

                case 1:
                    if (this.square2[0] < 19 && board[this.square1[0] + 1, this.square1[1] + 1] == 0 && board[this.square3[0] - 1, this.square3[1] - 1] == 0 && board[this.square4[0], this.square4[1] - 2] == 0)
                    {
                        this.square1[0] += 1;
                        this.square1[1] += 1;

                        this.square3[0] -= 1;
                        this.square3[1] -= 1;

                        this.square4[1] -= 2;
                        this.state = 2;
                    }

                    break;

                case 2:
                    if (this.square2[1] < 9 && board[this.square1[0] - 1, this.square1[1] + 1] == 0 && board[this.square3[0] + 1, this.square3[1] - 1] == 0 && board[this.square4[0] +2, this.square4[1]] == 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] += 1;


                        this.square3[0] += 1;
                        this.square3[1] -= 1;

                        this.square4[0] += 2;
                        this.state = 3;

                    }
                    break;
                case 3:
                    if (this.square2[0] > 0 && board[this.square1[0] - 1, this.square1[1] - 1] == 0 && board[this.square3[0] + 1, this.square3[1] + 1] == 0 && board[this.square1[0], this.square1[1] + 2] == 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] -= 1;

                        this.square3[0] += 1;
                        this.square3[1] += 1;

                        this.square4[1] += 2;
                        this.state = 0;
                    }
                    break;


            }
        }
    }
}