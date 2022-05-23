using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class JShape : ShapePlayer
    {
        public JShape()
        {
            square1 = new int[] { 0, 5 };
            square2 = new int[] { 1, 5 };
            square3 = new int[] { 2, 5 };
            square4 = new int[] { 2, 4 };
            color = Brushes.Blue;
            isPlaced = false;
            state = 0;

        }

        public override void rotateShape()
        {
            switch (this.state)
            {
                case 0:
                    if (this.square2[1] < 9)
                    {
                        this.square1[0] += 1;
                        this.square1[1] += 1;
                        this.square3[0] -= 1;
                        this.square3[1] -= 1;
                        this.square4[0] -= 2;
                        this.state = 1;
                    }
                    break;

                case 1:
                    if (this.square2[0] < 19)
                    {
                        this.square1[0] += 1;
                        this.square1[1] -= 1;
                        this.square3[0] -= 1;
                        this.square3[1] += 1;
                        this.square4[1] += 2;
                        this.state = 2;
                    }
                    break;

                case 2:
                    if (this.square2[1] > 0)
                    {
                        this.square1[0] -= 1;
                        this.square1[1] -= 1;
                        this.square3[0] += 1;
                        this.square3[1] += 1;
                        this.square4[0] += 2;
                        this.state = 3;
                    }
                    break;
                case 3:

                    this.square1[0] -= 1;
                    this.square1[1] += 1;
                    this.square3[0] += 1;
                    this.square3[1] -= 1;
                    this.square4[1] -= 2;
                    this.state = 0;

                    break;


            }
        }
    }
}