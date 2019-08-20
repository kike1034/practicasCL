using SoporteCL.Helpers;
using SoporteCL.Login;
using SoporteCL.Models;
using SoporteCL.Services;
using SoporteCL.ViewModels;
using SoporteCL.ViewModels.Login;
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
    //[XamlCompilation(XamlCompilationOptions.Compile)]  
    public partial class LoginPage : ContentPage
    {
        /*  private  IProfileStore<Profile> ProfileStore => DependencyService.Get<IProfileStore<Profile>>();
          private ObservableRangeCollection<Profile> perfiles;*/
        LoginViewModel loginviewmodel;
        public LoginPage()
        {
            InitializeComponent();
           /* this.iml = iml;
            BindingContext = loginviewmodel = new LoginViewModel();*/
        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            loginviewmodel = BindingContext as LoginViewModel;
            //if (loginviewmodel != null) loginviewmodel.OnAppearing(null);
        }
      
    }
}