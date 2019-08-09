using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoporteCL.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public IProfileStore<Profile> ProfileStore => DependencyService.Get<IProfileStore<Profile>>();

        string title = "Login";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        //Lista de profiles
        public ObservableRangeCollection<Profile> Profiles { get; set; }

        //Comando que permite hacer el login
        public Command LoginCommand { get; set; }

        //Comando que permite hacer el logout
        public Command LogoutCommand { get; set; }

        public Command LoadProfilesCommand { get; set; }

        public LoginViewModel()
        {
            Profiles = new ObservableRangeCollection<Profile>();

            LoadProfilesCommand = new Command(async () => await ExecuteLoadProfiles());

            LoginCommand = new Command<Profile>(Login);

            LogoutCommand = new Command(Logout);
        }

        private void Logout()
        {
            Application.Current.Properties["IsLoggedIn"] = false;
        }

        private void Login(Profile profile)
        {
            Application.Current.Properties["IsLoggedIn"] = true;
            Application.Current.Properties["name"] = profile;
        }

        private async Task ExecuteLoadProfiles()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Profiles.Clear();
                var profiles = await ProfileStore.GetAllProfileAsync();
                Profiles.ReplaceRange(profiles);
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
        }
    }
}
