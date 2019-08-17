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
using Firebase.Auth;
using Firebase.Database;
using Java.Util;
using UserLiveTracking.Droid.Services;
using UserLiveTracking.Helper;
using UserLiveTracking.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace UserLiveTracking.Droid.Services
{
    class FirebaseDBService : IFirebaseDatabase
    {
        public void CreateOrUpdateData(List<string> branches, string[] keys, string[] value)
        {
            var node = GetNode(branches);
            if (node != null)
            {
                #region All Parameter
                //Everytime Update All Parameter
                //IMap data = new HashMap();
                //for (int i = 0; i < keys.Length; i++)
                //{
                //    data.Put(keys[i], value[i]);
                //}
                //node.SetValue(data as Java.Lang.Object);
                #endregion

                #region Each Parameter
                //Each Parameter Updation
                Dictionary<string, Java.Lang.Object> data = new Dictionary<string, Java.Lang.Object>();
                for (int i = 0; i < keys.Length; i++)
                {
                    data.Add(keys[i], value[i]);
                }

                node.UpdateChildren(data);
                #endregion

                
            }


        }

        public void ReadDataOnce(List<string> branches, Action<DataSnapshot> listener)
        {
            try
            {
                var node = GetNode(branches);

                node.AddListenerForSingleValueEvent(new DataChangeListener(listener));
            }
            catch (Exception ex)
            {

            }
        }

        public DatabaseReference SubscribeForDataChange(List<string> branches, Action<DataSnapshot> listener)
        {
            var node = GetNode(branches);
            List<string> handlersList = new List<string>();
            handlersList.Add(listener.Method.Name);
            AddValueEventListener(node, listener);


            return node;
        }
        private void AddValueEventListener(DatabaseReference node, Action<DataSnapshot> listener)
        {
            try
            {
                var dataChangeListener = new DataChangeListener(listener);
                node.AddValueEventListener(dataChangeListener);
                var valueEventListeners = new List<IValueEventListener>();
                valueEventListeners.Add(dataChangeListener);

            }
            catch (Exception ex)
            {
            }
        }
        private DatabaseReference GetNode(List<string> branches)
        {
            try
            {
                var uid = FirebaseAuth.Instance.CurrentUser.Uid;
                var node = FirebaseDatabase.Instance.GetReferenceFromUrl(Constants.FCMURL).Child(uid);
                foreach (var branch in branches)
                {
                    node = node.Child(branch);
                }
                return node;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}