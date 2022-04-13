using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    internal class StickShape : ShapePlayer
    {
        public StickShape()
        {
            square1 = new int[] { 0, 3 };
            square2 = new int[] { 0, 4 };
            square3 = new int[] { 0, 5 };
            square4 = new int[] { 0, 6 };
            color = Brushes.Cyan;
            isPlaced = false;
        }
    }
}
