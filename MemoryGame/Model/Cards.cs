using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemoryGame.Model
{
    public class Cards : INotifyPropertyChanged
    {
        public int Number { get; set; }
        public bool Visibility { get; set; }
        public bool Enabled { get; set; }
        public ICommand Click { get; set; }

        public Cards(int Number) {
            this.Number = Number;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
