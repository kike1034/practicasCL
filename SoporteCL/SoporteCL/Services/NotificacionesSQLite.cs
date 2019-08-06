using SQLite;
using System;

namespace SoporteCL.Services
{
    class NotificacionesSQLite : INotificacionesSQLite
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                return new SQLiteConnection("C:\\Users\\jamigo\\sql_dbs\\test.db");
            }
            catch (Exception e)
            {
               throw new Exception("No se ha podido conectar a la base de datos debido a: "+ e);
            }
           
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            try
            {
                return new SQLiteAsyncConnection("C:\\Users\\jamigo\\sql_dbs\\test.db",SQLiteOpenFlags.Create|SQLiteOpenFlags.ReadWrite);
            }
            catch (Exception e)
            {
                throw new Exception("No se ha podido conectar a la base de datos debido a: " + e);
            }
            
        }
    }
}
