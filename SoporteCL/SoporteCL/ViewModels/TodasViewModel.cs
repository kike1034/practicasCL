using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoporteCL.ViewModels
{
    class TodasViewModel : NotificacionesViewModel
    {
        public TodasViewModel()
        {
            Title = "Notificaciones recibidas";
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
                        // Debug.WriteLine("New notification for user NOTIFID: {0}", NotifStore.GetNotificacionAsync(notif).Id);
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
                            //Debug.WriteLine("New notification for WorkNet ID: {0}", notifRed.Id);
                            //total++;
                        }
                        break;
                }
            });
        }
        public async override Task ExecuteLoadNotifs()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notifs.Clear();
                var notificaciones = await NotifStore.GetAllNotificacionesAsync();
                Notifs.ReplaceRange(notificaciones);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load notifs",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
