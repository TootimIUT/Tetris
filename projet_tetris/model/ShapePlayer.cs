using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projet_tetris.model
{
    public abstract class ShapePlayer
    {
        public int[] square1 { get; set; }
        public int[] square2 { get; set; }
        public int[] square3 { get; set; }
        public int[] square4 { get; set; }
        public Brush color { get; set; }
        public bool isPlaced { get; set; }
        public int state { get; set; }

    }

}
