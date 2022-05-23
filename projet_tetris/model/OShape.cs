using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class OShape : ShapePlayer
    {
        public OShape()
        {
            square1 = new int[] { 0, 5 };
            square2 = new int[] { 0, 6 };
            square3 = new int[] { 1, 5 };
            square4 = new int[] { 1, 6 };
            color = Brushes.Yellow;
            isPlaced = false;
            state = 0;

        }

        public override void rotateShape(int[,] board)
        {

        }
    }
}