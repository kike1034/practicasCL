using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoporteCL.Services
{
    public interface IProfileStore<T>
    {
            
        //Metodo que añade un Perfil nueva a la base de datos
        Task<bool> AddProfileAsync(T profile);
        //Metodo que actualiza los datos de un Perfil de la base de datos
        Task<bool> UpdateProfileAsync(T profile);
        //Metodo que borra el Perfil de la base de datos dado su Id
        Task<bool> DeleteProfileAsync(string id);
        //Metodo que borra el Perfil de la base de datos 
        Task<bool> DeleteProfileAsync(T profile);
        //Metodo que busca y devuelve un Perfil de la base de datos dado su Id
        Task<T> GetProfileAsync(string id);
        //Metodo que busca y devuelve un Perfil con todas las Profilees de la base de datos
        Task<T> GetProfileAsync(T profile);
        Task<IEnumerable<T>> GetAllProfileAsync();

        Task<int> NumberofProfilesAsync();
    }
}

