using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

/*
 * Pagina principal de la aplicación: una página etiquetada.
 */
namespace SoporteCL.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            //Deshabilitar la navegacion entre etiquetas mediante deslizamiento (Swipe) para Android
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
        void BtnLogoutClicked(object sender, EventArgs e)
        {
            Application.Current.Logout();
        }
    }
}