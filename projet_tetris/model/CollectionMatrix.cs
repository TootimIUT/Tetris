using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.model
{
    class CollectionMatrix : List<ShapePlayer>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
