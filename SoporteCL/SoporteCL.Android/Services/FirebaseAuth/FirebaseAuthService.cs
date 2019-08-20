﻿
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using SoporteCL.Droid.Services.FirebaseAuth;
using SoporteCL.Services.FirebaseAuth;
using Xamarin.Forms;
using Android.Gms.Extensions;
using Firebase.Auth;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace SoporteCL.Droid.Services.FirebaseAuth
{
    public class FirebaseAuthService : IFirebaseAuthService
    {

        public bool IsUserSigned()
        {
            var user = MainActivity.auth.CurrentUser;
            var signedIn = user != null;
            return signedIn;
        }

        public async Task<bool> Logout()
        {
            try
            {
                MainActivity.auth.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SignIn(string email, string password)
        {
            try
            {
                await MainActivity.auth.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SignUp(string email, string password)
        {
            try
            {
                await MainActivity.auth.CreateUserWithEmailAndPassword(email, password);
                //await MainActivity.auth.CurrentUser.SendEmailVerification();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}