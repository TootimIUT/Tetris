using System;
using System.Collections.Generic;
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

        }
    }
}
