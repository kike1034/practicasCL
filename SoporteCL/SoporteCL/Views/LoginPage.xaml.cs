using SoporteCL.ViewModels;
using System;
using System.Collections.Generic;
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
        public LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext= loginViewModel = new LoginViewModel();
        }
    }
}