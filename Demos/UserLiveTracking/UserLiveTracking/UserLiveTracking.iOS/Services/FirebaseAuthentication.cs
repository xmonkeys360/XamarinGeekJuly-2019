using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Foundation;
using UIKit;
using UserLiveTracking.Helper;
using UserLiveTracking.Interface;
using UserLiveTracking.iOS.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace UserLiveTracking.iOS.Services
{
    class FirebaseAuthentication : IFirebaseAuthentication
    {
        public void PasswordAuthentication()
        {
            try
            {
                if (Auth.DefaultInstance.CurrentUser == null)
                {
                    Auth.DefaultInstance.SignInWithPassword(Constants.UserName, Constants.Password, OnFirebaseSignIn);
                }
            }
            catch (Exception ex)
            {
                

            }
        }

        public void SignOut()
        {
            try
            {
                NSError error;
           
                var isSignedOut = Auth.DefaultInstance.SignOut(out error);
            }
            catch (Exception ex)
            {
              

            }
        }

        private void OnFirebaseSignIn(AuthDataResult authResult, NSError error)
        {
            try
            {
                if (error != null)
                {
                    AuthErrorCode errorCode;
                    if (IntPtr.Size == 8) // 64 bits devices
                        errorCode = (AuthErrorCode)((long)error.Code);
                    else // 32 bits devices
                        errorCode = (AuthErrorCode)((int)error.Code);

                    // Posible error codes that SignIn method with email and password could throw
                    // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                    switch (errorCode)
                    {
                        case AuthErrorCode.UserNotFound:
                            RegisterUserForFirebase();
                            break;
                        case AuthErrorCode.OperationNotAllowed:
                        case AuthErrorCode.InvalidEmail:
                        case AuthErrorCode.UserDisabled:
                        case AuthErrorCode.WrongPassword:
                        default:
                            // Print error
                            break;
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
               

            }
        }

        private void RegisterUserForFirebase()
        {
            try
            {
                Auth.DefaultInstance.CreateUser(Constants.UserName, Constants.Password, OnFirebaseRegistration);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void OnFirebaseRegistration(AuthDataResult authResult, NSError error)
        {
            try
            {
                if (error != null)
                {
                    AuthErrorCode errorCode;
                    if (IntPtr.Size == 8) // 64 bits devices
                        errorCode = (AuthErrorCode)((long)error.Code);
                    else // 32 bits devices
                        errorCode = (AuthErrorCode)((int)error.Code);

                    // Posible error codes that SignIn method with email and password could throw
                    // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                    switch (errorCode)
                    {
                        case AuthErrorCode.OperationNotAllowed:
                        case AuthErrorCode.InvalidEmail:
                        case AuthErrorCode.UserDisabled:
                        case AuthErrorCode.WrongPassword:
                        default:
                            // Print error
                            break;
                    }

                    return;
                }
                else
                {
                    PasswordAuthentication();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}