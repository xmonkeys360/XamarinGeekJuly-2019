using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace UserLiveTracking.CustomControl
{
    public class CustomMap:Map
    {
        public static readonly BindableProperty CustomPinsProperty =
            BindableProperty.Create<CustomMap, ObservableCollection<CustomPin>>(p => p.CustomPins, new ObservableCollection<CustomPin>());
        public ObservableCollection<CustomPin> CustomPins
        {
            get { return (ObservableCollection<CustomPin>)GetValue(CustomPinsProperty); }
            set { SetValue(CustomPinsProperty, value); }
        }
        public CustomMap()
        {
            
        }
        public CustomMap(MapSpan region) : base(region)
        {

        }
    }
}
