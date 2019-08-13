using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoporteCL.Services
{
    interface IUserStore <T>
    {
        //Metodo que añade un User nuevo a la base de datos
        Task<bool> AddUserAsync(T user);
        //Metodo que actualiza los datos de un User de la base de datos
        Task<bool> UpdateUserAsync(T user);
        //Metodo que borra el User de la base de datos dado su Id
        Task<bool> DeleteUserAsync(string id);
        //Metodo que borra el User de la base de datos dado su nombre
        Task<bool> DeleteUserbyNameAsync(string name);
        //Metodo que busca y devuelve un User de la base de datos dado su Id
        Task<T> GetUserAsync(string id);
        //Metodo que busca y devuelve un User de la base de datos dado su nombre
        Task<T> GetUserbyName(string name);
        //Método que busca y devuelve todos los users
        Task<IEnumerable<T>> GetAllUsersAsync();

    }
}
