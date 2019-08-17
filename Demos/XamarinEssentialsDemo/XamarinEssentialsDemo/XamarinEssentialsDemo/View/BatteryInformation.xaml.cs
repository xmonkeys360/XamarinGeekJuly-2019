using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentialsDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatteryInformation : ContentPage
	{
		public BatteryInformation ()
		{
			InitializeComponent ();
            SetBackground(Battery.ChargeLevel, Battery.State == BatteryState.Charging);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackground(e.ChargeLevel, e.State == BatteryState.Charging);
            (BindingContext as ViewModel).GetBatteryInformation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void SetBackground(double level, bool charging)
        {
            Color? color = null;
            if(charging)
            {
                if (level >= 1)
                    color = Color.Green.MultiplyAlpha(level);
                else if (level > 0.1 && level < 0.5)
                    color = Color.Yellow.MultiplyAlpha(level);
                    else
                    color = Color.Orange.MultiplyAlpha(level);

            }
            else
            {
                color = Color.Red.MultiplyAlpha(level);

            }
            BackgroundColor = color.Value;
        }
    }
}