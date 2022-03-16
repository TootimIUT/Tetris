using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.model
{
    public class ShapePlayer
    {
        public bool[,] MatrixShape { get; set; }
        public ShapePlayer(bool[,] coordShape)
        {
            MatrixShape = coordShape;
        }
    }
}
