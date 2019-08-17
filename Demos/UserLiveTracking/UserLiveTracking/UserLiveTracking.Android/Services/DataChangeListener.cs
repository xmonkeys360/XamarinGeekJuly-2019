using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;

namespace UserLiveTracking.Droid.Services
{
    public class DataChangeListener : Java.Lang.Object, IValueEventListener
    {
        Action<DataSnapshot> postListener;

        public DataChangeListener(Action<DataSnapshot> postListener)
        {
            this.postListener = postListener;
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            postListener.Invoke(snapshot);
        }

        public void OnCancelled(DatabaseError error)
        {
        }

    }
}