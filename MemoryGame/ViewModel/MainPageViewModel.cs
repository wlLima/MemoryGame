using MemoryGame.Model;
using MemoryGame.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MemoryGame.ViewModel
{
    internal class MainPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        public Command AvancarCommand { get; set; }
        public User User { get; set; }  

        public MainPageViewModel()
        {
            User = new User();
            AvancarCommand = new Command(Avancar);
        }

        private async void Avancar()
        {
            try
            {

            if(string.IsNullOrEmpty(User.Name))
            {
                    throw new Exception("O nome do usuário não pode ficar vazio!");
            }

            await App.Current.MainPage.Navigation.PushAsync(new Game() { BindingContext = new GameViewModel(User) });
            }catch(Exception ex) {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
        }
    }
}
