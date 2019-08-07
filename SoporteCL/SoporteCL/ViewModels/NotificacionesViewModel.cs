using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Views;
using Xamarin.Forms;

/*
 * ViewModel que contiene y gestiona los datos de las Notificaciones y las muestra en la vista Notificaciones
 */
namespace SoporteCL.ViewModels
{
    public class NotificacionesViewModel : BaseViewModel
    {
        //Colleccion de Notificaciones no leidas que seran observables
        public ObservableRangeCollection<Notificacion> Notifs { get; set; }
        
        //TODO: eliminar variable que sera reemplazada por sequence en base de datos o identificador autoincrementado
       // int total;

        //Comando que permitira recargar la lista de Notificaciones
        public Command LoadNotifsCommand { get; set; }

        //Comando para eliminar una notificacion
        public Command DeleteNotifsCommand { get; set; }

        //Lista de redes de negocios disponibles para envio masivo de notificaciones
        readonly public List<string> redesNegocio = new List<string>();

        public NotificacionesViewModel()
        {
            Title = "Notificaciones recibidas";
            Notifs = new ObservableRangeCollection<Notificacion>();
            //total = 0;

            //Se crea un comando que ejecuta el metodo asincrono de recarga
            LoadNotifsCommand = new Command(async () => await ExecuteLoadNotifs());

            DeleteNotifsCommand = new Command<Notificacion>(DeleteNotif);

            //TODO: Reemplazar con nueva operacion en la base de datos para obtener todas las redes de negocios
            redesNegocio.Add("DI");
            redesNegocio.Add("JG");
            redesNegocio.Add("SU");
            redesNegocio.Add("DA");
            redesNegocio.Add("DR");
            redesNegocio.Add("DN");

            MessagingCenter.Subscribe<NuevaNotificacion, Notificacion>(this, "AddNotificacion", async (obj, notif) =>
            {
                
                //switch para añadir segun el TipoTarget
                switch (notif.TipoTarget)
                {
                    case "Usuario": //Si target es un solo usuario, se crea la nueva notificacion y se añade a la lista del ViewModel
                        var newNotif = notif as Notificacion;
                      //  newNotif.Id = total;
                        Notifs.Add(newNotif);
                        await NotifStore.AddNotificacionAsync(newNotif);
                        Debug.WriteLine("New notification ID: {0}", newNotif.Id);
                       // total++;
                        break;
                    case "RedNegocio": //Si target es Red de Negocio, se creara una notificacion por cada red de negocio de nivel inferior, incluyendo la propia
                        //TODO: cuando base de datos este conectada, crear nueva operacion para obtener todos los usuarios de una red de negocio e inferiores y enviar una notificacion nueva a todos
                        int RN = redesNegocio.IndexOf(notif.Destino);
                        for (int i = 0; i <= RN; i++)
                        {
                            Notificacion notifRed = new Notificacion(notif);
                            //notifRed.Id = total;
                            foreach (var item in redesNegocio)
                            {
                                if (redesNegocio.IndexOf(item) == i) notifRed.Destino = item;
                            }
                            Notifs.Add(notifRed);
                            await NotifStore.AddNotificacionAsync(notifRed);
                            //total++;
                        }
                        break;
                }
            });

            //Se subscribe a la vista un comando asincrono para borrar notificaciones de la lista
            MessagingCenter.Subscribe<Notificaciones, int>(this, "DeleteNotificacion", async (obj, id) =>
            {
                //Comprobar si la notificacion existe en la base de datos. Si existe, borrarla
                var notifToDelete = await NotifStore.GetNotificacionAsync(id);
                if (notifToDelete != null)
                {
                    Notifs.Remove(notifToDelete);
                    await NotifStore.DeleteNotificacionAsync(id);
                }
                //Se ejecuta comando de recarga
                LoadNotifsCommand.Execute(null);
            });

            //Se subscribe a la vista un comando asincrono para modificar notificaciones de la lista como leidas
            MessagingCenter.Subscribe<Notificaciones, Notificacion>(this, "MarkAsReadNotificacion", async (obj, notif) =>
            {
                var updateNotif = notif as Notificacion;
                int index = Notifs.IndexOf(updateNotif);
                updateNotif.Leido = 1;
                Notifs[index].Leido = 1;
                updateNotif.Visible = 0;
                Notifs[index].Visible = 0;
                await NotifStore.UpdateNotificacionAsync(updateNotif);
                //Se ejecuta comando de recarga
                LoadNotifsCommand.Execute(null);
            });

        }

        private void DeleteNotif(Notificacion obj)
        {
            throw new NotImplementedException();
        }

        //Metodo asincrono para recargar la pagina. Cuando el hilo no este ocupado, se vaciara la lista del ViewModel y se volveran a cargar en ella las Notificaciones de la base de datos
        async Task ExecuteLoadNotifs()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var notificaciones = await NotifStore.GetAllNotificacionesAsync(true);
                //var notificaciones = await App.database.GetAllNotificacionesAsync();
                Notifs.Clear();
                foreach (var n in notificaciones)
                    {
                        n.Visible = (n.Leido == 0) ? 1:0; //TODO: eliminar esta linea de codigo
                        Notifs.Add(n);
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
