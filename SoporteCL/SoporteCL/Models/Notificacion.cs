using SQLite;
using System;

/*
 *  Clase Modelo para el objeto Notificacion que se mostrara en las vistas y almacenará en la base de datos
 */
namespace SoporteCL.Models
{
    public class Notificacion : BaseDataObject
    {
        //Asunto o titulo de la notificacion
        string asunto;
        public string Asunto { get { return asunto; } set { SetProperty(ref asunto, value); } }
        //Usuario que envia la notificacion
        //TODO: si se implementa verificacion de usuario, asignarlo como fuente en creacion de nuevas notificaciones (usuario identificado)
        string fuente;
        public string Fuente { get { return fuente; } set { SetProperty(ref fuente, value); } }
        //Usuario que recibira la Notificacion
        string destino;
        public string Destino { get { return destino; } set { SetProperty(ref destino, value); }}
        //Parametro que indica si se enviará la notificacion a un solo usuario o a todos los de una red de negocio
        string tipoTarget;
        public string TipoTarget { get { return tipoTarget; } set { SetProperty(ref tipoTarget, value); } }
        //Contenido de la notificacion
        string contenido;
        public string Contenido { get { return contenido; } set { SetProperty(ref contenido, value); } }
        //Parametro que indica si la Notificacion ha sido leida o no
        int leido;
        public int Leido { get { return leido; } set { SetProperty(ref leido, value); } }

        DateTime fecha;
        public DateTime Fecha { get { return fecha; } set { SetProperty(ref fecha, value); } }

        //Constructor por copia de Notificacion
        public Notificacion(Notificacion notif)
        {
            Asunto = notif.Asunto;
            Fuente = notif.Fuente;
            Destino = notif.Destino;
            TipoTarget = notif.TipoTarget;
            Contenido = notif.Contenido;
            Leido = notif.Leido;
            Fecha = notif.Fecha;
        }

        //Constructor por defecto de Notificacion
        public Notificacion()
        {
        }
    }
}
