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
    public partial class AppInformation : ContentPage
    {
        public AppInformation()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (Preferences.Get(Constants.IS_PREFERENCES_SET, false))
            //    Preferences.Clear();
            //else
            //    Preferences.Set(Constants.IS_PREFERENCES_SET, true);
        }
    }
}