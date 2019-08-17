using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UserLiveTracking.CustomControl;
using UserLiveTracking.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace UserLiveTracking.Droid.Services
{
    public class CustomMapRenderer : MapRenderer
    {
        GoogleMap nativeMap;
        ObservableCollection<CustomPin> customPins;
        private CustomMap Maps;
        public CustomMapRenderer() : base()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (e.OldElement != null)
                {
                    var nativeMap = Control as MapView;
                    if (nativeMap != null)
                    {
                    }
                }

                if (e.NewElement != null)
                {
                    Maps = (CustomMap)e.NewElement;
                    customPins = Maps.CustomPins;
                    Control.GetMapAsync(this);
                    if (customPins != null)
                    {
                        Maps.CustomPins.CollectionChanged += CustomPins_CollectionChanged; ;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CustomPins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            customPins = (ObservableCollection<CustomPin>)sender;
            UpdateMarker();

        }

        private void UpdateMarker()
        {
            try
            {
                if (nativeMap != null)
                {
                    nativeMap.Clear();
                }

                foreach (var custompin in customPins)
                {
                    var marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(custompin.Position.Latitude, custompin.Position.Longitude));
                    marker.SetTitle(custompin.Label);
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.icons));
                    nativeMap.AddMarker(marker);
                }


            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);
                if (Element == null || Control == null)
                    return;
                Maps = (CustomMap)sender;
                if (e.PropertyName == CustomMap.CustomPinsProperty.PropertyName || e.PropertyName == "VisibleRegion")
                {
                    if (Maps.CustomPins != null)
                    {
                        customPins = Maps.CustomPins;
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            nativeMap = map;


        }

    } 

}