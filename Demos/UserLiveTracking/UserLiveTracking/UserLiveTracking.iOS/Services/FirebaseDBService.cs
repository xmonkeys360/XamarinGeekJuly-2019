using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Firebase.Database;
using Foundation;
using UIKit;
using UserLiveTracking.Helper;
using UserLiveTracking.Interface;
using UserLiveTracking.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace UserLiveTracking.iOS.Services
{

    public class FirebaseDBService : IFirebaseDatabase
    {
        public void CreateOrUpdateData(List<string> branches, string[] keys, string[] values)
        {
            try
            {
                var node = GetNode(branches);
                if (node != null)
                {
                    var data = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);

                    //node.SetValue(data); //Everytime Update All Parameter
                    node.UpdateChildValues(data); // //Each Parameter Updation

                    node.KeepSynced(true);

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ReadDataOnce(List<string> branches, Action<DataSnapshot> listener)
        {
            try
            {
                var node = GetNode(branches);

                if (node != null)
                {
                    DatabaseQueryUpdateHandler handler = (snapshot) => listener(snapshot);
                    node.ObserveSingleEvent(DataEventType.Value, handler);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public DatabaseReference SubscribeForDataChange(List<string> branches, Action<DataSnapshot> listener)
        {
            try
            {
                var node = GetNode(branches); 
                if (node != null)
                { 
                        List<string> handlersList = new List<string>();
                        handlersList.Add(listener.Method.Name);  

                        DatabaseQueryUpdateHandler handler = (snapshot) => listener(snapshot);
                        node.ObserveEvent(DataEventType.Value, handler); 
                }

                return node;

            }
            catch (Exception ex)
            {
               
                return null;
            }

        }

        private DatabaseReference GetNode(List<string> branches)
        {
            try
            {
                var uid = Auth.DefaultInstance.CurrentUser.Uid;
                var node = Database.DefaultInstance.GetReferenceFromUrl(Constants.FCMURL).GetChild(uid);
                foreach (var branch in branches)
                {
                    node = node.GetChild(branch);
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