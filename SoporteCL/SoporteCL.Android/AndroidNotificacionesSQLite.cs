using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SoporteCL.Droid;
using SoporteCL.Services;
using SQLite;

/*
 * Clase que establece conexion con la base de datos SQLite con la plataforma Android.
 * TODO: comprobar que se encuentra el path a la base de datos y que se establece la conexion
 */
[assembly: Xamarin.Forms.Dependency(typeof(AndroidNotificacionesSQLite))]
namespace SoporteCL.Droid
{
    public class AndroidNotificacionesSQLite : INotificacionesSQLite
    {
        private string GetPath()
        {
            var dbName = "test.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}