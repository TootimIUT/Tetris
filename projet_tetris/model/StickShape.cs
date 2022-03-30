using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.model
{
    internal class StickShape : ShapePlayer
    {
        public StickShape()
        {
            square1 = new int[] { 20, 3 };
            square2 = new int[] { 20, 4 };
            square3 = new int[] { 20, 5 };
            square4 = new int[] { 20, 6 };

        }
    }
}
