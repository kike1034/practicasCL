using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoporteCL.Models;
using SQLite;

/*
 * Base de datos simulada. Implementa los metodos definidos en INotificationStore
 * TODO: para cada referencia a cada metodo, sustituirlo por un metodo de la base de datos actual
 */
namespace SoporteCL.Services
{
    public class MockNotificationStore : INotificationStore<Notificacion>
    {
        //Lista de notificaciones que simula la tabla de base de datos
        List<Notificacion> listNotif;
        readonly SQLiteAsyncConnection database;

        public MockNotificationStore()
        {
            NotificacionesSQLite notifsq = new NotificacionesSQLite();
            database = notifsq.GetConnectionAsync();
            listNotif = new List<Notificacion>();
        }

        //Metodo que añade una Notificacion nueva a la base de datos
        public async Task<bool> AddNotificacionAsync(Notificacion notificacion)
        {
            listNotif.Add(notificacion);
           /* Console.WriteLine("holaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine(notificacion.Contenido);*/
           // return  database.InsertAsync(notificacion);

            return await Task.FromResult(true);
        }

        //Metodo que actualiza los datos de una Notificacion de la base de datos
        public async Task<bool> UpdateNotificacionAsync(Notificacion notificacion)
        {
            var oldNotif = listNotif.Where((Notificacion arg) => arg.Id == notificacion.Id).FirstOrDefault();
            listNotif.Remove(oldNotif);
            listNotif.Add(notificacion);

            return await Task.FromResult(true);
        }

        //Metodo que borra la Notificacion de la base de datos dado su Id
        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            var oldNotif = listNotif.Where((Notificacion arg) => arg.Id == id).FirstOrDefault();
            listNotif.Remove(oldNotif);

            return await Task.FromResult(true);
        }

        //Metodo que busca y devuelve una Notificacion de la base de datos dado su Id
        public async Task<Notificacion> GetNotificacionAsync(int id)
        {
            return await Task.FromResult(listNotif.FirstOrDefault(s => s.Id == id));
        }

        //Metodo que busca y devuelve una lista con todas las Notificaciones de la base de datos
        public async Task<IEnumerable<Notificacion>> GetAllNotificacionesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(listNotif);
        }

        //Metodo que busca y devuelve una lista con todas las Notificaciones que no han sido leidas de la base de datos
        public async Task<IEnumerable<Notificacion>> GetAllUnreadNotificacionesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(listNotif.Where((Notificacion arg) => arg.Leido == 0));
        }
    }
}
