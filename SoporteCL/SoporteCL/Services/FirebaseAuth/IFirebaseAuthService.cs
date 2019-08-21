using System;
using System.Threading.Tasks;

namespace SoporteCL.Services.FirebaseAuth
{
    public interface IFirebaseAuthService
    {
        bool IsUserSigned();
        Task<bool> SignUp(String email, String password);
        Task<bool> SignIn(String email, String password);

        //TODO Este método da error implementarlo para cada plataforma
        Task<bool> SendEmailVerification();
        Task<bool> Logout();

        string GetUserId();
    }
}
