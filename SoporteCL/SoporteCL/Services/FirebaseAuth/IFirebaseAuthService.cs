using System;
using System.Threading.Tasks;

namespace SoporteCL.Services.FirebaseAuth
{
    public interface IFirebaseAuthService
    {
        bool IsUserSigned();
        Task<bool> SignUp(String email, String password);
        Task<bool> SignIn(String email, String password);
        Task<bool> Logout();
    }
}
