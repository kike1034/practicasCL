using SoporteCL.Services.FirebaseAuth;
using SoporteCL.ViewModels.Base;
using SoporteCL.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SoporteCL.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _logoutCommand;
        private IFirebaseAuthService _firebaseService;

        public MainViewModel()
        {
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();
        }

        public ICommand LogoutCommand
        {
            get { return _logoutCommand = _logoutCommand ?? new DelegateCommandAsync(LogoutCommandExecute); }
        }

        private async Task LogoutCommandExecute()
        {
            if (await _firebaseService.Logout())
            {
                await NavigationService.NavigateToAsync<LoginViewModel>();
            }


        }
    }
}
