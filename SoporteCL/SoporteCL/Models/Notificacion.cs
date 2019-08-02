using SQLite;

/*
 *  Clase Modelo para el objeto Notificacion que se mostrara en las vistas y almacenará en la base de datos
 */
namespace SoporteCL.Models
{
    public class Notificacion
    {
        //Identificador, llave primaria
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Asunto o titulo de la notificacion
        public string Asunto { get; set; }
        //Usuario que envia la notificacion
        //TODO: si se implementa verificacion de usuario, asignarlo como fuente en creacion de nuevas notificaciones (usuario identificado)
        public string Fuente { get; set; }
        //Usuario que recibira la Notificacion
        public string Destino { get; set; }
        //Parametro que indica si se enviará la notificacion a un solo usuario o a todos los de una red de negocio
        public string TipoTarget { get; set; }
        //Contenido de la notificacion
        public string Contenido { get; set; }
        //Parametro que indica si la Notificacion ha sido leida o no
        //TODO: configurar codigo para utilizarlo para su control en la interfaz (icono de leido en vista Notificaciones)
        public int Leido { get; set; }

        //TODO: eliminar este parametro y en su lugar utilizar Leido para su control en la interfaz (icono de leido en vista Notificaciones)
        public bool Visible { get; set; }

        //Constructor por copia de Notificacion
        public Notificacion(Notificacion notif)
        {
            Asunto = notif.Asunto;
            Fuente = notif.Fuente;
            Destino = notif.Destino;
            TipoTarget = notif.TipoTarget;
            Contenido = notif.Contenido;
            Leido = notif.Leido;
            Visible = notif.Visible;
        }

        //Constructor por defecto de Notificacion
        public Notificacion()
        {
        }
    }
}
