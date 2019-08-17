using System;
using System.Collections.Generic;
using System.Text;

namespace UserLiveTracking.Interface
{
    interface IFirebaseAuthentication
    {
        void PasswordAuthentication();
        void SignOut();
    }
}
