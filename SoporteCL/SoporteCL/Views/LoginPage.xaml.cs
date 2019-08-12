using SoporteCL.Helpers;
using SoporteCL.Login;
using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoporteCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]  
    public partial class LoginPage : ContentPage
    {
        /*  private  IProfileStore<Profile> ProfileStore => DependencyService.Get<IProfileStore<Profile>>();
          private ObservableRangeCollection<Profile> perfiles;*/
        public LoginViewModel loginviewmodel;
        public ILoginManager iml;

        private Profile perfil;
        public LoginPage(ILoginManager iml)
        {
            InitializeComponent();
            this.iml = iml;
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
            });
            BindingContext = loginviewmodel = new LoginViewModel();
        }
        /* void async perfileslist()
         {
             var profiles = await ProfileStore.GetAllProfileAsync();
             perfiles.AddRange(profiles);
         }*/
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loginviewmodel.LoadProfilesCommand.Execute(null);
        }
        void PerfilSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            perfil=(Profile)picker.SelectedItem;
            Debug.WriteLine(perfil.Nombre);

        }
        void BtnLoginClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["name"] = perfil;
            Application.Current.Properties["IsLoggedIn"] = true;
            iml.ShowMainPage();
        }
    }
}