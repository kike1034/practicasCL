using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SoporteCL.Views;
using System.IO;
using SoporteCL.Login;

/*
 * Modulo de inicio del proyecto PCL, invocado por clase principal de cada plataforma. Carga la vista principal de la aplicación.
 */
namespace SoporteCL
{
    public partial class App : Xamarin.Forms.Application, ILoginManager
    {

        //public static NotificacionesDatabase database;
        public new static App Current;

        private MainPage main;
        public App()
        {
            InitializeComponent();
            Current = this;
            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
            if (isLoggedIn)
            {
                if (main == null) MainPage = main = new MainPage();
                else MainPage = main;
            }
            else
            {
                MainPage = new LoginPage(this);
            }           
        }

        public void Logout()
        {
            Properties["IsLoggedIn"] = false;
            Properties.Remove("name");
            MainPage = new LoginPage(this);
        }

        public void ShowMainPage()
        {       
            if (main == null) MainPage = main = new MainPage();
            else MainPage = main;
        }
       



        //public static NotificacionesDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new NotificacionesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.db"));
        //        }
        //        return database;
        //    }
        //}

    }
}
