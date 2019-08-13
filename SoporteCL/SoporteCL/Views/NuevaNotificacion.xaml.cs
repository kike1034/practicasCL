using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoporteCL.Helpers;
using SoporteCL.Models;
using SoporteCL.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/*
 * Vista mostrada para crear Nuevas Notificaciones. Esta clase contiene el codigo que gestiona las interacciones del usuario con el formulario y botones de la vista.
 */
namespace SoporteCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaNotificacion : ContentPage
    {
        //Notificacion nueva
        public Notificacion Notificacion { get; set; }

        public IProfileStore<Profile> ProfilStore => DependencyService.Get<IProfileStore<Profile>>();

        public ObservableRangeCollection<Profile> RedNegocios { get; set; }

        public NuevaNotificacion()
        {
            InitializeComponent();

            //Crear nueva Notificacion e inicializarla
            Notificacion = new Notificacion
            {
                TipoTarget = "Usuario",
                Leido = 0
            };
            //La propia vista es el contexto del que se usuaran los datos por Binding
            RedNegocios = new ObservableRangeCollection<Profile>();
            //Cargar la lista de redes de negocios a las que puede enviar mensajes cuando se cree la pagina.
            LoadRedToSend();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        //Obtiene la lista de redes de negocios de la base de datos (perfiles con jerarquía < que la red de negocios con la que esta logueados)
        private async void LoadRedToSend()
        {
            try
            {
                if (App.Current.Properties.ContainsKey("name")){ 
                    Profile perfillogged = (Profile)App.Current.Properties["name"];
                    var perfiles= await ProfilStore.GetAllProfileAsync();
                    RedNegocios.Clear();
                    foreach(Profile perfil in perfiles)
                    {
                        if (perfil.Jerarquia < perfillogged.Jerarquia) RedNegocios.Add(perfil);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load red de negocios",
                    Cancel = "OK"
                }, "message");
            }
        }
        //Metodo Listener que se ejecuta cuando se presiona el boton para crear y enviar la nueva Notificacion
        private async void Enviar_Clicked(object sender, EventArgs e)
        {
            Notificacion.Fuente = "sender";
            //Se envia un mensaje al MessagingCenter del ViewModel para ejecutar los cambios. Se incluye la Notificacion creada en la vista.
            MessagingCenter.Send(this, "AddNotificacion", Notificacion);
            //PopAsync quita la vista de la cima de la pila de navegacion, volviendo a la pantalla anterior, al igual que al presionar el boton Atras.
            await Navigation.PopAsync();
        }

        //Metodo Listener que se ejecuta cuando se presiona el boton para cancelar la Notificacion
        private async void Cancelar_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(RedNegocios.Count);
            //PopAsync quita la vista de la cima de la pila de navegacion, volviendo a la pantalla anterior, al igual que al presionar el boton Atras.
            await Navigation.PopAsync();
        }

        //Metodo Listener que se ejecuta cuando se cambia el valor del Switch
        private void SwitchSendAll_Toggled(object sender, ToggledEventArgs e)
        {
            //Dependiendo del estado del Switch
            if (e.Value)
            {
                //Si esta activado, el Target es una Red de Negocio, se habilita la entrada para esta y se deshabilita la entrada para Usuarios especificos
                Notificacion.TipoTarget = "RedNegocio";
                destinoNotificacionPersona.Text = "";
                destinoNotificacionPersona.IsEnabled = false;
                destinoNotificacionRedNegocio.IsEnabled = true;
            }
            else
            {
                //Si esta desactivado, el Target es un Usuario Especifico, se habilita la entrada para este y se deshabilita la entrada para una Red de Negocio
                Notificacion.TipoTarget = "Usuario";
                destinoNotificacionRedNegocio.SelectedItem = null;
                destinoNotificacionRedNegocio.IsEnabled = false;
                destinoNotificacionPersona.IsEnabled = true;
            }
        }

        //Metodo Listener que se ejecuta cuando se selecciona una red de Negocio del Picker. El valor de Destino será el de la opcion seleccionada.
        private void RedNegocioSeleccionada(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            Profile destino = (Profile)picker.SelectedItem;
            Notificacion.Destino = destino.Nombre;
        }
    }
}