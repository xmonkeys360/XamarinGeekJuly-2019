using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using UserLiveTracking.CustomControl;
using UserLiveTracking.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UserLiveTracking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapUserPage : ContentPage
    {
        IFirebaseDatabase FCMDB;
        public MapUserPage()
        {
            InitializeComponent();
            FCMDB = DependencyService.Get<IFirebaseDatabase>();
            var branch = new List<string>();
            branch.Add("Anbu");

            FCMDB.SubscribeForDataChange(branch, ListenerUser);
        }

        private void ListenerUser(DataSnapshot obj)
        {
            var snapChildren = obj.Children.ToEnumerable();
            var Lat = obj.Child("Latitude").GetValue(true).ToString();
            var Long = obj.Child("Longitude").GetValue(true).ToString();
            // var Lat = obj.GetValue(true);
            var CurrentPosition =new Position(Convert.ToDouble(Lat), Convert.ToDouble(Long));
            var Pin = new CustomPin
            {
                Type = PinType.Place,
                Position = CurrentPosition,
                Label = "Current Location",
                Name = "IdCurrentLocation",
            };

            var CustomPinCurrent = UserCustomMap.CustomPins.Where(x => x.Name == "IdCurrentLocation").FirstOrDefault();
            var IndexCurrentPinNew = UserCustomMap.CustomPins.IndexOf(CustomPinCurrent);
            if (UserCustomMap.CustomPins.Count != 0)
            {
                if (IndexCurrentPinNew >= 0)
                {
                    UserCustomMap.CustomPins[IndexCurrentPinNew] = Pin;
                }
                else
                {

                    UserCustomMap.CustomPins.Add(Pin);
                }
            }
            else
            {

                UserCustomMap.CustomPins.Add(Pin);
            }
            UserCustomMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(CurrentPosition.Latitude, CurrentPosition.Longitude), Xamarin.Forms.Maps.Distance.FromKilometers(1)));

        }
    }
}