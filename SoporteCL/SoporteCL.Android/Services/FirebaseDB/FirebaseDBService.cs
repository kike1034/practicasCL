
using System;
using System.Threading.Tasks;
using SoporteCL.Services.FirebaseAuth;
using Xamarin.Forms;
using SoporteCL.Droid.Services.FirebaseDB;
using SoporteCL.Services.FirebaseDB;
using Firebase.Database;
using SoporteCL.Droid.Services.FirebaseAuth;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace SoporteCL.Droid.Services.FirebaseDB
{
        public class ValueEventListener : Java.Lang.Object, IValueEventListener
        {
            public void OnCancelled(DatabaseError error) { }

            public void OnDataChange(DataSnapshot snapshot)
            {
                String message = snapshot.Value.ToString();
                MessagingCenter.Send(FirebaseDBService.KEY_MESSAGE, FirebaseDBService.KEY_MESSAGE, message);


            }
        }
        public class FirebaseDBService : IFirebaseDBService
    {
        DatabaseReference databaseReference;
        FirebaseDatabase database;
        FirebaseAuthService authService = new FirebaseAuthService();
        public static String KEY_MESSAGE = "message";

        public void Connect()
        {
            database = FirebaseDatabase.GetInstance(MainActivity.app);
        }

        public void DeleteItem(string key)
        {
            throw new NotImplementedException();
        }

        public void GetMessage()
        {
            throw new NotImplementedException();
        }

        public string GetMessageKey()
        {
            throw new NotImplementedException();
        }

        public void SetMessage(string message)
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("user/" + userId);
            databaseReference.SetValue(message);
        }
    }
}