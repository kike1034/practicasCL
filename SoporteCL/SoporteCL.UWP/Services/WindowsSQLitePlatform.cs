using System.IO;
using Windows.Storage;
using SQLite;
using SoporteCL.Services;
using SoporteCL.UWP.Services;
[assembly: Xamarin.Forms.Dependency(typeof(WindowsSQLitePlatform))]
namespace SoporteCL.UWP.Services
{
    public class WindowsSQLitePlatform : ISQLitePlatform
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