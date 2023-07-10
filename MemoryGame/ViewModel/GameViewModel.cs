using MemoryGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MemoryGame.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public User User { get; set; }
        public Cards Card1 { get; set; }
        public Cards Card2 { get; set; }
        public Cards Card3 { get; set; }
        public Cards Card4 { get; set; }
        public Cards Card5 { get; set; }
        public Cards Card6 { get; set; }
        public bool WrapperDisplay { get; set; }
        public Cards CardSelected { get; set; }
        public List<int> Numbers { get; set; }
        public bool Flag { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public GameViewModel(User Username)
        {
            User = Username ;
            Numbers = new List<int>();
            WrapperDisplay = true;

            Card1 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card1)) };
            Card2 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card2)) };
            Card3 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card3)) };
            Card4 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card4)) };
            Card5 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card5)) };
            Card6 = new Cards(RandomNumbers()) { Click = new Command(() => CheckEquals(Card6)) };

            ShowAllNumbers();
        }

        public async void ShowAllNumbers()
        {
            Card1.Visibility = true;
            Card2.Visibility = true;
            Card3.Visibility = true;
            Card4.Visibility = true;
            Card5.Visibility = true;
            Card6.Visibility = true;

            await Task.Delay(2000);

            CardAttributesChanged(Card1);
            CardAttributesChanged(Card2);
            CardAttributesChanged(Card3);
            CardAttributesChanged(Card4);
            CardAttributesChanged(Card5);
            CardAttributesChanged(Card6);
        }
    
        public async void CheckEquals(Cards AcctualyCard)
        {
            try
            {
   
               if(Flag == true)
                {
                    WrapperDisplay = false;

                   if(AcctualyCard.Enabled == true)
                    {
                        CardAttributesChanged(AcctualyCard);
                        
                        if(AcctualyCard.Number == CardSelected.Number)
                        {
                            User.Record += 10;
                            CardSelected = null;
                            Flag = !Flag;
                            WrapperDisplay = true;
                            ChekFinish();
                        }
                        else
                        {
                            await Task.Delay(1000);
                            User.Errors += 1;
                            CardAttributesChanged(AcctualyCard);
                            CardAttributesChanged(CardSelected);
                            CardSelected = null;
                            Flag = !Flag;
                            WrapperDisplay = true;
                            ChekFinish();
                        }
                        
                    }

                }
                else
                {
                    CardSelected = AcctualyCard;
                    CardAttributesChanged(CardSelected);
                    Flag = !Flag;
                }

            }catch(Exception ex) {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }

        }

        //No primeiro momento torna a Visibilidade como "False" e o Enabled como "True"
        public void CardAttributesChanged(Cards Card)
        {
            Card.Visibility = !Card.Visibility;
            Card.Enabled = !Card.Enabled;
            return;
        }

        public int RandomNumbers()
        {
            Random ranNum = new Random();
            bool randomFlag = true;

            while (randomFlag)
            {

                int num = ranNum.Next(1, 4);

                var repeatedNumbers = Numbers.FindAll(x => x == num);

                if(repeatedNumbers.Count < 2)
                {
                    Numbers.Add(num);
                    randomFlag = false;
                    return num;

                }else if (repeatedNumbers.Count == 2)
                {
                    randomFlag = true;
                }

               
            }

            return 0;

        }

        public async void ChekFinish()
        {
            if(User.Record == 30)
            {
                await App.Current.MainPage.DisplayAlert("Fim de jogo!", "Parabéns, você venceu!", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();

            }else if (User.Errors == 3)
            {
                await App.Current.MainPage.DisplayAlert("Fim de jogo!", "Total de tentativas atingido, você perdeu!", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

    }
}
