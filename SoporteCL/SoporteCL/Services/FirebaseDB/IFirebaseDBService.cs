using System;
using System.Collections.Generic;
using System.Text;

namespace SoporteCL.Services.FirebaseDB
{
    public interface IFirebaseDBService
    {
        void Connect();
        void GetMessage();
        void SetMessage(String message);
        string GetMessageKey();
        void DeleteItem(string key);
    }
}
