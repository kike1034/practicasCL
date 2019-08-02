using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SoporteCL.Models;
using SQLite;

/*
 * Base de datos SQLite e implementacion de los metodos utilizados para realizar operaciones sobre ella.
 */
namespace SoporteCL.Services
{
    public class NotificacionesDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NotificacionesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            
        }

        //Metodo que añade una Notificacion nueva a la base de datos
        public Task<int> AddNotificacionAsync(Notificacion notificacion)
        {
            return database.InsertAsync(notificacion);
        }

        //Metodo que actualiza los datos de una Notificacion de la base de datos
        public Task<int> UpdateNotificacionAsync(Notificacion notificacion)
        {
            return database.UpdateAsync(notificacion);
        }

        //Metodo que borra la Notificacion de la base de datos dado su Id
        public Task<int> DeleteNotificacionAsync(Notificacion notificacion)
        {
            return database.DeleteAsync(notificacion);
        }

        //Metodo que busca y devuelve una Notificacion de la base de datos dado su Id
        public Task<Notificacion> GetNotificacionAsync(int id)
        {
            return database.GetAsync<Notificacion>(id);
        }

        //Metodo que busca y devuelve una lista con todas las Notificaciones de la base de datos
        public Task<List<Notificacion>> GetAllNotificacionesAsync()
        {
            return database.QueryAsync<Notificacion>("SELECT * FROM Notificaciones");
        }

        //Metodo que busca y devuelve una lista con todas las Notificaciones que no han sido leidas de la base de datos
        public Task<List<Notificacion>> GetAllUnreadNotificacionesAsync()
        {
            return database.QueryAsync<Notificacion>("SELECT * FROM Notificaciones WHERE Leido = 0");
        }
    }
}
