using Acr.UserDialogs;
using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.Services.FirebaseAuth;
using SoporteCL.Services.Navigation;
using SoporteCL.ViewModels.Base;
using SoporteCL.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SoporteCL.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel//: CarouselPage
    {
        private ICommand _signUpCommand;
        private ICommand _loginCommand;
        private ICommand _loginGoogleCommand;


        private String _username;
        private String _password;

        private IUserDialogs _userDialogService;

        private IFirebaseAuthService _firebaseService;
        public LoginViewModel(IUserDialogs userDialogsService)
        {
            _userDialogService = userDialogsService;
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();
        }
        public ICommand SignUpCommand
        {
            get { return _signUpCommand = _signUpCommand ?? new DelegateCommandAsync(SignUpCommandExecute); }
        }
        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommandAsync(LoginCommandExecute); }
        }
        public String Username
        {
            get {return _username;}
            set {_username=value; RaisePropertyChanged(); }
        }

        public String Password
        {
            get {return _password;}
            set{ _password = value; }
        }

        private async Task LoginCommandExecute()
        {
            if (await _firebaseService.SignIn(Username, Password))
            {
               
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
            else
            {
                _userDialogService.Toast("Usuario o contraseña incorrectos");
            }

        }

        private async Task SignUpCommandExecute()
        {
            await NavigationService.NavigateToAsync<SignUpViewModel>();
        }
    }
}
