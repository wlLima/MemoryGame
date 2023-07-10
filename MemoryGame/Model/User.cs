using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryGame.Model
{
    public class User : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Record { get; set; }
        public int Errors { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }

}
