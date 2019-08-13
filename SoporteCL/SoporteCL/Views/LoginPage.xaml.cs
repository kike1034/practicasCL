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
            App.Current.Properties["name"] = perfil;
            App.Current.Properties["IsLoggedIn"] = true;
           // MessagingCenter.Unsubscribe<ContentPage>(this, "Login");
            iml.ShowMainPage();
        }
    }
}