using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinEssentialsDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void EssentialsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItemName = e.Item.ToString();
            if(selectedItemName == Constants.APP_INFORMATION)
            {
                await Navigation.PushAsync(new AppInformation(), false);
            }
            else if (selectedItemName == Constants.BATTERY_INFORMATION)
            {
                await Navigation.PushAsync(new BatteryInformation(), false);
            }
            else if (selectedItemName == Constants.DISPLAY_INFORMATION)
            {
                await Navigation.PushAsync(new DisplayInformation(), false);
            }
            else if (selectedItemName == Constants.DEVICE_INFORMATION)
            {
                await Navigation.PushAsync(new DeviceInformation(), false);
            }
            else if (selectedItemName == Constants.SEND_EMAIL)
            {
                List<string> emailRecipients = new List<string>();
                emailRecipients.Add("harinsync@gmail.com");
                await SendEmail.SendMailWithDefaultClient("Test Email", "This is a test email", emailRecipients);
            }
        }
    }
}
