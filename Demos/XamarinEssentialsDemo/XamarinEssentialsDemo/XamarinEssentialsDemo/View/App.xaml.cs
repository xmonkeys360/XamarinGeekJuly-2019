using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentialsDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(Preferences.Get(Constants.IS_PREFERENCES_SET, false))
                MainPage = new NavigationPage(new AppInformation());
            else
                MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
