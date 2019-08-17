using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;

namespace UserLiveTracking.Droid
{
    [Activity(Label = "UserLiveTracking", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            AccessPermissions();
            base.OnCreate(savedInstanceState);
             Xamarin.FormsMaps.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public void AccessPermissions()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
                    && (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted))
                {
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation,
                        Manifest.Permission.AccessFineLocation
                     }, 100);
                }
                else if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == Permission.Granted)
                    && (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == Permission.Granted))
                {

                }
                else
                {
                    
                    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted)
                    {
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessFineLocation }, 102);
                    }

                    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
                    {
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation }, 102);
                    }
                   
                }
            }
            else
            {
                //
            }
        }
    }
}