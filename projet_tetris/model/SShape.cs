using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class SShape : ShapePlayer
    {
        public SShape()
        {
            square1 = new int[] { 0, 4 };
            square2 = new int[] { 0, 5 };
            square3 = new int[] { 1, 5 };
            square4 = new int[] { 1, 6 };
            color = Brushes.Red;
            isPlaced = false;
            state = 0;
        }

        public override void rotateShape(int[,] board)
        {
            switch (this.state)
            {
                case 0:
                    if (this.square1[0] > 0 && board[this.square1[0] - 1, this.square1[1] + 1] == 0 && board[this.square3[0] - 1, this.square3[1] - 1] == 0 && board[this.square4[0], this.square4[1] - 2] == 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] += 1;

                        this.square3[0] -= 1;
                        this.square3[1] -= 1;

                        this.square4[1] -= 2;

                        this.state = 1;

                    }
                    break;

                case 1:
                    if (this.square4[1] < 8 && board[this.square1[0] + 1, this.square1[1] - 1] == 0 && board[this.square3[0] + 1, this.square3[1] + 1] == 0 && board[this.square4[0], this.square4[1] + 2] == 0)
                    {
                        this.square1[0] += 1;
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