using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoporteCL.Models
{
    public class User : BaseDataObject
    {
        //Nombre del usuario
        string nombre;
        public string Nombre { get { return nombre; } set { SetProperty(ref nombre, value); } }

        //Password del user
        string password;
        public string Passwoprd { get { return password; } set { SetProperty(ref password, value); } }


        //Telefono del usuario
        int telefono;

        public int Telefono { get { return telefono; } set { SetProperty(ref telefono, value); } }

        //Codigo del perfil, clave externa a tabla Profiles.
        [ForeignKey("Profile")]
        string codperfil;

        public string Codperfil { get { return codperfil; } set { SetProperty(ref codperfil, value); } }

        public User(User user)
        {
            nombre = user.nombre;
            telefono = user.telefono;
            codperfil = user.codperfil;
        }
        public User()
        {
        }
    }
}
