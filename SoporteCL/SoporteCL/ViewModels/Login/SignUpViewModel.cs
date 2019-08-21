using Acr.UserDialogs;
using SoporteCL.Services.FirebaseAuth;
using SoporteCL.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SoporteCL.ViewModels.Login
{
    class SignUpViewModel : BaseViewModel
    {
        private ICommand _loginCommand;
        private ICommand _signupCommand;
        private String _username;
        private String _password;
        private IUserDialogs _userDialogService;

        private IFirebaseAuthService _firebaseService;

        public SignUpViewModel(IUserDialogs userDialogsService)
        {
            _userDialogService = userDialogsService;
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();

        }

        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommandAsync(LoginCommandExecute); }
        }
        public ICommand SignUpCommand
        {
            get { return _signupCommand = _signupCommand ?? new DelegateCommandAsync(SignUpCommandExecute); }
        }
        private async Task LoginCommandExecute()
        {
            await NavigationService.NavigateToAsync<LoginViewModel>();
        }
        private async Task SignUpCommandExecute()
        {
            if (await _firebaseService.SignUp(Username, Password))
            {
                //TODO cuando este implementada la verificación por correo.
                //if (await _firebaseService.SendEmailVerification()) _userDialogService.Toast("Email de verificación enviado a la dirección de correo");
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
            else
            {
                _userDialogService.Toast("El Usuario introducido no es válido");
            }

        }
        public String Username
        {
            get {return _username; }
            set {_username=value; RaisePropertyChanged(); }
        }

        public String Password
        {
            get { return _password; }
            set {_password=value; RaisePropertyChanged(); }
        }
    }
}
