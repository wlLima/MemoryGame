using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryGame.ViewModel
{
    internal class RankingViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
