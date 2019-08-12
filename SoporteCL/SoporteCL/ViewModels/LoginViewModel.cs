using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoporteCL.ViewModels
{
    public class LoginViewModel : ObservableObject//: CarouselPage
    {
        //readonly ContentPage login;
        public IProfileStore<Profile> ProfilStore => DependencyService.Get<IProfileStore<Profile>>();

        public ObservableRangeCollection<Profile> Profiles { get; set; }

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
        }
        public LoginViewModel()/*ILoginManager ilm*/
        {
            /*login = new LoginPage(ilm);
            this.Children.Add(login);
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = login;
            });*/
            Profiles = new ObservableRangeCollection<Profile>();
            LoadProfilesCommand=new Command(async () => await ExecuteLoadProfiles());
           /* var profiles=ProfilStore.NumberofProfilesAsync();
            Debug.WriteLine("hola {0}",profiles);*/
        }

        private async Task ExecuteLoadProfiles()
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
        }
    }
}
