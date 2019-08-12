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
    public partial class Application : Xamarin.Forms.Application, ILoginManager
    {

        //public static NotificacionesDatabase database;
        public new static Application Current;
        public Application()
        {
            InitializeComponent();
            Current = this;
            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
            if (isLoggedIn) MainPage = new MainPage();
            else MainPage = new LoginPage(this);
            //Añadir base de datos simulada al servicio de dependencias para responder a cambios sobre los datos.
            //DependencyService.Register<MockNotificationStore>();

            
        }

        public void Logout()
        {
            Application.Current.Properties["IsLoggedIn"] = false;
            MainPage = new LoginPage(this);
        }

        public void ShowMainPage()
        {
            MainPage = new MainPage();
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
