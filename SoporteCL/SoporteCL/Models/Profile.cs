using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoporteCL.Models
{
    public class Profile : BaseDataObject
    {
        //Nombre del perfil SU, CRISTIANLAY...
        string nombre;
        public string Nombre { get { return nombre; } set { SetProperty(ref nombre, value); } }

        //Jerarquía del perfil: Determina a quien le envia las notificacioens
        int jerarquia;

        public int Jerarquia {get { return jerarquia;} set { SetProperty(ref jerarquia, value); } }

        public Profile(Profile profile)
        {
            nombre = profile.nombre;
            jerarquia = profile.jerarquia;
        }
        public Profile()
        {

        }

    }
}
