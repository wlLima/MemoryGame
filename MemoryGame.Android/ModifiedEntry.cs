using Android.Content;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MemoryGame.Controls;
using MemoryGame.Droid;

[assembly: ExportRenderer(typeof(PersonalizedEntry), typeof(ModifiedEntry))]
namespace MemoryGame.Droid
{
    public class ModifiedEntry : EntryRenderer
    {
        public ModifiedEntry(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
                var lp = new MarginLayoutParams(Control.LayoutParameters);
                lp.SetMargins(0, 7, 0, 0);


                var d = e.NewElement.Margin;
                e.NewElement.VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center;
                LayoutParameters = lp;
                Control.LayoutParameters = lp;
                Control.SetIncludeFontPadding(true);
                Control.SetPaddingRelative(5, 0, 5, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}