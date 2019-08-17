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
using UserLiveTracking.Droid.Services;
using UserLiveTracking.Helper;
using UserLiveTracking.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace UserLiveTracking.Droid.Services
{
    class FirebaseAuthentication : IFirebaseAuthentication
    {
        public void PasswordAuthentication()
        {
            try
            {
                if (FirebaseAuth.Instance.CurrentUser == null)
                {
                    var task = FirebaseAuth.Instance.SignInWithEmailAndPassword(Constants.UserName, Constants.Password);
                    if (!task.IsSuccessful)
                    {
                        var ex = task.Exception as FirebaseAuthException;
                        if (ex is FirebaseAuthInvalidUserException)
                        {
                            var taskLogin = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(Constants.UserName, Constants.Password);
                            if (task.IsSuccessful)
                            {
                                PasswordAuthentication();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
          
        }

        public void SignOut()
        {
            FirebaseAuth.Instance.SignOut();
        }
    }
}