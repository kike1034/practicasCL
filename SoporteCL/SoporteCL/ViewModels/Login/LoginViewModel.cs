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
        //readonly ContentPage login;
        /* public IProfileStore<Profile> ProfilStore => DependencyService.Get<IProfileStore<Profile>>();

         public ObservableRangeCollection<Profile> Profiles { get; set; }

         private IFirebaseAuthService _firebaseService;
         public Command LoadProfilesCommand { get; set; }

         bool isBusy = false;
         public bool IsBusy
         {
             get { return isBusy; }
             set { SetProperty(ref isBusy, value); }
         }

         //Titulo de la vista, mostrado en la barra de herramientas
         string title = "Login";
         public string Title
         {
             get { return title; }
             set { SetProperty(ref title, value); }
         }*/
        private ICommand _signUpCommand;
        private ICommand _loginCommand;
        private ICommand _loginGoogleCommand;


        private String _username;
        private String _password;

        private IUserDialogs _userDialogService;

        private IFirebaseAuthService _firebaseService;
        public LoginViewModel(IUserDialogs userDialogsService)/*ILoginManager ilm*/
        {
            /*login = new LoginPage(ilm);
            this.Children.Add(login);
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = login;
            });
            Profiles = new ObservableRangeCollection<Profile>();
            LoadProfilesCommand=new Command(async () => await ExecuteLoadProfiles());
            var profiles=ProfilStore.NumberofProfilesAsync();
            Debug.WriteLine("hola {0}",profiles);*/
            _userDialogService = userDialogsService;
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();
            MessagingCenter.Subscribe<String, String>(this, _firebaseService.getAuthKey(), async (sender, args) =>
            {
               await LoginGoogle(args);

            });
        }
        public ICommand SignUpCommand
        {
            get { return _signUpCommand = _signUpCommand ?? new DelegateCommandAsync(SignUpCommandExecute); }
        }

        public ICommand LoginGoogleCommand
        {
            get { return _loginGoogleCommand = _loginGoogleCommand ?? new DelegateCommandAsync(LoginGoogleCommandExecute); }
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


        private async Task LoginGoogleCommandExecute()
        {
            _firebaseService.SignInWithGoogle();

        }

        private async Task LoginGoogle(String token)
        {
            if (await _firebaseService.SignInWithGoogle(token))
            {
                await NavigationService.NavigateToAsync<MainViewModel>();
            }

        }
        /* private async Task ExecuteLoadProfiles()
         {
             if (IsBusy)
                 return;

             IsBusy = true;

             try
             {
                 Profiles.Clear();
                 var perfiles = await ProfilStore.GetAllProfileAsync();
                 Profiles.ReplaceRange(perfiles);
             }
             catch (Exception ex)
             {
                 Debug.WriteLine(ex);
                 MessagingCenter.Send(new MessagingCenterAlert
                 {
                     Title = "Error",
                     Message = "Unable to load profiles",
                     Cancel = "OK"
                 }, "message");
             }
             finally
             {
                 IsBusy = false;
             }
         }¨*/
    }
}
