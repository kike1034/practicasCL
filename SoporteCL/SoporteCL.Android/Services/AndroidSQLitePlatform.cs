using System.IO;
using SQLite;
using SoporteCL.Services;
using SoporteCL.Droid.Services;
[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLitePlatform))]
namespace SoporteCL.Droid.Services
{
    public class AndroidSQLitePlatform : ISQLitePlatform
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