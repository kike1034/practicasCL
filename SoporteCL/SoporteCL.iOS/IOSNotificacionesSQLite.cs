using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SoporteCL.iOS;
using SoporteCL.Services;
using SQLite;
using UIKit;

/*
 * Clase que establece conexion con la base de datos SQLite con la plataforma iOS.
 * TODO: comprobar que se encuentra el path a la base de datos y que se establece la conexion
 */
[assembly: Xamarin.Forms.Dependency(typeof(IOSNotificacionesSQLite))]
namespace SoporteCL.iOS
{
    public class IOSNotificacionesSQLite : INotificacionesSQLite
    {
        private string GetPath()
        {
            var dbName = "test.db";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
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