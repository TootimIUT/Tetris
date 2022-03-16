using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.model
{
    public class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Shape(int[] coordX, int[] coordY)
        {

        }

        public bool[,] matrixShape = new bool[4,4];
        public int[,] I_Tetromino_90 = new int[4, 2] {{ 1,0 },   // *  
                                                       { 1,0 },  // *
                                                       { 1,0 },  // *
                                                       { 1,0 }}; // *

    }
}
