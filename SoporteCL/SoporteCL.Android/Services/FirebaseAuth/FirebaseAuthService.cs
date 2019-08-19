
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using SoporteCL.Droid.Activities;
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
        public static int REQ_AUTH = 9999;
        public static String KEY_AUTH = "auth";
        public string getAuthKey()
        {
            return KEY_AUTH;
        }

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

        public void SignInWithGoogle()
        {
                var googleIntent = new Intent(Android.App.Application.Context, typeof(GoogleLoginActivity));
                ((Android.App.Activity)Android.App.Application.Context).StartActivityForResult(googleIntent, REQ_AUTH);
            
        }

        public async Task<bool> SignInWithGoogle(string token)
        {
            try
            {
                AuthCredential credential = GoogleAuthProvider.GetCredential(token, null);
                await MainActivity.auth.SignInWithCredentialAsync(credential);
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}