using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLiveTracking.CustomControl;
using UserLiveTracking.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UserLiveTracking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapAdminPage : ContentPage
    {
        ObservableCollection<CustomPin> Pins = new ObservableCollection<CustomPin>();
        public MapAdminPage()
        {
            InitializeComponent();

            //  Pins.Add(new CustomPin{new Position(12,12});
            Pins.Add(new CustomPin { Position = new Position(13.033395, 80.243644) });
            Pins.Add(new CustomPin { Position = new Position(13.033855, 80.244264) });
            Pins.Add(new CustomPin { Position = new Position(13.034665, 80.245318) });
            Pins.Add(new CustomPin { Position = new Position(13.035671, 80.246013) });
            Pins.Add(new CustomPin { Position = new Position(13.037053, 80.246364) });
            Pins.Add(new CustomPin { Position = new Position(13.037860, 80.246530) });
            Pins.Add(new CustomPin { Position = new Position(13.038871, 80.246744) });
            Pins.Add(new CustomPin { Position = new Position(13.039759, 80.246948) });
            Pins.Add(new CustomPin { Position = new Position(13.040441, 80.247088) });
            Pins.Add(new CustomPin { Position = new Position(13.041013, 80.247193) });
            Pins.Add(new CustomPin { Position = new Position(13.041679, 80.247316) });
            Pins.Add(new CustomPin { Position = new Position(13.042413, 80.247488) });
            Pins.Add(new CustomPin { Position = new Position(13.043474, 80.247708) });
            Pins.Add(new CustomPin { Position = new Position(13.044522, 80.247933) });
            Pins.Add(new CustomPin { Position = new Position(13.045356, 80.248097) });
            Pins.Add(new CustomPin { Position = new Position(13.046291, 80.248285) });
         
           

            int i = 0;

            var sec = TimeSpan.FromSeconds(10);

            Device.StartTimer(sec, () =>
            {
                var CurrentPosition = Pins[i].Position; 
                i++; 
                var Pin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = CurrentPosition,
                    Label = "Current Location",
                    Name = "IdCurrentLocation",
                };

                var CustomPinCurrent = customMap.CustomPins.Where(x => x.Name == "IdCurrentLocation").FirstOrDefault();
                var IndexCurrentPinNew = customMap.CustomPins.IndexOf(CustomPinCurrent);
                if (customMap.CustomPins.Count != 0)
                {
                    if (IndexCurrentPinNew >= 0)
                    {
                        customMap.CustomPins[IndexCurrentPinNew] = Pin;
                    }
                    else
                    {

                        customMap.CustomPins.Add(Pin);
                    }
                }
                else
                {

                    customMap.CustomPins.Add(Pin);
                }
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(CurrentPosition.Latitude, CurrentPosition.Longitude), Xamarin.Forms.Maps.Distance.FromKilometers(1)));


                Dictionary<string, string> properties = new Dictionary<string, string>();

                properties.Add("Latitude", CurrentPosition.Latitude.ToString());
                properties.Add("Longitude", CurrentPosition.Longitude.ToString());
                var branchHierarchy = new List<string>();
                branchHierarchy.Add("Test");

                DependencyService.Get<IFirebaseDatabase>().CreateOrUpdateData(branchHierarchy, properties.Keys.ToArray(), properties.Values.ToArray());


                return true;
            });



        }
    }
}