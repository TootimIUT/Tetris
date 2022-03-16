using projet_tetris.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.view_model
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ShapePlayer shape { get; set; }

        public ViewModel()
        {
            bool[,] matrix = {{ false, false, false, false},
                { false, true, true, false},
                { false, true, true, false},
                { false, false, false, false}};
            this.shape = new ShapePlayer(matrix);

        }

        public bool[,] Matrix 
        { 
            get { return this.shape.MatrixShape; }
            set { this.shape.MatrixShape = value; }
        }


    }
}
