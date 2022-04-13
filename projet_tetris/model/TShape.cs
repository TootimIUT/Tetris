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

        }
    }
}
