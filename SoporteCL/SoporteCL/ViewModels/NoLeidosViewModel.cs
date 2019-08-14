using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SoporteCL.Helpers;
using Xamarin.Forms;

/*
 * ViewModel que contiene y gestiona los datos de las Notificaciones no leidas y las muestra en la vista NotificacionesNoLeidas
 */
namespace SoporteCL.ViewModels
{
    /*public class NoLeidosViewModel : MainViewModel
    {

        public NoLeidosViewModel()
        {
            Title = "Notificaciones no leidas";
        }
        public async override Task ExecuteLoadNotifs()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notifs.Clear();
                var notificaciones = await NotifStore.GetAllUnreadNotificacionesAsync();
                Notifs.ReplaceRange(notificaciones);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load unread notifs",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }*/
}
