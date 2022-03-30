using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.model
{
    internal class ZShape : ShapePlayer
    {
        public ZShape()
        {
            square1 = new int[] { 20, 6 };
            square2 = new int[] { 20, 5 };
            square3 = new int[] { 19, 5 };
            square4 = new int[] { 19, 4 };

        }
    }
}
