using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Firebase;
using SoporteCL.Droid.Services.FirebaseAuth;
using Xamarin.Forms;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Android.Gms.Auth.Api.SignIn;
using Firebase.Auth;

namespace SoporteCL.Droid
{
    [Activity(Label = "SoporteCL.Android", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static Firebase.FirebaseApp app;
        public static FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            InitFirebaseAuth();
            UserDialogs.Init(this);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
            .SetApplicationId("1:794347157754:android:16a6a04d9417fbbc")
            .SetApiKey("AIzaSyAAVtOm4H3W0N7nyih3GfuBfHTG-hZFWP8")
            .SetDatabaseUrl("https://soportecl-b0939.firebaseio.com")
            .Build();
           /* var options = new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            };*/
          

            if (app == null)
            {
                app = FirebaseApp.InitializeApp(this, options, "SoporteCLAndroid");
                if (FirebaseAuth.GetInstance(app) == null&&auth==null)
                {
                    auth = new FirebaseAuth(app);
                }
                //FirebaseAuth.Instance = new FirebaseAuth();
                //app = FirebaseAdmin.FirebaseApp.Create(options,"SoporteCLAndroid");

            }

        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == FirebaseAuthService.REQ_AUTH && resultCode == Result.Ok)
            {
                GoogleSignInAccount sg = (GoogleSignInAccount)data.GetParcelableExtra("result");
                MessagingCenter.Send(FirebaseAuthService.KEY_AUTH, FirebaseAuthService.KEY_AUTH, sg.IdToken);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}