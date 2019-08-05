using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoporteCL.Models;
using SoporteCL.Views;
using Xamarin.Forms;

/*
 * ViewModel que contiene y gestiona los datos de las Notificaciones no leidas y las muestra en la vista NotificacionesNoLeidas
 */
namespace SoporteCL.ViewModels
{
    public class NoLeidosViewModel : BaseViewModel
    {
        //Colleccion de Notificaciones no leidas que seran observables
        public ObservableCollection<Notificacion> UnreadNotifs { get; set; }

        //Comando que permitira recargar la lista de Notificaciones
        public Command LoadUnreadCommand { get; set; }

        public NoLeidosViewModel()
        {
            Title = "Notificaciones no leidas";
            UnreadNotifs = new ObservableCollection<Notificacion>();

            //Se crea un comando que ejecuta el metodo asincrono de recarga
            LoadUnreadCommand = new Command(async () => await ExecuteLoadUnread());

            //Se subscribe a la vista un comando asincrono para borrar notificaciones de la lista
            MessagingCenter.Subscribe<NotificacionesNoLeidas, int>(this, "DeleteNotificacion", async (obj, id) =>
            {
                //Comprobar si la notificacion existe en la base de datos. Si existe, borrarla
                var notifToDelete = await NotifStore.GetNotificacionAsync(id);
                if (notifToDelete != null)
                {
                    UnreadNotifs.Remove(notifToDelete);
                    await NotifStore.DeleteNotificacionAsync(id);
                }
                //Se ejecuta comando de recarga
                LoadUnreadCommand.Execute(null);
            });

            //Se subscribe a la vista un comando asincrono para modificar notificaciones de la lista como leidas
            MessagingCenter.Subscribe<NotificacionesNoLeidas, Notificacion>(this, "MarkAsReadNotificacion", async (obj, notif) =>
            {
                var updateNotif = notif as Notificacion;
                int index = UnreadNotifs.IndexOf(updateNotif);
                updateNotif.Leido = 1;
                updateNotif.Visible = false;
                await NotifStore.UpdateNotificacionAsync(updateNotif);
                UnreadNotifs.Remove(notif);
                //Se ejecuta comando de recarga
                LoadUnreadCommand.Execute(null);
            });

        }

        //Metodo asincrono para recargar la pagina. Cuando el hilo no este ocupado, se vaciara la lista del ViewModel y se volveran a cargar en ella las Notificaciones (no leidas) de la base de datos
        async Task ExecuteLoadUnread()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                UnreadNotifs.Clear();
                var notificaciones = await NotifStore.GetAllUnreadNotificacionesAsync(true);
                foreach (var n in notificaciones)
                {
                    UnreadNotifs.Add(n);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
