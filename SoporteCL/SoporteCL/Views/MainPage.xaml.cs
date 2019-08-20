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
    public partial class MainPage : ContentPage
    {
        private MainViewModel mainviewmodel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            mainviewmodel = BindingContext as MainViewModel;
            //if (loginviewmodel != null) loginviewmodel.OnAppearing(null);
        }
    }
}