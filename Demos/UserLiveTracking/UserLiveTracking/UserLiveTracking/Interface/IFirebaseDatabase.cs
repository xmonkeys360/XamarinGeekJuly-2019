using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace UserLiveTracking.Interface
{
    interface IFirebaseDatabase
    {
        void ReadDataOnce(List<string> branches, Action<DataSnapshot> listener);
        void CreateOrUpdateData(List<string> branchHierarchy, string[] keys, string[] value);
        DatabaseReference SubscribeForDataChange(List<string> branches, Action<DataSnapshot> listener);
    }
}
