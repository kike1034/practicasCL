using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoporteCL.Services;
using SoporteCL.UWP;
using SQLite;
using Windows.Storage;

/*
 * Clase que establece conexion con la base de datos SQLite con la plataforma UWP.
 * TODO: comprobar que se encuentra el path a la base de datos y que se establece la conexion
 */
[assembly: Xamarin.Forms.Dependency(typeof(WindowsNotificacionesSQLite))]
namespace SoporteCL.UWP
{
    public class WindowsNotificacionesSQLite : INotificacionesSQLite
    {
        private string GetPath()
        {
            var dbName = "test.db";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
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
