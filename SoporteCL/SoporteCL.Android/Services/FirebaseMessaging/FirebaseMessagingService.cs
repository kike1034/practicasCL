using System;
using Android.App;
using Firebase.Iid;
using Android.Util;
using Firebase.Messaging;

namespace SoporteCL.Droid.Services.FirebaseMessaging
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseMessagingService
    {
        public override void OnNewToken(string s)
        {
            //string SENDER_ID = "kikis";
            /*RemoteMessage message = new RemoteMessage.Builder(SENDER_ID+"@fcm.googleapis.com")
                .SetMessageId("asdasdas")
                .AddData("my_message","hola")
                .Build();*/
            //Firebase.Messaging.FirebaseMessaging.Instance.Send(message);
            base.OnNewToken(s);
            Log.Debug("NEW TOKEN",s);
        }
        public override void OnMessageReceived(RemoteMessage p0)
        {
            base.OnMessageReceived(p0);
        }
        public void SendRegistrationToserver(string token)
        {

        }
    }
}