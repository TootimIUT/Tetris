using projet_tetris.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projet_tetris.view_model
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string[] shape { get; set; }

        public ViewModel()
        {
            shape = new string[] {"JShape", "ZShape", "LShape", "TShape", "StickShape", "SShape", "OShape"};

        }




    }
}
