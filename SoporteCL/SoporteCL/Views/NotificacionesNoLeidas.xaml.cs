using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoporteCL.Models;
using SoporteCL.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/*
 * Vista mostrada en la etiqueta de No Leidas.Esta clase contiene el codigo que gestiona las interacciones del usuario con la lista de datos.
 */
namespace SoporteCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesNoLeidas : ContentPage
    {
        //ViewModel que toma los datos y los muestra en la vista. Cambios en los datos del ViewModel se reflejaran en la vista
        public NoLeidosViewModel notifViewModel;

        public NotificacionesNoLeidas()
        {
            InitializeComponent();
            //El contexto del binding se asigna al ViewModel para acceder a la lista de notificaciones y comando de recarga
            BindingContext = notifViewModel = new NoLeidosViewModel();
        }

        //Metodo que se ejecuta automaticamente cuando la vista aparece en la aplicacion (se muestra por pantalla)
        protected override void OnAppearing()
        {
            //Se ejecuta el comando de carga de datos del ViewModel cuando se muestre la vista
            if (notifViewModel.Notifs.Count == 0)
                notifViewModel.LoadNotifsCommand.Execute(null);
        }

        /*private async void NuevaNotificacion_Clicked(object sender, EventArgs e)
        {
            //PushAsync coloca una nueva vista en la pila de navegacion, abriendo una nueva pantalla.
            await Navigation.PushAsync(new NuevaNotificacion());
        }*/

        //Metodo Listener que se ejecuta cuando se presiona el boton para eliminar una notificacion de la lista.
        /* private void UnreadBorrar_Clicked(object sender, EventArgs e)
         {
             ImageButton button = (ImageButton)sender;
             int ID = (int)button.CommandParameter;

             //Se envia un mensaje al MessagingCenter del ViewModel para ejecutar los cambios. Se incluye el ID recibido por comando.
             MessagingCenter.Send(this, "DeleteNotificacion", ID);
         }

         //Metodo Listener que se ejecuta cuando se desliza una notificacion de la lista para borrarla.
         private void UnreadDelete_Swiped(object sender, SwipedEventArgs e)
         {
             var swipped = (SwipeGestureRecognizer)((StackLayout)sender).GestureRecognizers[0];
             int ID = (int)swipped.CommandParameter;

             //Se envia un mensaje al MessagingCenter del ViewModel para ejecutar los cambios. Se incluye el ID recibido por comando.
             MessagingCenter.Send(this, "DeleteNotificacion", ID);
         }

         //Metodo Listener que se ejecuta cuando se presiona una notificacion de la lista para marcala como leida, dejando de mostrarse en la lista.
         private void MarkReadDelete_Tapped(object sender, EventArgs e)
         {
             var layout = (StackLayout)sender;
             var notif = (Notificacion)layout.Children[1].BindingContext;
             var ID = (string)((TapGestureRecognizer)layout.GestureRecognizers[1]).CommandParameter;

             //Buscar notificacion mediante el ID proporcionado para comprobar que se encuentra en la lista y coincide
             var notifInList = unreadViewModel.NotifStore.GetNotificacionAsync(ID).Result;

             //Solo realizar nuevos cambios si la Notificacion no se habia marcado como leida anteriormente
             if (notif.Id == notifInList.Id && notif.Leido == 0)
             {
                 //Se envia un mensaje al MessagingCenter del ViewModel para ejecutar los cambios. Se incluye la Notificacion detectada por el Listener.
                 MessagingCenter.Send(this, "MarkAsReadNotificacion", notif);
             }
         }*/
    }
}