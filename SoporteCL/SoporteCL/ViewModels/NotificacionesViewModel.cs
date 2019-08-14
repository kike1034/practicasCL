
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.ViewModels.Base;
using SoporteCL.Views;
using Xamarin.Forms;

/*
 * ViewModel que contiene y gestiona los datos de las Notificaciones y las muestra en la vista Notificaciones
 */
namespace SoporteCL.ViewModels
{
   /* public abstract class NotificacionesViewModel : BaseViewModel
    {
        //Colleccion de Notificaciones no leidas que seran observables
        public ObservableRangeCollection<Notificacion> Notifs { get; set; }

        //Comando que permitira recargar la lista de Notificaciones
        public Command LoadNotifsCommand { get; set; }

        //Comando para eliminar una notificacion
        public Command DeleteNotifsCommand { get; set; }
       
        //Comando para leer las notificaciones
        
        public Command ReadNotifsCommand { get; set; }

        public NotificacionesViewModel()
        {
            Notifs = new ObservableRangeCollection<Notificacion>();

            //Se crea un comando que ejecuta el metodo asincrono de recarga
            LoadNotifsCommand = new Command(async () => await ExecuteLoadNotifs());

            DeleteNotifsCommand = new Command<Notificacion>(DeleteNotif);

            ReadNotifsCommand = new Command<Notificacion>(ReadNotif);

        }

        private async void ReadNotif(Notificacion updateNotif)
        {
            if (updateNotif.Leido == 0)
            {
                updateNotif.Leido = 1;
                await NotifStore.UpdateNotificacionAsync(updateNotif);
                await ExecuteLoadNotifs();
            }

        }

        private async void DeleteNotif(Notificacion notif)
        {
            var notifToDelete = await NotifStore.GetNotificacionAsync(notif.Id);
            if (notifToDelete != null) await NotifStore.DeleteNotificacionAsync(notifToDelete);
            else
            {
                Debug.WriteLine("Error al borrar la notificacion");
            }
            await ExecuteLoadNotifs();
        }

        //Metodo asincrono para recargar la pagina. Cuando el hilo no este ocupado, se vaciara la lista del ViewModel y se volveran a cargar en ella las Notificaciones de la base de datos
        public abstract Task ExecuteLoadNotifs();
    }*/
}
