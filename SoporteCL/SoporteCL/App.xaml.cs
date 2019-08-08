using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SoporteCL.Services;
using SoporteCL.Views;
using System.IO;

/*
 * Modulo de inicio del proyecto PCL, invocado por clase principal de cada plataforma. Carga la vista principal de la aplicación.
 */
namespace SoporteCL
{
    public partial class App : Application
    {
        
        //public static NotificacionesDatabase database;

        public App()
        {
            InitializeComponent();

            //Añadir base de datos simulada al servicio de dependencias para responder a cambios sobre los datos.
            //DependencyService.Register<MockNotificationStore>();
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
