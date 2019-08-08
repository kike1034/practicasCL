using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/*
 * Interfaz de la base de datos simulada. Contiene la definicion de todos los metodos que gestionan datos del Modelo
 */
namespace SoporteCL.Services
{
    public interface INotificationStore<T>
    {
        //Metodo que añade una Notificacion nueva a la base de datos
        Task<bool> AddNotificacionAsync(T notificacion);
        //Metodo que actualiza los datos de una Notificacion de la base de datos
        Task<bool> UpdateNotificacionAsync(T notificacion);
        //Metodo que borra la Notificacion de la base de datos dado su Id
        Task<bool> DeleteNotificacionAsync(string id);
        //Metodo que borra la Notificacion de la base de datos 
        Task<bool> DeleteNotificacionAsync(T notificacion);
        //Metodo que busca y devuelve una Notificacion de la base de datos dado su Id
        Task<T> GetNotificacionAsync(string id);
        //Metodo que busca y devuelve una lista con todas las Notificaciones de la base de datos
        Task<T> GetNotificacionAsync(T notificacion);
        Task<IEnumerable<T>> GetAllNotificacionesAsync();
        //Metodo que busca y devuelve una lista con todas las Notificaciones que no han sido leidas de la base de datos
        Task<IEnumerable<T>> GetAllUnreadNotificacionesAsync();
    }
}
