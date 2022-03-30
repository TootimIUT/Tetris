using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace projet_tetris.model
{
    internal class LShape : ShapePlayer
    {
        public LShape()
        {
            square1 = new int[] { 20, 5};
            square2 = new int[] { 19, 5 };
            square3 = new int[] { 18, 5 };
            square4 = new int[] { 18, 6 };
            color = Brushes.orange;

        }

    }
}
