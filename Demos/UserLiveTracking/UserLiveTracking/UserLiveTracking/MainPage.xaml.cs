using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLiveTracking.Interface;
using UserLiveTracking.Views;
using Xamarin.Forms;

namespace UserLiveTracking
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<IFirebaseAuthentication>()
                .PasswordAuthentication();
        }
        private void BtnAdmin_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapAdminPage());
        }

        private void BtnUser_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapUserPage());
        }
    }
}
